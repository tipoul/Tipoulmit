using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Tipoul.Framework.DataAccessLayer;
using Tipoul.PersonalGateWay.WebUI.ViewModels;
using Tipoul.Services.Agent;
using Tipoul.Services.Shared.Models.Pay;

namespace Tipoul.PersonalGateWay.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private GateWayService gateWayService;

        private TipoulFrameworkDbContext dbContext;

        public HomeController(GateWayService gateWayService, TipoulFrameworkDbContext dbContext)
        {
            this.gateWayService = gateWayService;
            this.dbContext = dbContext;
        }

        [HttpGet("/")]
        public IActionResult Index()
        {
            return Redirect("https://about.tipoul.com");
            //return View();
        }

        [HttpGet("/{gateWayUrl}/{userId?}/{factorNumber?}/{amount?}")]
        public async Task<IActionResult> Index(string gateWayUrl, [FromRoute] int? amount)
        {
            var gateWay = await dbContext.CommertialGateWays.Where(f => f.WebSiteURL.EndsWith("/" + gateWayUrl)).FirstOrDefaultAsync();

            if (gateWay == null)
                return NotFound();

            ViewBag.Amount = amount;

            return View(gateWay);
        }

        [HttpPost("/{gateWayUrl}/{userId?}/{factorNumber?}/{amount?}")]
        public async Task Index(string gateWayUrl, string userId, string factorNumber, [FromRoute] int? amount, [FromForm] GetTokenModel model, [FromForm] string payerFirstName, [FromForm] string payerLastName)
        {
            var gateWay = await dbContext.CommertialGateWays.Where(f => f.WebSiteURL.EndsWith("/" + gateWayUrl)).FirstOrDefaultAsync();

            if (string.IsNullOrWhiteSpace(model.PayerName))
                model.PayerName = $"{(payerFirstName ?? "")} {payerLastName ?? ""}".Trim();

            model.CallBackUrl = $"{Request.Scheme}://{Request.Host}/{gateWayUrl}/callback";
            model.GateToken = gateWay.Token;
            model.PayerUserId = userId;
            model.FactorNumber = factorNumber;

            if (amount.HasValue)
                model.Amount = (amount.Value / 213) * 10000;

            var token = await gateWayService.GetToken(model);

            await gateWayService.StartAsync(new StartModel
            {
                TipoulAccessToken = token.AccessToken
            });
        }

        [HttpGet("/{gateWayUrl}/callback")]
        public async Task<IActionResult> Callback(string gateWayUrl)
        {
            var gateWay = await dbContext.CommertialGateWays.Where(f => f.WebSiteURL.EndsWith("/" + gateWayUrl)).FirstOrDefaultAsync();
            var transaction = await dbContext.Transactions.Include(f => f.TransactionResponse).Include(f => f.GetTokenModel).Where(f => f.TransactionConfirmResult != null).FirstOrDefaultAsync();
            var viewModel = new CallBackViewModel
            {
                LogoUrl = gateWay.LogoUrl,
                Title = gateWay.Title,
                Amount = 10000,
                CardNumber = transaction.TransactionResponse.CardNumber,
                DatePaid = transaction.TransactionResponse.DatePaid,
                FactorNumber = transaction.GetTokenModel.FactorNumber,
                IssuerBank = transaction.TransactionResponse.IssuerBank,
                RespCode = transaction.TransactionResponse.RespCode,
                RespMsg = transaction.TransactionResponse.RespMsg?.Substring(3),
                RRN = transaction.TransactionResponse.RRN,
                TipoulTraceNumber = transaction.TipoulTraceNumber,
                TipoulTrackNumber = transaction.TransactionResponse.TipoulTrackNumber,
                TraceNumber = transaction.TransactionResponse.TraceNumber
            };

            return View(viewModel);
        }

        [HttpPost("/{gateWayUrl}/callback")]
        public async Task<IActionResult> Callback(string gateWayUrl, [FromServices] GateWayService gateWayService)
        {
            var gateWay = await dbContext.CommertialGateWays.Where(f => f.WebSiteURL.EndsWith("/" + gateWayUrl)).FirstOrDefaultAsync();

            string TipoulTraceNumber = HttpContext.Request.Form["TipoulTraceNumber"];

            var viewModel = new CallBackViewModel();
            viewModel.LogoUrl = gateWay.LogoUrl;
                viewModel.Title = gateWay.Title;
            long.TryParse(HttpContext.Request.Form["Amount"], out long Amount);
            viewModel.Amount = Amount;
            viewModel.CardNumber = HttpContext.Request.Form["CardNumber"];
            viewModel.DatePaid = HttpContext.Request.Form["DatePaid"];
            viewModel.FactorNumber = HttpContext.Request.Form["FactorNumber"];
            viewModel.IssuerBank = HttpContext.Request.Form["IssuerBank"];
            int.TryParse(HttpContext.Request.Form["RespCode"], out int RespCode);
            viewModel.RespCode = RespCode;
            viewModel.RespMsg = HttpContext.Request.Form["RespMsg"];
            viewModel.RRN = HttpContext.Request.Form["RRN"];
            viewModel.TipoulTraceNumber = TipoulTraceNumber;
            viewModel.TipoulTrackNumber = HttpContext.Request.Form["TipoulTrackNumber"];
            long.TryParse(HttpContext.Request.Form["TraceNumber"], out long TraceNumber);
            viewModel.TraceNumber = TraceNumber;

            if (RespCode == 0)
            {
                var confirmResult = await gateWayService.ConfirmAsync(new ConfirmModel
                {
                    TipoulTraceNumber = TipoulTraceNumber
                });

                if (confirmResult.Status == ConfirmResult.ConfirmStatus.NOK)
                {
                    viewModel.RespMsg = confirmResult.Message;
                    viewModel.ReturnId = confirmResult.ReturnId;
                }
                else
                {
                    viewModel.Success = true;
                    viewModel.PayerName = await dbContext.Transactions.Where(f => f.TipoulTraceNumber == TipoulTraceNumber).Select(f => f.GetTokenModel.PayerName).FirstOrDefaultAsync();
                }
            }

            return View(viewModel);
        }
    }
}
