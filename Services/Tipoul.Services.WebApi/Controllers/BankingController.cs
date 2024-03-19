using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Tipoul.Framework.DataAccessLayer;
using Tipoul.Framework.ShahinService.ShahinOperation;
using Tipoul.Framework.ShahinService.ShahinOperation.Enums;
using Tipoul.Framework.ShahinService.ShahinOperation.Models;
using Tipoul.Framework.ShahinService.StorageModels;
using Tipoul.Framework.StorageModels;
using Tipoul.Framework.Utilities.Converters;
using Tipoul.Framework.Utilities.Enums;
using Tipoul.Framework.Utilities.Extentions;
using Tipoul.Framework.Utilities.Utilities;
using Tipoul.Infrastructure.RequestLog.Services;
using Tipoul.Services.Shared.Models.Banking;
using Tipoul.Services.Shared.Models.Common;
using static Tipoul.Framework.StorageModels.SettlementStatusHistory;

namespace Tipoul.Services.WebApi.Controllers
{
    [Route("[controller]/v1")]
    public class BankingController : ControllerBase
    {
        private readonly TipoulFrameworkDbContext dbContext;
        private readonly ShahinService shahinService;
        private readonly RequestLogService requestLogService;
        private readonly ResponseUtilities responseUtilities;
        public BankingController(TipoulFrameworkDbContext dbContext, ShahinService shahinService,
            RequestLogService requestLogService, ResponseUtilities responseUtilities)
        {
            this.dbContext = dbContext;
            this.shahinService = shahinService;
            this.requestLogService = requestLogService;
            this.responseUtilities = responseUtilities;
        }

        public TipoulFrameworkDbContext GetDbContext()
        {
            return dbContext;
        }

        [HttpGet]
        [Route("/Banking/v2/transfer")]
        public async Task<ApiResult<BankingTransferResult>> transfer([FromServices] IConfiguration configuration, [FromBody] BankingTransferModel model, TipoulFrameworkDbContext dbContext)
        {
            try
            {
                var user = await dbContext.Users.FirstOrDefaultAsync(f => f.MobileNumber == model.Mobile
                        && f.Wallet.WalletCode == model.WalletCode && f.NationalCode == model.NationalCode && f.OBHAuthCode == model.OBHAuthCode);
                if (user == null || user.Id == 0)
                    throw new Exception("کاربری با مشخصات وارد شده یافت نشد");
                var bank = dbContext.Banks.Where(f => f.Code == model.DestBank.ToString()).FirstOrDefault();
                if (bank == null)
                    throw new Exception(string.Format("بانک ({0}) در سیستم تعریف نشده است", model.DestBank));
                if (model.Amount <= 0)
                    throw new Exception("مبلغ تسویه را وارد کنید");
                if (model.DestOwnerName == null || model.DestOwnerName.Length == 0)
                    throw new Exception("صاحب حساب شماره شبای مقصد را وارد کنید");
                try
                {
                    if (model.TransferType == null || model.TransferType.StringToEnum<TransferTypeEnum>().ToDescription().Length == 0)
                        throw new Exception("نوع تسویه را وارد کنید");
                }
                catch (Exception)
                {
                    throw new Exception("نوع تسویه اشتباه می باشد");
                }
                try
                {
                    if (model.Babat == null || model.Babat.StringToEnum<BabatEnum>().ToDescription().Length == 0)
                        throw new Exception("بابت را وارد کنید");
                }
                catch (Exception)
                {
                    throw new Exception("بابت اشتباه می باشد");
                }
                if (model.Sharh == null || model.Sharh.Length == 0)
                    throw new Exception("شرح تسویه را وارد کنید");
                DateTime DestBirthDate = DateTime.MinValue;
                if (model.DestBirthDate == null || model.DestBirthDate.Length == 0)
                    DestBirthDate = DateTime.Now;
                else if (model.DestBirthDate != null && model.DestBirthDate.Length == 10)
                    throw new Exception("فرمت تاریخ تولد صحیح نمی باشد");
                else
                {
                    try
                    {
                        DestBirthDate = DateConverter.ToGerigorian(model.DestBirthDate);
                    }
                    catch (Exception)
                    {
                        throw new Exception("فرمت تاریخ تولد صحیح نمی باشد");
                    }
                }
                bool isValidCardNumber = false;
                if ((model.DestIban ?? "").Replace("IR", "").Length > 0)
                {
                    string ibanFormat = "^IR[0-9]{24}";
                    if (!Regex.IsMatch(model.DestIban, ibanFormat))
                        throw new Exception(string.Format("شماره شبا معتبر نمی باشد", model.DestBank));
                }
                else
                    throw new Exception(string.Format("شماره شبای مقصد را وارد کنید", model.DestBank));

                Framework.ShahinService.ShahinOperation.Models.GetTokenResult token = await shahinService.GetToken();
                var accountBalance = new AccountBalanceModel(token.bank, token.user_name, token.accounts[0]);
                AccountBalanceResultModel accountBalanceResult = await shahinService.GetAccountBalance(accountBalance, token.access_token, "");
                if (accountBalanceResult.respObject.availableBalance < model.Amount)
                    throw new Exception(string.Format("موجودی حساب از مبلغ تسویه کمتر می باشد", model.DestBank));

                var data = await dbContext.Wallets.Where(f => f.UserId == user.Id).ToListAsync();
                var userWageType = dbContext.UserWageTypeHistories.Where(f => f.UserId == user.Id).FirstOrDefault();
                var AmountInTipoulSettlementable = data.FirstOrDefault().AmountInTipoul - (data.FirstOrDefault().AmountInTipoul * userWageType.QuickSettlementWagePercent);
                if (AmountInTipoulSettlementable < model.Amount)
                    throw new Exception(string.Format("مبلغ تسویه ({0}) نمیتواند بیشتر از موجودی قابل برداشت ({1}) باشد", model.Amount, AmountInTipoulSettlementable));

                var destIbanInfoModel = new Framework.ShahinService.ShahinOperation.Models.IbanInfoModel(token.bank, token.user_name, model.DestIban);

                Framework.ShahinService.ShahinOperation.Models.IbanInfoResultModel ibanInfoResult = await shahinService.GetIbanInfo(destIbanInfoModel, token.access_token, "");


                if (ibanInfoResult.respObject.errorCode != null)
                    throw new Exception("خطای سرویس استعلام شبا =>" + ibanInfoResult.transactionState + ":" + ibanInfoResult.respObject.message);
                else if (ibanInfoResult.respObject.firstName + " " + ibanInfoResult.respObject.lastName != model.DestOwnerName)
                    throw new Exception("صاحب حساب شماره شبای مقصد وارد شده با اطلاعات استعلام شده همخوانی ندارد");
                #region dbContext.BankAccounts
                var bankAccount = dbContext.BankAccounts.Where(f => f.Iban == model.DestIban).FirstOrDefault();
                if (bankAccount == null)
                {
                    bankAccount = new Tipoul.Framework.StorageModels.BankAccount();
                    bankAccount.FullName = ibanInfoResult.respObject.firstName + " " + ibanInfoResult.respObject.lastName;
                    bankAccount.NationalCode = ibanInfoResult.respObject.nationalCode;
                    bankAccount.BankId = bank.Id;
                    bankAccount.Iban = ibanInfoResult.respObject.ibanNumber;
                    bankAccount.UserId = user.Id;
                    bankAccount.BirthDate = DestBirthDate;
                    bankAccount.IsActive = true;
                    dbContext.BankAccounts.Add(bankAccount);
                    dbContext.SaveChanges();
                }
                #endregion

                string destinationAccountNumber = model.TransferType.StringToEnum<TransferTypeEnum>() == TransferTypeEnum.LOCAL ? ibanInfoResult.respObject.accountNumber : model.DestIban;
                var transferModel = new Framework.ShahinService.ShahinOperation.Models.TransferModel(token.bank, token.user_name, token.accounts[0],
                    destinationAccountNumber, model.DestBank.ToString(), model.Amount,
                    model.TransferType.StringToEnum<TransferTypeEnum>(), model.Babat.StringToEnum<BabatEnum>(), model.PaymentID, null, null,
                    model.Sharh, model.Sharh, "");
                Framework.ShahinService.ShahinOperation.Models.TransferResultModel transferResult = await shahinService.Transfer(transferModel, token.access_token, "");

                if (transferResult.respObject.errorCode != null)
                {
                    if (transferResult.respObject.errorCode == "20000")
                        throw new Exception("سرویس انتقال موقتا در دسترس نمی باشد");
                    else
                        throw new Exception("خطای سرویس انتقال :" + transferResult.respObject.errorCode + ":" + transferResult.respObject.message);
                }
                else
                {
                    var balanceModel = new Framework.ShahinService.ShahinOperation.Models.AccountBalanceModel(token.bank, token.user_name, token.accounts[0]);
                    long AmountInBank = shahinService.GetAccountBalance(balanceModel, token.access_token, "").Result.respObject.availableBalance;

                    int walletId = dbContext.Wallets.Where(f => f.WalletCode == model.WalletCode).FirstOrDefault().Id;
                    var settlement = new Framework.StorageModels.Settlement();
                    settlement.Amount = model.Amount;
                    settlement.BankAccountId = bankAccount.Id;
                    settlement.UserId = user.Id;
                    settlement.WalletId = walletId;
                    settlement.QuickSettlement = true;
                    SettlementStatus settlementStatus = SettlementStatus.InReview;
                    var inquiryModel = new Framework.ShahinService.ShahinOperation.Models.TransactionInquiryModel(token.bank, token.user_name, token.accounts[0], transferResult.uuid);
                    var transactionState = shahinService.TransactionInquiry(inquiryModel, token.access_token, "").Result.respObject.transactionState;
                    if (transactionState == "SUCCESS")
                        settlementStatus = SettlementStatus.Done;

                    settlement.SettlementStatusHistories = new List<SettlementStatusHistory> { new SettlementStatusHistory { Status = settlementStatus, UserId = user.Id } };

                    settlement.RequestedUuid = transferResult.uuid;
                    settlement.AmountInBankAfterSettlement = AmountInBank;
                    settlement.OwnerName = ibanInfoResult.respObject.firstName + " " + ibanInfoResult.respObject.lastName;
                    settlement.AccountNumber = ibanInfoResult.respObject.accountNumber;
                    settlement.IbanNumber = model.DestIban;
                    if (ibanInfoResult.respObject.nationalCode == null || ibanInfoResult.respObject.nationalCode.Length == 0)
                        settlement.NationalCode = "1111111111";
                    else
                        settlement.NationalCode = ibanInfoResult.respObject.nationalCode;
                    settlement.Babat = model.Babat.ToString();
                    settlement.Sharh = model.Sharh;
                    settlement.Bank = model.DestBank.ToString();
                    settlement.TransferType = model.TransferType.ToString();
                    settlement.TraceNumber = transferResult.respObject.traceNumber;
                    settlement.PaymentID = model.PaymentID;
                    dbContext.Settlements.Add(settlement);
                    await dbContext.SaveChangesAsync();

                    long amountWithWage = (long)Math.Ceiling(model.Amount / (1 - userWageType.QuickSettlementWagePercent));
                    long wage = amountWithWage - model.Amount;
                    dbContext.Wallets.Where(f => f.Id == walletId).ToList().ForEach(f => { f.AmountInTipoul -= amountWithWage; });
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
                    settlement.AmountInTipoulAfterSettlement = dbContext.Wallets.Where(f => f.Id == walletId).FirstOrDefault().AmountInTipoul;
                    await dbContext.SaveChangesAsync();

                    BankingTransferResult transfer = new BankingTransferResult();
                    transfer.OwnerName = settlement.OwnerName;
                    transfer.AccountNumber = settlement.AccountNumber;
                    transfer.IbanNumber = settlement.IbanNumber;
                    transfer.CardNumber = settlement.CardNumber;
                    transfer.NationalCode = settlement.NationalCode;
                    transfer.Amount = settlement.Amount;
                    transfer.Babat = settlement.Babat.StringToEnum<BabatEnum>().ToDescription();
                    transfer.Sharh = settlement.Sharh;
                    transfer.Bank = settlement.Bank.StringToEnum<BankEnum>().ToDescription();
                    transfer.TransferType = settlement.TransferType.StringToEnum<TransferTypeEnum>().ToDescription();
                    transfer.SettlementCreateDate = DateConverter.ToShamsy(settlement.CreateDate, true);
                    transfer.DepositCreateDate = DateConverter.ToShamsy(settlement.CreateDate, true);
                    transfer.AmountInTipoulAfterSettlement = settlement.AmountInTipoulAfterSettlement;
                    transfer.TraceNumber = settlement.TraceNumber;

                    return new ApiResult<BankingTransferResult>(transfer);
                }
            }
            catch (Exception ex)
            {
                return new ApiResult<BankingTransferResult>(ex, -1);
            }
        }

    }
}