using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text.Json;
using Tipoul.Console.WebApi;

using Tipoul.Framework.Services.IranKishGateWay;
using Tipoul.Shaparak.Services.Data;
using Tipoul.Framework.Utilities.Utilities;
using Tipoul.Infrastructure.RequestLog.Services;
using Tipoul.Shaparak.Switch;
using Tipoul.Framework.DataAccessLayer;
using Tipoul.Framework.Services.OpenBanking.Shahin.Data;
using Tipoul.Framework.Services.OpenBanking.Shahin.Infrastructure;
using Azure;
//using SharedModels = Tipoul.Services.Shared.Models;

namespace Tipoul.Services.WebApiii.Controllers
{
    [Route("[controller]/v1")]
    public class PayController : ControllerBase
    {

        private readonly IConfiguration configuration;     
        private readonly RequestLogService requestLogService;      
        private static Random rand = new Random((int)DateTime.Now.Ticks);
        protected readonly TipoulFrameworkDbContext _TipouldbContext;
        private readonly Tipoul.Shaparak.Services.Data.Context _dbContext;
        private readonly string TokenUrl;
        private readonly string ApiUrl;
        private readonly string UserName;
        private readonly string Password;

        private readonly IUnitOfWork _unitOfWork;       

        public PayController(IConfiguration config, Tipoul.Shaparak.Services.Data.Context dbContext)
        {
              

            _dbContext = dbContext;
            
        }

        [HttpPost("getToken")]
        public async Task<GetTokenResult> GetToken([FromServices] IConfiguration configuration, [FromBody] GetTokenModel model)
        {

            
            try
            {
                var traceNumber = DateTime.Now.TimeOfDay.TotalMilliseconds.ToString().Substring(DateTime.Now.TimeOfDay.TotalMilliseconds.ToString().Length - 4);
                traceNumber += rand.Next(1000, 9999);
                traceNumber += new PersianCalendar().GetDayOfMonth(DateTime.Now).ToString().PadLeft(2, '0');
                traceNumber += rand.Next(1000, 9999);
               
                Tipoul.Shaparak.Switch.Model.GetToken.InModel modelipg = new Shaparak.Switch.Model.GetToken.InModel();

                modelipg.IPG = model.IPG;
                modelipg.BlankForTransaction = model.BlankForTransaction;
                modelipg.BlankForPayer = model.BlankForPayer;
                modelipg.ValidCardNum = model.ValidCardNum;
                modelipg.Amount = model.Amount;
                modelipg.PayerUserId = model.PayerUserId;
                modelipg.FactorNumber = model.FactorNumber;
                modelipg.PayerName = model.PayerName;
                modelipg.Description = model.Description;
                modelipg.GateToken = model.GateToken;
                modelipg.CallBackUrl = model.CallBackUrl;
                modelipg.PayerMobile = model.PayerMobile;

                


                HomeController sw=new HomeController(_dbContext);
                Task<string>a= sw.IPGParameter(model.IPG, modelipg, null);

               GetTokenResult gr = new GetTokenResult();
                gr.AccessToken = a.Result;      



                return gr;
            }
            catch (Exception ex)
            {
                return null;
                //return new SharedModels.Common.ApiResult<SharedModels.Pay.GetTokenResult>(ex, -1);
            }
        }

        [HttpPost("start")]
        public async Task Start()
        {
            try
            {
                //    var transaction = await dbContext.Transactions.Include(f => f.GetTokenModel).Include(f => f.GateWay).FirstOrDefaultAsync(f => f.GetTokenResult.TipoulAccessToken == model.TipoulAccessToken);

                //    if (transaction == null)
                //        throw new Exception("Token not provided");

                //    transaction.RequestId = requestLogService.RequestId;

                //    transaction.RedirectToGateWay = DateTime.Now;

                //    await iranKishService.Redirect(responseUtilities, transaction.ISPAccessToken, JsonSerializer.Serialize(new { transactionId = transaction.Id, requestLogService.RequestId, gateWayId = transaction.GateWay.Id, transaction.ISPAccessToken }));
            }
            catch (Exception ex)
            {
                await Response.WriteAsJsonAsync(new { Success = false, Error = ex.Message });
            }
        }

        [HttpGet]
        [Route("/Pay/v2/start")]
        public async Task StartGet()
        {
            try
            {
                //string TokenHashed = "";
                //if (HttpContext.Request.Query.ContainsKey("TokenHashed"))
                //    TokenHashed = HttpContext.Request.Query["TokenHashed"].ToString();
                //var transaction = await dbContext.Transactions.Include(f => f.GetTokenModel).Include(f => f.GateWay).FirstOrDefaultAsync(f => f.GetTokenResult.TipoulAccessTokenHashed == TokenHashed);

                //if (transaction == null)
                //    throw new Exception("Token not provided");

                //transaction.RequestId = requestLogService.RequestId;
                //transaction.RedirectToGateWay = DateTime.Now;
                //await dbContext.SaveChangesAsync();

                //await iranKishService.Redirect(responseUtilities, transaction.ISPAccessToken, JsonSerializer.Serialize(new { transactionId = transaction.Id, requestLogService.RequestId, gateWayId = transaction.GateWay.Id, transaction.ISPAccessToken }));
            }
            catch (Exception ex)
            {
                await Response.WriteAsJsonAsync(new { Success = false, Error = ex.Message });
            }
        }

        [HttpPost("callback")]
        //[HttpGet("callback")]
        public async Task Callback()
        {
            long.TryParse(HttpContext.Request.Form["RefId"].ToString(), out long RequestID);
            //var transaction = await dbContext.Transactions.Include(f => f.GetTokenModel).OrderByDescending(f => f.CreateDate).FirstOrDefaultAsync(f => f.InvoiceId == RequestID.ToString());

            //transaction.TransactionResponse = new Framework.StorageModels.TransactionResponse();
            //long.TryParse(HttpContext.Request.Form["Amount"], out long Amount);
            //transaction.TransactionResponse.Amount = Amount;
            //transaction.TransactionResponse.CardNumber = HttpContext.Request.Form["maskedPan"];
            //transaction.TransactionResponse.DatePaid = HttpContext.Request.Form["DatePaid"];
            //transaction.TransactionResponse.SAN = HttpContext.Request.Form["systemTraceAuditNumber"];
            //transaction.TransactionResponse.IssuerBank = HttpContext.Request.Form["IssuerBank"];
            //int.TryParse(HttpContext.Request.Form["responseCode"].ToString(), out int responseCode);
            //transaction.TransactionResponse.RespCode = responseCode;
            //transaction.TransactionResponse.RespMsg = HttpContext.Request.Form["RespMsg"];
            //transaction.TransactionResponse.RRN = HttpContext.Request.Form["retrievalReferenceNumber"];
            //transaction.TransactionResponse.TraceNumber = RequestID;
            //transaction.TransactionResponse.TerminalId = transaction.GateWayId.Value;
            //transaction.TransactionResponse.TipoulTrackNumber = rand.Next(1000000, 9999999) + transaction.GateWayId.ToString() + rand.Next(1000000, 9999999);

            //await dbContext.SaveChangesAsync();

            //await responseUtilities.RedirectUsingPost(transaction.GetTokenModel.CallBackUrl, new SharedModels.Pay.CallbackModel
            //{
            //    Amount = transaction.TransactionResponse.Amount,
            //    CardNumber = transaction.TransactionResponse.CardNumber,
            //    IssuerBank = transaction.TransactionResponse.IssuerBank,
            //    RRN = transaction.TransactionResponse.RRN,
            //    DatePaid = transaction.TransactionResponse.DatePaid,
            //    TraceNumber = transaction.TransactionResponse.TraceNumber,
            //    FactorNumber = transaction.GetTokenModel.FactorNumber,
            //    RespCode = transaction.TransactionResponse.RespCode,
            //    RespMsg = transaction.TransactionResponse.RespMsg,
            //    TipoulTrackNumber = transaction.TransactionResponse.TipoulTrackNumber,
            //    TipoulTraceNumber = transaction.TipoulTraceNumber
            //});
        }

        [HttpPost("confirm")]
        public async Task<int> Confirm()
        {
            return 1;
            try
            {
                //var transaction = await dbContext.Transactions
                //    //.Include(f => f.TransactionResponse)
                //    //.Include(f => f.GetTokenModel)
                //    //.Include(f => f.GateWay).ThenInclude(f => f.Wallet)
                //    .OrderByDescending(f => f.CreateDate)
                //    //.FirstOrDefaultAsync(f => f.TipoulTraceNumber == model.TipoulTraceNumber);

                //var transaction = await dbContext.Transactions

                //.OrderByDescending(f => f.CreateDate)
                //    .FirstOrDefault(f => f.TipoulTraceNumber == model.TipoulTraceNumber);

                //transaction.TransactionConfirmModel = new Framework.StorageModels.TransactionConfirmModel
                //{
                //    TipoulTraceNumber = model.TipoulTraceNumber
                //};

                //await dbContext.SaveChangesAsync();
                //Framework.Services.IranKishGateWay.Models.ConfirmModel confirmModel = new Framework.Services.IranKishGateWay.Models.ConfirmModel(transaction.GateWay.TerminalNumber,
                //    transaction.TransactionResponse.RRN.ToString(), transaction.TransactionResponse.SAN.ToString(), transaction.ISPAccessToken);
                //var confirmResult = await iranKishService.Confirm(confirmModel, JsonSerializer.Serialize(new { transactionId = transaction.Id, requestLogService.RequestId }));

                //transaction.TransactionConfirmResult = new Framework.StorageModels.TransactionConfirmResult();
                //transaction.TransactionConfirmResult.Message = confirmResult.Description;
                //transaction.TransactionConfirmResult.ReturnId = confirmResult.ResponseCode;
                //SharedModels.Pay.ConfirmResult.ConfirmStatus status = confirmResult.Status ? SharedModels.Pay.ConfirmResult.ConfirmStatus.OK : SharedModels.Pay.ConfirmResult.ConfirmStatus.NOK;
                //transaction.TransactionConfirmResult.Status = Enum.Parse<Framework.StorageModels.TransactionConfirmResult.ConfirmStatus>(status.ToString(), true);
                //transaction.TransactionConfirmResult.TipoulTrackNumber = rand.Next(1000000, 9999999) + transaction.GateWayId.ToString() + rand.Next(1000000, 9999999);

                //if (transaction.TransactionConfirmResult.Status == Framework.StorageModels.TransactionConfirmResult.ConfirmStatus.OK)
                //{
                //    transaction.GateWay.Wallet.Amount += transaction.GetTokenModel.Amount;
                //    transaction.GateWay.Wallet.AmountInHand += transaction.GetTokenModel.Amount;
                //    //if (transaction.GateWay.Settlement == Framework.StorageModels.CommertialGateWay.SettlementType.Manual)
                //    transaction.GateWay.Wallet.AmountSettlementable += transaction.GetTokenModel.Amount;
                //}

                //await dbContext.SaveChangesAsync();
                //SharedModels.Pay.ConfirmResult confirmResultPay = new SharedModels.Pay.ConfirmResult();
                //confirmResultPay.Message = confirmResult.Description;
                //confirmResultPay.ReturnId = confirmResult.ResponseCode;
                //SharedModels.Pay.ConfirmResult.ConfirmStatus statusPay = confirmResult.Status ? SharedModels.Pay.ConfirmResult.ConfirmStatus.OK : SharedModels.Pay.ConfirmResult.ConfirmStatus.NOK;
                //confirmResultPay.Status = Enum.Parse<SharedModels.Pay.ConfirmResult.ConfirmStatus>(statusPay.ToString(), true);
                //confirmResultPay.TipoulTrackNumber = transaction.TransactionConfirmResult.TipoulTrackNumber;
                //return new SharedModels.Common.ApiResult<SharedModels.Pay.ConfirmResult>(confirmResultPay);

            }
            catch (Exception ex)
            {
                return 0;
                //return new SharedModels.Common.ApiResult<SharedModels.Pay.ConfirmResult>(ex, -1);
            }
        }
    }
}
