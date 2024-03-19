using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Tipoul.Athentication.Agent.Services;
using Tipoul.Framework.DataAccessLayer;
using Tipoul.Framework.StorageModels;
using Tipoul.Framework.Utilities.Extentions;
using static Tipoul.Framework.StorageModels.SettlementStatusHistory;
using Tipoul.Framework.Utilities.Converters;
using Tipoul.AdminPanel.WebUI.Models.Settlements;
using Tipoul.Framework.Utilities.Utilities;
using Tipoul.Framework.Utilities.Enums;
using Org.BouncyCastle.Bcpg;
using ICSharpCode.SharpZipLib.Zip;
using static Tipoul.Framework.StorageModels.WalletDepositRequestStatusHistory;
using Tipoul.Framework.ShahinService.ShahinOperation;
using Tipoul.Framework.ShahinService.ShahinOperation.Models;
using System.Collections.Generic;
using Tipoul.Athentication.Agent.Models;
using Tipoul.Framework.DataAccessLayer.Migrations;
using NPOI.POIFS.Crypt.Dsig;
using Tipoul.Framework.ShahinService.ShahinOperation.Enums;

namespace Tipoul.UserPanel.WebUI.Controllers
{
    public class SettlementController : Controller
    {
        private readonly TipoulFrameworkDbContext dbContext;
        private readonly ShahinService shahinService;
        private readonly AthenticationProvider athenticationProvider;
        public SettlementController(TipoulFrameworkDbContext dbContext, ShahinService shahinService, AthenticationProvider athenticationProvider)
        {
            this.dbContext = dbContext;
            this.shahinService = shahinService;
            this.athenticationProvider = athenticationProvider;
        }
        public async Task<IActionResult> Settlements(int? minAmount, int? maxAmount, int? bankAccountId, int? walletId, int pageNumber = 1, int pageSize = 10)
        {
            var user = athenticationProvider.GetUser();

            var query = dbContext.Settlements.Where(f => f.UserId > 0);

            if (minAmount.HasValue)
                query = query.Where(f => f.Amount >= minAmount.Value);

            if (maxAmount.HasValue)
                query = query.Where(f => f.Amount <= maxAmount.Value);

            if (walletId.HasValue)
                query = query.Where(f => f.WalletId == walletId.Value);
            var data = await query.OrderByDescending(f => f.CreateDate).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(f => new
            {
                f.Amount,
                f.QuickSettlement,
                f.AmountInTipoulAfterSettlement,
                f.AmountInBankAfterSettlement,
                f.CreateDate,
                f.SelectedDate,
                LastStatus = f.SettlementStatusHistories.OrderByDescending(x => x.CreateDate).Select(x => x.Status).FirstOrDefault().ToDescription(),
                SettlementStatusHistories = f.SettlementStatusHistories,
                f.Id,
                UserFullName = f.User.FirstName + " " + f.User.LastName,
                DestIban = f.BankAccount.Iban,
                WalletTitle = f.Wallet.Title,
                RequestedUuid = f.RequestedUuid
            }).ToListAsync();

            var totalCount = query.Count();
            var viewModel = new SettlementsListViewModel
            {
                SelectedMaxAmount = maxAmount,
                SelectedMinAmount = minAmount,
                MinAmount = query.Any() ? query.Min(f => f.Amount) : 0,
                MaxAmount = query.Any() ? query.Max(f => f.Amount) : 0,
                PageNumber = pageNumber,
                PagesCount = totalCount / pageSize + (totalCount % pageSize == 0 ? 0 : 1),
                PageSize = pageSize,
                TotalCount = totalCount,

                WalletId = walletId,
                Items = data.ConvertAll(f => new SettlementsListItemViewModel
                {
                    Amount = f.Amount,
                    QuickSettlement = f.QuickSettlement,
                    AmountInTipoulAfterSettlement = f.AmountInTipoulAfterSettlement,
                    AmountInBankAfterSettlement = f.AmountInBankAfterSettlement,
                    CreateDate = DateConverter.ToShamsy(f.CreateDate, true),
                    SelectedDate = DateConverter.ToShamsy(f.SelectedDate, true),
                    UserFullName = f.UserFullName,
                    DestIban = f.DestIban,
                    Id = f.Id,
                    LastStatus = f.LastStatus,
                    Wallet = f.WalletTitle,
                    RequestedUuid = f.RequestedUuid,
                })
            };

            return View(viewModel);
        }
        public async Task<IActionResult> GetSettlement(int SettlementId)
        {
            try
            {
                var f = await dbContext.Settlements.Where(f => f.Id == SettlementId).Select(f => new
                {
                    f.Amount,
                    UserWageHistories = dbContext.UserWageHistories.Where(w => w.SettlementId == SettlementId).ToList(),
                    WalletTitle = f.Wallet.Title,
                    LastStatus = f.SettlementStatusHistories.OrderByDescending(x => x.CreateDate).Select(x => x.Status).FirstOrDefault().ToDescription(),
                    f.QuickSettlement,
                    RequestedUuid = f.RequestedUuid,
                    f.CreateDate,
                    f.SelectedDate,
                    f.Id,
                    UserFullName = f.User.FirstName + " " + f.User.LastName,
                    f.AmountInTipoulAfterSettlement,
                    f.AmountInBankAfterSettlement,
                    BankAccount = f.BankAccount.FullName,
                    DestIban = f.BankAccount.Iban,
                    OwnerName = f.OwnerName,
                    AccountNumber = f.AccountNumber,
                    CardNumber = f.CardNumber,
                    NationalCode = f.NationalCode,
                    Babat = f.Babat,
                    Bank = f.Bank,
                    Sharh = f.Sharh,
                }).FirstOrDefaultAsync();
                var model = new SettlementsListItemViewModel();
                if (f != null && f.Id > 0)
                {
                    model.Amount = f.Amount;
                    model.Wage = f.UserWageHistories.Sum(w => w.Amount);
                    model.Wallet = f.WalletTitle;
                    model.LastStatus = f.LastStatus;
                    model.QuickSettlement = f.QuickSettlement;
                    model.RequestedUuid = f.RequestedUuid;
                    model.CreateDate = DateConverter.ToShamsy(f.CreateDate, true);
                    model.SelectedDate = DateConverter.ToShamsy(f.SelectedDate, true);
                    model.UserFullName = f.UserFullName;
                    model.AmountInTipoulAfterSettlement = f.AmountInTipoulAfterSettlement;
                    model.AmountInBankAfterSettlement = f.AmountInBankAfterSettlement;
                    model.BankAccount = f.BankAccount;
                    model.DestIban = f.DestIban;
                    model.OwnerName = f.OwnerName;
                    model.AccountNumber = f.AccountNumber;
                    model.CardNumber = f.CardNumber;
                    model.NationalCode = f.NationalCode;
                    if (f.Babat!=null && f.Babat.Length > 0)
                        try { model.Babat = f.Babat.StringToEnum<BabatEnum>().ToDescription(); } catch (Exception ex) { };
                    if (f.Bank != null && f.Bank.Length > 0)
                    try { model.DestnitionBank = f.Bank.StringToEnum<BankEnum>().ToDescription(); } catch (Exception ex) { };
                    model.Sharh = f.Sharh;
                    model.Id = f.Id;
                };
                return Json(new { status = "success", message = model });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", message = ex.Message });
            }
        }

        public async Task<IActionResult> ChangeSettlementStatus(int SettlementId, SettlementStatus status)
        {
            try
            {
                var user = athenticationProvider.GetUser();
                var settlement = dbContext.Settlements.Where(f => f.Id == SettlementId).Select(f => new
                {
                    f.Amount,
                    f.QuickSettlement,
                    f.AmountInTipoulAfterSettlement,
                    f.AmountInBankAfterSettlement,
                    f.CreateDate,
                    f.SelectedDate,
                    LastStatus = f.SettlementStatusHistories.OrderByDescending(x => x.CreateDate).Select(x => x.Status).FirstOrDefault(),
                    SettlementStatusHistories = f.SettlementStatusHistories,
                    f.Id,
                    UserFullName = f.User.FirstName + " " + f.User.LastName,
                    DestIban = f.BankAccount.Iban,
                    WalletTitle = f.Wallet.Title,
                    RequestedUuid = f.RequestedUuid,
                    WalletId = f.WalletId
                }).FirstOrDefault();
                if (settlement == null)
                    return Json(new { status = "error", message = "تسویه ای با مشخصات وارد شده یافت نشد" });
                else
                {
                    var LastStatus = settlement.LastStatus;
                    if (LastStatus == SettlementStatus.Done || LastStatus == SettlementStatus.Rejected)
                        return Json(new { status = "error", message = "تسویه بررسی شده و امکان بررسی مجدد وجود ندارد" });
                    var history = new SettlementStatusHistory();
                    history.UserId = user.Id;
                    history.UserId = user.Id;
                    history.Status = status;
                    history.CreateDate = DateTime.Now;
                    dbContext.Settlements.Where(f => f.Id == SettlementId).ToList().ForEach(f => f.SettlementStatusHistories.Add(history));

                    if (status == SettlementStatus.Rejected)
                    {
                        if (settlement.QuickSettlement)
                            dbContext.Wallets.Where(f => f.Id == settlement.WalletId).ToList().ForEach(f => { f.AmountInTipoul -= settlement.Amount; });
                        else
                            dbContext.Wallets.Where(f => f.Id == settlement.WalletId).ToList().ForEach(f => { f.Amount -= settlement.Amount; f.AmountInHand -= settlement.Amount; f.AmountSettlementable -= settlement.Amount; });

                        dbContext.UserWageHistories.Where(f => f.SettlementId == SettlementId).ToList().ForEach(f =>
                        {
                            dbContext.UserWageHistories.Remove(f);
                        });
                    }
                    dbContext.SaveChanges();
                };
                return Json(new { status = "success", message = true });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", message = ex.Message });
            }
        }
        public async Task<IActionResult> GetAccountStatement(string fromDate, string fromTime, string toDate, string toTime)
        {
            try
            {
                var user = athenticationProvider.GetUser();
                Framework.ShahinService.ShahinOperation.Models.GetTokenResult token = await shahinService.GetToken();
                var model = new AccountStatementModel(token.bank, token.user_name, token.accounts[0], fromDate, fromTime, toDate, toTime);
                AccountStatementResultModel accountStatement = await shahinService.GetAccountStatement(model, token.access_token, "");
                var result = new List<AccountStatementListViewModel>();
                foreach (var item in accountStatement.respObject.accountStatementList)
                {
                    AccountStatementListViewModel accountStatementList = new AccountStatementListViewModel();
                    accountStatementList.transactionDate = item.transactionDate;
                    accountStatementList.transactionTime = item.transactionTime;
                    accountStatementList.debit = item.debit;
                    accountStatementList.credit = item.credit;
                    accountStatementList.description = item.description;
                    accountStatementList.balance = item.balance;
                    accountStatementList.transactionTrace = item.transactionTrace;
                    accountStatementList.branchCode = item.branchCode;
                    accountStatementList.transactionIdentity = item.transactionIdentity;
                    accountStatementList.statementStatus = item.statementStatus;
                    accountStatementList.sourceAccount = item.sourceAccount;
                    accountStatementList.destinationAccount = item.destinationAccount;
                    result.Add(accountStatementList);
                }
                return Json(new { status = "success", message = result });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", message = ex.Message });
            }
        }
        public async Task<IActionResult> TransactionInquiry(string RequestedUuid)
        {
            try
            {
                var user = athenticationProvider.GetUser();
                if (RequestedUuid==null || RequestedUuid.Length==0)
                    return Json(new { status = "error", message = "کد درخواست معتبر نمی باشد و امکان استعلام وجود ندارد" });

                var settlement = await dbContext.Settlements.Where(f => f.RequestedUuid == RequestedUuid).Select(f => new
                {
                    LastStatus = f.SettlementStatusHistories.OrderByDescending(x => x.CreateDate).Select(x => x.Status).FirstOrDefault(),
                }).FirstOrDefaultAsync(); ;
                var LastStatus = settlement.LastStatus;
                if (LastStatus == SettlementStatus.Done || LastStatus == SettlementStatus.Rejected)
                    return Json(new { status = "error", message = "تسویه تعیین وضعیت شده و امکان استعلام وجود ندارد" });

                Framework.ShahinService.ShahinOperation.Models.GetTokenResult token = await shahinService.GetToken();
                var model = new TransactionInquiryModel(token.bank, token.user_name, token.accounts[0], RequestedUuid);
                TransactionInquiryResultModel accountStatement = await shahinService.TransactionInquiry(model, token.access_token, "");
                if (accountStatement != null && accountStatement.respObject.transactionState == "SUCCESS")
                {
                    var history = new SettlementStatusHistory();
                    history.UserId = user.Id;
                    history.Status = SettlementStatus.Done;
                    history.CreateDate = DateTime.Now;
                    dbContext.Settlements.Where(f => f.RequestedUuid == RequestedUuid).ToList().ForEach(f => f.SettlementStatusHistories.Add(history));
                    dbContext.SaveChanges();
                    return Json(new { status = "success", message = true });
                }
                else
                    return Json(new { status = "error", message = "وضعیت تراکنش :" + accountStatement.respObject.transactionState });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", message = ex.Message });
            }
        }
    }
}
