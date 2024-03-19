using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Tipoul.Framework.DataAccessLayer;
using Tipoul.Framework.Services.IranKishGateWay;
using Tipoul.Framework.Utilities.Utilities;
using Tipoul.Infrastructure.RequestLog.Services;

using SharedModels = Tipoul.Services.Shared.Models;

namespace Tipoul.Services.WebApi.Controllers
{
    [Route("[controller]/v1")]
    public class PayController : ControllerBase
    {
        private readonly TipoulFrameworkDbContext dbContext;
        private readonly IranKishGateWayService iranKishService;
        private readonly RequestLogService requestLogService;
        private readonly ResponseUtilities responseUtilities;
        private static Random rand = new Random((int)DateTime.Now.Ticks);
        public PayController(IranKishGateWayService iranKishService, RequestLogService requestLogService,
            TipoulFrameworkDbContext dbContext, ResponseUtilities responseUtilities)
        {
            this.iranKishService = iranKishService;
            this.requestLogService = requestLogService;
            this.dbContext = dbContext;
            this.responseUtilities = responseUtilities;
        }

        [HttpPost("getToken")]
        public async Task<SharedModels.Common.ApiResult<SharedModels.Pay.GetTokenResult>> GetToken([FromServices] IConfiguration configuration, [FromBody] SharedModels.Pay.GetTokenModel model)
        {
            try
            {
                var traceNumber = DateTime.Now.TimeOfDay.TotalMilliseconds.ToString().Substring(DateTime.Now.TimeOfDay.TotalMilliseconds.ToString().Length - 4);
                traceNumber += rand.Next(1000, 9999);
                traceNumber += new PersianCalendar().GetDayOfMonth(DateTime.Now).ToString().PadLeft(2, '0');
                traceNumber += rand.Next(1000, 9999);

                var invoiceId = requestLogService.RequestId.ToString();

                var transaction = new Framework.StorageModels.Transaction
                {
                    TipoulTraceNumber = traceNumber,
                    InvoiceId = invoiceId,
                    SelectedPSP = Framework.StorageModels.Transaction.PSP.IranKish,
                    GetTokenModel = new Framework.StorageModels.GetTokenModel
                    {
                        Amount = model.Amount,
                        RequestId = requestLogService.RequestId,
                        BlankForPayer = model.BlankForPayer,
                        BlankForTransaction = model.BlankForTransaction,
                        CallBackUrl = model.CallBackUrl,
                        Description = model.Description,
                        FactorNumber = model.FactorNumber,
                        GateToken = model.GateToken,
                        IPG = model.IPG,
                        PayerUserId = model.PayerUserId,
                        PayerMail = model.PayerMail,
                        PayerMobile = model.PayerMobile,
                        PayerName = model.PayerName,
                        ValidCardNum = model.ValidCardNum != null ? string.Join(",", model.ValidCardNum) : string.Empty
                    }
                };

                dbContext.Transactions.Add(transaction);

                await dbContext.SaveChangesAsync();

                if (string.IsNullOrWhiteSpace(model.GateToken = model.GateToken?.Trim()))
                    throw new Exception("Token not provided");

                var gateWay = await dbContext.CommertialGateWays.Include(f => f.Wallet).FirstOrDefaultAsync(f => f.Token == model.GateToken);

                if (gateWay == null)
                    throw new Exception("Invalid token provided");

                if (string.IsNullOrWhiteSpace(gateWay.TerminalNumber))
                    throw new Exception("Gate way is not activated");

                transaction.GateWay = gateWay;

                await dbContext.SaveChangesAsync();

                //if (!Request.Headers["Referer"].ToString().StartsWith(gateWay.WebSiteURL) && !string.IsNullOrWhiteSpace(Request.Headers["Referer"].ToString()))
                //{
                //    transaction.InvalidReferer = true;

                //    await dbContext.SaveChangesAsync();

                //    throw new Exception("Invalid referer");
                //}

                //if (!model.CallBackUrl.StartsWith(gateWay.WebSiteURL))
                //{
                //    transaction.InvalidCallbackUrl = true;

                //    await dbContext.SaveChangesAsync();

                //    throw new Exception("Invalid callback url provided");
                //}

                var redirecUrl = $"{configuration["Tipoul:GateWayAddress"]}/pay/v1/callback";

                var wageData = await dbContext.UserWageTypeHistories.Where(f => f.UserId == gateWay.Wallet.UserId).OrderByDescending(f => f.CreateDate).FirstOrDefaultAsync();

                if (wageData != null)
                {
                    Framework.StorageModels.UserWageHistory wageHistory = null;

                    if (wageData.WageType == Framework.StorageModels.UserWageTypeHistory.UserWageType.FromTransaction && wageData.RelativeAmount.HasValue)
                    {
                        wageHistory = new Framework.StorageModels.UserWageHistory
                        {
                            UserId = gateWay.Wallet.UserId,
                            Amount = (transaction.GetTokenModel.Amount * wageData.RelativeAmount.Value) / 100,
                            UserWageTypeHistory = wageData
                        };

                        if (wageData.MaxRelativeAmount.HasValue && wageData.MaxRelativeAmount.Value < wageHistory.Amount)
                            wageHistory.Amount = wageData.MaxRelativeAmount.Value;
                    }
                    if (wageData.WageType == Framework.StorageModels.UserWageTypeHistory.UserWageType.FromTransactionStaticAmount && wageData.StaticAmount.HasValue)
                    {
                        wageHistory = new Framework.StorageModels.UserWageHistory
                        {
                            UserId = gateWay.Wallet.UserId,
                            Amount = wageData.StaticAmount.Value,
                            UserWageTypeHistory = wageData
                        };
                    }
                    if (wageHistory != null && wageHistory.Amount > 0)
                    {
                        dbContext.UserWageHistories.Add(wageHistory);

                        if (gateWay.WageSide == Framework.StorageModels.CommertialGateWay.WagePayerSide.FromPayer)
                            transaction.GetTokenModel.Amount += wageHistory.Amount;

                        await dbContext.SaveChangesAsync();
                    }
                    if (wageHistory != null && wageHistory.Id != 0)
                    {
                        transaction.UserWageHistoryId = wageHistory.Id;

                        await dbContext.SaveChangesAsync();
                    }
                }
                var tokenModel = new Framework.Services.IranKishGateWay.Models.GetTokenModel(gateWay.MerchantNumber, transaction.GetTokenModel.Amount, transaction.GetTokenModel.FactorNumber,
                    requestLogService.RequestId.ToString(), redirecUrl, gateWay.TerminalNumber, gateWay.RsaPublicKey, gateWay.PassPhrase);

                var tokenResult = await iranKishService.GetToken(tokenModel, JsonSerializer.Serialize(new { requestLogService.RequestId, gateWayId = transaction.GateWay.Id }));
                if (tokenResult.Status != true)
                {
                    transaction.ISPAccessTokenErrorMessage = tokenResult.Status.ToString();
                    await dbContext.SaveChangesAsync();
                    throw new Exception("Gate way exception");
                }

                transaction.ISPAccessToken = tokenResult.Result.Token;

                var claims = new Dictionary<string, string>();

                claims.Add("Amount", model.Amount.ToString());
                claims.Add("CallBackUrl", model.CallBackUrl);
                claims.Add("FactorNumber", model.FactorNumber);
                claims.Add("GateToken", model.GateToken);
                claims.Add("Date", DateTime.Now.ToShortDateString());
                claims.Add("Time", DateTime.Now.ToShortTimeString());

                transaction.GetTokenResult = new Framework.StorageModels.GetTokenResult
                {
                    TipoulAccessToken = JWTUtility.GenerateToken(claims),
                    TipoulTrackNumber = rand.Next(1000000, 9999999) + gateWay.Id.ToString() + rand.Next(1000000, 9999999)
                };
                transaction.GetTokenResult.TipoulAccessTokenHashed = transaction.GetTokenResult.TipoulAccessToken.MD5Hash();
                await dbContext.SaveChangesAsync();
                //insert token
                return new SharedModels.Common.ApiResult<SharedModels.Pay.GetTokenResult>(new SharedModels.Pay.GetTokenResult
                {
                    AccessToken = transaction.GetTokenResult.TipoulAccessToken,
                    AccessTokenHashed = transaction.GetTokenResult.TipoulAccessTokenHashed,
                    TipoulTraceNumber = transaction.TipoulTraceNumber,
                    TipoulTrackNumber = transaction.GetTokenResult.TipoulTrackNumber
                });
            }
            catch (Exception ex)
            {

                return new SharedModels.Common.ApiResult<SharedModels.Pay.GetTokenResult>(ex, -1);
            }
        }

        [HttpPost("start")]
        public async Task Start([FromForm] SharedModels.Pay.StartModel model)
        {
            try
            {
                var transaction = await dbContext.Transactions.Include(f => f.GetTokenModel).Include(f => f.GateWay).FirstOrDefaultAsync(f => f.GetTokenResult.TipoulAccessToken == model.TipoulAccessToken);

                if (transaction == null)
                    throw new Exception("Token not provided");

                transaction.RequestId = requestLogService.RequestId;

                transaction.RedirectToGateWay = DateTime.Now;

                await iranKishService.Redirect(responseUtilities, transaction.ISPAccessToken, JsonSerializer.Serialize(new { transactionId = transaction.Id, requestLogService.RequestId, gateWayId = transaction.GateWay.Id, transaction.ISPAccessToken }));
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
                string TokenHashed = "";
                if (HttpContext.Request.Query.ContainsKey("TokenHashed"))
                    TokenHashed = HttpContext.Request.Query["TokenHashed"].ToString();
                var transaction = await dbContext.Transactions.Include(f => f.GetTokenModel).Include(f => f.GateWay).FirstOrDefaultAsync(f => f.GetTokenResult.TipoulAccessTokenHashed == TokenHashed);

                if (transaction == null)
                    throw new Exception("Token not provided");

                transaction.RequestId = requestLogService.RequestId;
                transaction.RedirectToGateWay = DateTime.Now;
                await dbContext.SaveChangesAsync();

                await iranKishService.Redirect(responseUtilities, transaction.ISPAccessToken, JsonSerializer.Serialize(new { transactionId = transaction.Id, requestLogService.RequestId, gateWayId = transaction.GateWay.Id, transaction.ISPAccessToken }));
            }
            catch (Exception ex)
            {
                await Response.WriteAsJsonAsync(new { Success = false, Error = ex.Message });
            }
        }

        [HttpPost("callback")]
        //[HttpGet("callback")]
        public async Task Callback([FromForm] Tipoul.Services.Shared.Models.Pay.CallbackModel model)
        {
            long.TryParse(HttpContext.Request.Form["RequestID"].ToString(), out long RequestID);
            var transaction = await dbContext.Transactions.Include(f => f.GetTokenModel).OrderByDescending(f => f.CreateDate).FirstOrDefaultAsync(f => f.InvoiceId == RequestID.ToString());

            transaction.TransactionResponse = new Framework.StorageModels.TransactionResponse();
            long.TryParse(HttpContext.Request.Form["Amount"], out long Amount);
            transaction.TransactionResponse.Amount = Amount;
            transaction.TransactionResponse.CardNumber = HttpContext.Request.Form["maskedPan"];
            transaction.TransactionResponse.DatePaid = HttpContext.Request.Form["DatePaid"];
            transaction.TransactionResponse.SAN = HttpContext.Request.Form["systemTraceAuditNumber"];
            transaction.TransactionResponse.IssuerBank = HttpContext.Request.Form["IssuerBank"];
            int.TryParse(HttpContext.Request.Form["responseCode"].ToString(), out int responseCode);
            transaction.TransactionResponse.RespCode = responseCode;
            transaction.TransactionResponse.RespMsg = HttpContext.Request.Form["RespMsg"];
            transaction.TransactionResponse.RRN = HttpContext.Request.Form["retrievalReferenceNumber"];
            transaction.TransactionResponse.TraceNumber = RequestID;
            transaction.TransactionResponse.TerminalId = transaction.GateWayId.Value;
            transaction.TransactionResponse.TipoulTrackNumber = rand.Next(1000000, 9999999) + transaction.GateWayId.ToString() + rand.Next(1000000, 9999999);

            await dbContext.SaveChangesAsync();

            await responseUtilities.RedirectUsingPost(transaction.GetTokenModel.CallBackUrl, new SharedModels.Pay.CallbackModel
            {
                Amount = transaction.TransactionResponse.Amount,
                CardNumber = transaction.TransactionResponse.CardNumber,
                IssuerBank = transaction.TransactionResponse.IssuerBank,
                RRN = transaction.TransactionResponse.RRN,
                DatePaid = transaction.TransactionResponse.DatePaid,
                TraceNumber = transaction.TransactionResponse.TraceNumber,
                FactorNumber = transaction.GetTokenModel.FactorNumber,
                RespCode = transaction.TransactionResponse.RespCode,
                RespMsg = transaction.TransactionResponse.RespMsg,
                TipoulTrackNumber = transaction.TransactionResponse.TipoulTrackNumber,
                TipoulTraceNumber = transaction.TipoulTraceNumber
            });
        }

        [HttpPost("confirm")]
        public async Task<SharedModels.Common.ApiResult<SharedModels.Pay.ConfirmResult>> Confirm([FromBody] SharedModels.Pay.ConfirmModel model)
        {
            try
            {
                var transaction = await dbContext.Transactions
                    .Include(f => f.TransactionResponse)
                    .Include(f => f.GetTokenModel)
                    .Include(f => f.GateWay).ThenInclude(f => f.Wallet)
                    .OrderByDescending(f => f.CreateDate)
                    .FirstOrDefaultAsync(f => f.TipoulTraceNumber == model.TipoulTraceNumber);

                transaction.TransactionConfirmModel = new Framework.StorageModels.TransactionConfirmModel
                {
                    TipoulTraceNumber = model.TipoulTraceNumber
                };

                await dbContext.SaveChangesAsync();
                Framework.Services.IranKishGateWay.Models.ConfirmModel confirmModel = new Framework.Services.IranKishGateWay.Models.ConfirmModel(transaction.GateWay.TerminalNumber,
                    transaction.TransactionResponse.RRN.ToString(), transaction.TransactionResponse.SAN.ToString(), transaction.ISPAccessToken);
                var confirmResult = await iranKishService.Confirm(confirmModel, JsonSerializer.Serialize(new { transactionId = transaction.Id, requestLogService.RequestId }));

                transaction.TransactionConfirmResult = new Framework.StorageModels.TransactionConfirmResult();
                transaction.TransactionConfirmResult.Message = confirmResult.Description;
                transaction.TransactionConfirmResult.ReturnId = confirmResult.ResponseCode;
                SharedModels.Pay.ConfirmResult.ConfirmStatus status = confirmResult.Status ? SharedModels.Pay.ConfirmResult.ConfirmStatus.OK : SharedModels.Pay.ConfirmResult.ConfirmStatus.NOK;
                transaction.TransactionConfirmResult.Status = Enum.Parse<Framework.StorageModels.TransactionConfirmResult.ConfirmStatus>(status.ToString(), true);
                transaction.TransactionConfirmResult.TipoulTrackNumber = rand.Next(1000000, 9999999) + transaction.GateWayId.ToString() + rand.Next(1000000, 9999999);

                if (transaction.TransactionConfirmResult.Status == Framework.StorageModels.TransactionConfirmResult.ConfirmStatus.OK)
                {
                    transaction.GateWay.Wallet.Amount += transaction.GetTokenModel.Amount;
                    transaction.GateWay.Wallet.AmountInHand += transaction.GetTokenModel.Amount;
                    //if (transaction.GateWay.Settlement == Framework.StorageModels.CommertialGateWay.SettlementType.Manual)
                        transaction.GateWay.Wallet.AmountSettlementable += transaction.GetTokenModel.Amount;
                }

                await dbContext.SaveChangesAsync();
                SharedModels.Pay.ConfirmResult confirmResultPay = new SharedModels.Pay.ConfirmResult();
                confirmResultPay.Message = confirmResult.Description;
                confirmResultPay.ReturnId = confirmResult.ResponseCode;
                SharedModels.Pay.ConfirmResult.ConfirmStatus statusPay = confirmResult.Status ? SharedModels.Pay.ConfirmResult.ConfirmStatus.OK : SharedModels.Pay.ConfirmResult.ConfirmStatus.NOK;
                confirmResultPay.Status = Enum.Parse<SharedModels.Pay.ConfirmResult.ConfirmStatus>(statusPay.ToString(), true);
                confirmResultPay.TipoulTrackNumber = transaction.TransactionConfirmResult.TipoulTrackNumber;
                return new SharedModels.Common.ApiResult<SharedModels.Pay.ConfirmResult>(confirmResultPay);

            }
            catch (Exception ex)
            {
                return new SharedModels.Common.ApiResult<SharedModels.Pay.ConfirmResult>(ex, -1);
            }
        }
    }
}