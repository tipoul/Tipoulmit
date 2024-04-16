using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

using Wallet2.Models;

namespace Wallet2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly JsonSerializerOptions camelCaseSettings = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, PropertyNameCaseInsensitive = true, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping };
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public async Task<IActionResult> console(long amount, string mobile, string nationalcode)
        {

            //GetTokenModel model = new GetTokenModel();
            //model.Amount = amount;
            //model.FactorNumber = "";
            //model.IPG = "BPT";
            //model.ValidCardNum = null;
            //model.PayerName = "";
            //model.PayerUserId = null;
            //model.BlankForPayer = nationalcode;
            //model.BlankForTransaction = "";
            //model.CallBackUrl = "http://www.google.com";
            //model.PayerMobile = mobile;
            //model.Description = "";
            //model.GateToken = "66b3cebc-b125-4c73-90d3-d9ace2a68b44";




            //var ApiUrl = "https://localhost:7260/Pay/v1/getToken";

            //var modelString = JsonSerializer.Serialize(model, camelCaseSettings);
            //var stringContent = new StringContent(modelString, null, "application/json");





            //using (var httpClient = new HttpClient())
            //{
            //    var m = await httpClient.PostAsync(ApiUrl, stringContent);
            //    //CallApi _cai = new CallApi();
            //    //return  httpClient.PostAsync(ApiUrl,);
            //}

            //var response = await _cai.CallShahinApiAsync(url, modelString, access_token, X_Obh_timestamp, X_Obh_uuid, UserName, Password);
            //var responseString = await response.Content.ReadAsStringAsync();
            //requestLog.Body = modelString;
            //requestLog.Response = responseString;
            //requestLog.Success = response.IsSuccessStatusCode;
            //CardInfoResult resultModel = JsonSerializer.Deserialize<CardInfoResult>(responseString);

            //return resultModel;



            //GetToken.
            //Tipoul.Console.WebApi s = new GetTokenModel();
            //s.();



            //PayController m = new PayController();
            //GetToken()
            //var user = athenticationProvider.GetUser();



            //dbContext.Settlements.Add(new Settlement
            //{
            //	Amount = amount,
            //	BankAccountId = bankAccountId,
            //	UserId = user.Id,
            //	WalletId = walletId,
            //	QuickSettlement = false,
            //	SettlementStatusHistories = new List<SettlementStatusHistory> { new SettlementStatusHistory { Status = SettlementStatusHistory.SettlementStatus.InReview, UserId = user.Id } }
            //});

            //dbContext.Wallets.Where(f => f.Id == walletId).ToList().ForEach(f => { f.Amount -= amount; f.AmountInHand -= amount; f.AmountSettlementable -= amount; });
            //await dbContext.SaveChangesAsync();

            //return Redirect(Request.Headers["Referer"]);

            return null;
        }
    }
}
