using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Tipoul.Athentication.Agent.Services;
using Tipoul.Framework.DataAccessLayer;
using Tipoul.Framework.ShahinService.ShahinOperation;
using Tipoul.Framework.ShahinService.ShahinOperation.Enums;
using Tipoul.Framework.ShahinService.ShahinOperation.Models;
using Tipoul.Framework.StorageModels;
using Tipoul.Framework.Utilities.Converters;
using Tipoul.Framework.Utilities.Enums;
using Tipoul.Framework.Utilities.Extentions;
using Tipoul.Framework.Utilities.Utilities;
using Tipoul.Infrastructure.RequestLog.StorageModels;
using Tipoul.UserPanel.WebUI.Models.Wallet;
using static Tipoul.Framework.StorageModels.SettlementStatusHistory;

namespace Tipoul.UserPanel.WebUI.Controllers
{
    public class WalletController : Controller
    {
        private readonly TipoulFrameworkDbContext dbContext;

        private readonly AthenticationProvider athenticationProvider;
        private readonly ShahinService shahinService;
        private readonly IConfiguration configuration;
        public WalletController(TipoulFrameworkDbContext dbContext, AthenticationProvider athenticationProvider,
            ShahinService shahinService, IConfiguration configuration)
        {
            this.dbContext = dbContext;
            this.athenticationProvider = athenticationProvider;
            this.shahinService = shahinService;
            this.configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {
            var user = athenticationProvider.GetUser();

            var data = await dbContext.Wallets.Where(f => f.UserId == user.Id).ToListAsync();
            var userInfo = dbContext.Users.Where(f => f.Id == user.Id).FirstOrDefault();
            ViewBag.QuickSettlement = userInfo.QuickSettlement;
            var viewModel = data.ConvertAll(f => new WalletViewModel
            {
                Id = f.Id,
                Title = f.Title,
                Amount = f.Amount,
                AmountInHand = f.AmountInHand,
                AmountSettlementable = f.AmountSettlementable,
                AmountInTipoul = f.AmountInTipoul
            });
            foreach (var wallet in viewModel)
            {
                wallet.AmountWage = (from uwh in dbContext.UserWageHistories.Where(f => f.UserId == user.Id)
                                     join trs in dbContext.Transactions on uwh.Id equals trs.UserWageHistoryId
                                     join tcr in dbContext.TransactionConfirmResult.Where(t => t.Status == 0) on trs.TransactionConfirmResult.Id equals tcr.Id
                                     join cgw in dbContext.CommertialGateWays.Where(t => t.WalletId == wallet.Id) on trs.GateWayId equals cgw.Id
                                     select new
                                     {
                                         Amount = uwh.Amount,
                                     }).Sum(f => f.Amount);
                wallet.AmountInHand -= wallet.AmountWage;
                wallet.AmountSettlementable -= wallet.AmountWage;
            }
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddSettlement(int walletId, int bankAccountId, long amount)
        {
            var user = athenticationProvider.GetUser();

            dbContext.Settlements.Add(new Settlement
            {
                Amount = amount,
                BankAccountId = bankAccountId,
                UserId = user.Id,
                WalletId = walletId,
                QuickSettlement = false,
                SettlementStatusHistories = new List<SettlementStatusHistory> { new SettlementStatusHistory { Status = SettlementStatusHistory.SettlementStatus.InReview, UserId = user.Id } }
            });

            dbContext.Wallets.Where(f => f.Id == walletId).ToList().ForEach(f => { f.Amount -= amount; f.AmountInHand -= amount; f.AmountSettlementable -= amount; });
            await dbContext.SaveChangesAsync();

            return Redirect(Request.Headers["Referer"]);
        }
        [HttpPost]
        public async Task<IActionResult> AddQuickSettlement(int walletId, BankEnum bank, TransferTypeEnum transferType,
          BabatEnum babat, long amount, string CardNumber, string Iban, string sharh,string paymentID)
        {
            try
            {
                var user = athenticationProvider.GetUser();
                if ((CardNumber ?? "").Length == 0 && (Iban ?? "").Replace("IR", "").Length == 0)
                    return Json(new { status = "error", message = "شماره کارت یا شبا را وارد کنید" });
                if ((CardNumber ?? "").Length > 0 && (Iban ?? "").Replace("IR", "").Length > 0)
                    return Json(new { status = "error", message = "از بین شماره کارت یا شبا فقط یک مورد را وارد کنید" });

                bool isValidIban = false;
                bool isValidCardNumber = false;
                if ((Iban ?? "").Replace("IR", "").Length > 0)
                {
                    string ibanFormat = "^IR[0-9]{24}";
                    if (!Regex.IsMatch(Iban, ibanFormat))
                        return Json(new { status = "error", message = "شماره شبا معتبر نمی باشد" });
                    else
                        isValidIban = true;
                }
                else if (CardNumber != null && CardNumber.Length > 0)
                {
                    if (!(CardNumber.Trim().Length == 16 && CardNumber.Trim().All(char.IsDigit)))
                        return Json(new { status = "error", message = "شماره کارت معتبر نمی باشد" });
                    else
                        isValidCardNumber = true;
                }
                Framework.ShahinService.ShahinOperation.Models.GetTokenResult token = await shahinService.GetToken();
                var model = new AccountBalanceModel(token.bank, token.user_name, token.accounts[0]);
                AccountBalanceResultModel accountBalanceResult = await shahinService.GetAccountBalance(model, token.access_token, "");

                if (accountBalanceResult.respObject.availableBalance < amount)
                    return Json(new { status = "error", message = "موجودی حساب از مبلغ تسویه کمتر می باشد" });

                var data = await dbContext.Wallets.Where(f => f.UserId == user.Id).ToListAsync();
                var userWageType = dbContext.UserWageTypeHistories.Where(f => f.UserId == user.Id).FirstOrDefault();
                var AmountInTipoulSettlementable = data.FirstOrDefault().AmountInTipoul - (data.FirstOrDefault().AmountInTipoul * userWageType.QuickSettlementWagePercent);
                if (AmountInTipoulSettlementable < amount)
                    return Json(new { status = "error", message = string.Format("مبلغ تسویه ({0}) نمیتواند بیشتر از موجودی قابل برداشت ({1}) باشد", amount, AmountInTipoulSettlementable) });

                QuickSettlementResultModel confirmResult = new QuickSettlementResultModel();
                confirmResult.amount = amount;
                confirmResult.transferType = transferType;
                confirmResult.babat = babat;
                confirmResult.sharh = sharh;
                confirmResult.paymentID = paymentID;
                confirmResult.walletId = data.FirstOrDefault().Id;
                if (isValidIban)
                {
                    var ibanInfoModel = new IbanInfoModel(token.bank, token.user_name, Iban);
                    IbanInfoResultModel ibanInfoResult = await shahinService.GetIbanInfo(ibanInfoModel, token.access_token, "");
                    if (ibanInfoResult.respObject.errorCode != null)
                        return Json(new { status = "error", message = "خطای سرویس استعلام شبا =>" + ibanInfoResult.transactionState + ":" + ibanInfoResult.respObject.message });
                    confirmResult.bank = ibanInfoResult.respObject.bank.StringToEnum<BankEnum>();
                    confirmResult.ownerName = ibanInfoResult.respObject.firstName + " " + ibanInfoResult.respObject.lastName;
                    confirmResult.ibanNumber = ibanInfoResult.respObject.ibanNumber;
                    confirmResult.accountNumber = ibanInfoResult.respObject.accountNumber;
                    confirmResult.nationalCode = ibanInfoResult.respObject.nationalCode;
                }
                else if (isValidCardNumber)
                {
                    var cardInfoModel = new CardInfoModel(token.bank, token.user_name, token.accounts[0], CardNumber);
                    CardInfoResultModel cardInfoResult = await shahinService.GetCardInfo(cardInfoModel, token.access_token, "");
                    if (cardInfoResult.respObject.errorCode != null)
                        return Json(new { status = "error", message = "خطای سرویس استعلام کارت =>" + cardInfoResult.transactionState + ":" + cardInfoResult.respObject.message });
                    confirmResult.bank = cardInfoResult.respObject.bank.StringToEnum<BankEnum>();
                    confirmResult.ownerName = cardInfoResult.respObject.ownerName;
                    if (cardInfoResult.respObject.iban == null)
                        return Json(new { status = "error", message = string.Format("برای شماره کارت ({0}) با شماره حساب ({1}) شماره شبا یافت نشد لطفا به جای شماره کارت شماره شبا وارد کنید", CardNumber, cardInfoResult.respObject.accountNumber) });
                    else
                        confirmResult.ibanNumber = cardInfoResult.respObject.iban;
                    confirmResult.accountNumber = cardInfoResult.respObject.accountNumber;
                    confirmResult.cardNumber = CardNumber;
                }
                if (confirmResult.nationalCode == null || confirmResult.nationalCode.Length == 0)
                    confirmResult.nationalCode = "1111111111";

                confirmResult.time = DateTime.Now.Ticks.ToString();
                if (bank != confirmResult.bank)
                    return Json(new { status = "error", message = "بانک انتخابی با بانک حساب وارد شده مطابقت ندارد" });
                string key = "confirmResult-" + user.Id + "-" + confirmResult.time;
                HttpContext.Session.SetString(key, JsonSerializer.Serialize(confirmResult));
                return Json(new { status = "success", message = confirmResult });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", message = ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddQuickSettlementConfirm(string time)
        {
            try
            {
                var user = athenticationProvider.GetUser();
                string key = "confirmResult-" + user.Id + "-" + time;
                var json = HttpContext.Session.GetString(key);
                if (json == null)
                    return Json(new { status = "error", message = "درخواستی با مشخصات وارد شده ثبت نشده است" });

                QuickSettlementResultModel confirmResult = JsonSerializer.Deserialize<QuickSettlementResultModel>(json);
                var bank = dbContext.Banks.Where(f => f.Code == confirmResult.bank.ToString()).FirstOrDefault();
                if (bank == null)
                {
                    return Json(new { status = "error", message = string.Format("بانک ({0}) در سیستم تعریف نشده است", confirmResult.bank.ToDescription()) });
                }
                Framework.ShahinService.ShahinOperation.Models.GetTokenResult token = await shahinService.GetToken();
                string destinationAccountNumber = confirmResult.transferType == TransferTypeEnum.LOCAL ? confirmResult.accountNumber : confirmResult.ibanNumber;
                var model = new TransferModel(token.bank, token.user_name, token.accounts[0],
                    destinationAccountNumber, confirmResult.bank.ToString(), confirmResult.amount,
                    confirmResult.transferType, confirmResult.babat, confirmResult.paymentID, null, null,
                    confirmResult.sharh, confirmResult.sharh, "");

                TransferResultModel transferResult = await shahinService.Transfer(model, token.access_token, "");

                QuickSettlementResultFinishModel finishModel = new QuickSettlementResultFinishModel();
                if (transferResult.respObject.errorCode != null)
                {
                    if (transferResult.respObject.errorCode == "20000")
                        return Json(new { status = "error", message = "سرویس انتقال موقتا در دسترس نمی باشد" });
                    else
                        return Json(new { status = "error", message = "خطای سرویس انتقال :" + transferResult.respObject.errorCode + ":" + transferResult.respObject.message });
                }
                else
                {
                    var balanceModel = new AccountBalanceModel(token.bank, token.user_name, token.accounts[0]);
                    long AmountInBank = shahinService.GetAccountBalance(balanceModel, token.access_token, "").Result.respObject.availableBalance;

                    #region dbContext.BankAccounts
                    var bankAccount = dbContext.BankAccounts.Where(f => f.Iban == confirmResult.ibanNumber).FirstOrDefault();
                    if (bankAccount == null)
                    {
                        bankAccount = new BankAccount();
                        bankAccount.FullName = confirmResult.ownerName;
                        bankAccount.NationalCode = confirmResult.nationalCode;
                        bankAccount.BankId = bank.Id;
                        bankAccount.Iban = confirmResult.ibanNumber;
                        bankAccount.UserId = user.Id;
                        bankAccount.BirthDate = DateTime.MinValue;
                        bankAccount.IsActive = true;
                        dbContext.BankAccounts.Add(bankAccount);
                        dbContext.SaveChanges();
                    }
                    #endregion
                    var settlement = new Settlement();
                    var SettlementDocutmentPath = await SaveUploadedFileIfExists("SettlementDocutments", configuration);
                    if (!string.IsNullOrWhiteSpace(SettlementDocutmentPath))
                    {
                        settlement.DocutmentURL = SettlementDocutmentPath;
                    }
                    settlement.Amount = confirmResult.amount;
                    settlement.BankAccountId = bankAccount.Id;
                    settlement.UserId = user.Id;
                    settlement.WalletId = confirmResult.walletId;
                    settlement.QuickSettlement = true;
                    SettlementStatus settlementStatus = SettlementStatus.InReview;
                    var inquiryModel = new TransactionInquiryModel(token.bank, token.user_name, token.accounts[0], transferResult.uuid);
                    TransactionInquiryResultModel transactionInquiry =await shahinService.TransactionInquiry(inquiryModel, token.access_token, "");
                    if (transactionInquiry.respObject.transactionState == "SUCCESS")
                        settlementStatus = SettlementStatus.Done;

                    settlement.SettlementStatusHistories = new List<SettlementStatusHistory> { new SettlementStatusHistory { Status = settlementStatus, UserId = user.Id } };

                    settlement.RequestedUuid = transferResult.uuid;
                    settlement.AmountInBankAfterSettlement = AmountInBank;
                    settlement.OwnerName = confirmResult.ownerName;
                    settlement.AccountNumber = confirmResult.accountNumber;
                    settlement.IbanNumber = confirmResult.ibanNumber;
                    settlement.CardNumber = confirmResult.cardNumber;
                    settlement.NationalCode = confirmResult.nationalCode;
                    settlement.Babat = confirmResult.babat.ToString();
                    settlement.Sharh = confirmResult.sharh;
                    settlement.Bank = confirmResult.bank.ToString();
                    settlement.TransferType = confirmResult.transferType.ToString();
                    settlement.TraceNumber = transferResult.respObject.traceNumber;
                    settlement.PaymentID = confirmResult.paymentID;
                    dbContext.Settlements.Add(settlement);
                    await dbContext.SaveChangesAsync();

                    var userWageType = dbContext.UserWageTypeHistories.Where(f => f.UserId == user.Id).FirstOrDefault();
                    long amountWithWage = (long)Math.Ceiling(confirmResult.amount / (1 - userWageType.QuickSettlementWagePercent));
                    long wage = amountWithWage - confirmResult.amount;
                    dbContext.Wallets.Where(f => f.Id == confirmResult.walletId).ToList().ForEach(f => { f.AmountInTipoul -= amountWithWage; });
                    var wageHistory = new Framework.StorageModels.UserWageHistory
                    {
                        UserId = settlement.UserId,
                        UserWageTypeHistoryId = userWageType.Id,
                        SettlementId = settlement.Id,
                        Amount = wage,
                        CreateDate = DateTime.Now
                    };
                    dbContext.UserWageHistories.Add(wageHistory);
                    await dbContext.SaveChangesAsync();
                    long AmountInTipoul = dbContext.Wallets.Where(f => f.Id == confirmResult.walletId).FirstOrDefault().AmountInTipoul;
                    settlement.AmountInTipoulAfterSettlement = AmountInTipoul;
                    await dbContext.SaveChangesAsync();

                    finishModel.ownerName = confirmResult.ownerName;
                    finishModel.accountNumber = confirmResult.accountNumber;
                    finishModel.ibanNumber = confirmResult.ibanNumber;
                    finishModel.cardNumber = confirmResult.cardNumber;
                    finishModel.nationalCode = confirmResult.nationalCode;
                    finishModel.amount = confirmResult.amount;
                    finishModel.babat = confirmResult.babat.ToDescription();
                    finishModel.sharh = confirmResult.sharh;
                    finishModel.bank = confirmResult.bank.ToDescription();
                    finishModel.transferType = confirmResult.transferType.ToDescription();
                    finishModel.settlementCreateDate = DateConverter.ToShamsy(settlement.CreateDate, true);
                    finishModel.depositCreateDate = DateConverter.ToShamsy(settlement.CreateDate, true);
                    finishModel.amountInTipoulAfterSettlement = AmountInTipoul;
                    finishModel.TraceNumber = settlement.TraceNumber;
                    finishModel.PaymentID = settlement.PaymentID;

                    HttpContext.Session.Remove(key);
                    return Json(new { status = "success", message = finishModel });
                }
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", message = ex.Message });
            }
        }
        private async Task<string> SaveUploadedFileIfExists(string directory, [FromServices] IConfiguration configuration, IFormFile file = null)
        {
            if (file == null && (Request.Form.Files == null || Request.Form.Files.Count == 0))
                return null;

            file = file ?? Request.Form.Files[0];

            if (file.Length == 0)
                return null;

            var path = $"/{directory}/{DateTime.Now.ToFileTime()}/{file.FileName.Replace(" ", "-")}";

            var fileManagerPath = configuration["FileManagerPath"];

            CreateDirectory(new FileInfo(fileManagerPath + path).Directory);

            using (var stream = new FileStream(fileManagerPath + path, FileMode.Create))
                await file.CopyToAsync(stream);

            return path;

            void CreateDirectory(DirectoryInfo directoryInfo)
            {
                if (!directoryInfo.Exists)
                {
                    if (directoryInfo.Parent != null)
                        CreateDirectory(directoryInfo.Parent);

                    directoryInfo.Create();
                }
            }
        }
        public IActionResult GetSettlementModal(int walletId)
        {
            return PartialView(walletId);
        }
        public IActionResult GetQuickSettlementModal(int walletId)
        {
            return PartialView(walletId);
        }
    }
}
