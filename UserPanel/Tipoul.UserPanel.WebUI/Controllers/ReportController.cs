using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Tipoul.Athentication.Agent.Services;
using Tipoul.Framework.DataAccessLayer;
using Tipoul.Framework.ShahinService.ShahinOperation.Enums;
using Tipoul.Framework.ShahinService.ShahinOperation.Models;
using Tipoul.Framework.ShahinService.ShahinOperation;
using Tipoul.Framework.StorageModels;
using Tipoul.UserPanel.WebUI.Models.Report.Customers;
using Tipoul.UserPanel.WebUI.Models.Report.Settlements;
using Tipoul.UserPanel.WebUI.Models.Report.Transactions;
using Tipoul.UserPanel.WebUI.Models.Report.WalletDepositRequests;
using Tipoul.Framework.Utilities.Converters;
using Tipoul.Framework.Utilities.Utilities;
using Tipoul.Framework.Utilities.Enums;
using Tipoul.Framework.Utilities.Extentions;
using Tipoul.Framework.DataAccessLayer.Migrations;
using static Tipoul.Framework.StorageModels.SettlementStatusHistory;

namespace Tipoul.UserPanel.WebUI.Controllers
{
    public class ReportController : Controller
    {
        private readonly TipoulFrameworkDbContext dbContext;
        private readonly ShahinService shahinService;

        private readonly AthenticationProvider athenticationProvider;

        public ReportController(TipoulFrameworkDbContext dbContext, AthenticationProvider athenticationProvider, ShahinService shahinService)
        {
            this.dbContext = dbContext;
            this.athenticationProvider = athenticationProvider;
            this.shahinService = shahinService;
        }

        public IActionResult Transactions(int? gatewayId, int? walletId, string customerKey, string keyword, int? wageHistoryId, bool? success, int pageNumber = 1, int pageSize = 10,
            string PayDateFrom_Year = "", string PayDateFrom_Month = "", string PayDateFrom_Day = "", string PayDateFrom_Hour = "", string PayDateFrom_Min = "",
             string PayDateTo_Year = "", string PayDateTo_Month = "", string PayDateTo_Day = "", string PayDateTo_Hour = "", string PayDateTo_Min = ""
            )
        {
            string strDateFrom = "";
            string strDateTo = "";
            string strTimeFrom = "";
            string strTimeTo = "";
            if (!string.IsNullOrEmpty(PayDateFrom_Year))
            {
                strDateFrom = $"{PayDateFrom_Year}-{PayDateFrom_Month ?? "01"}-{PayDateFrom_Day ?? "01"}";
            }

            if (!string.IsNullOrEmpty(PayDateTo_Year))
            {
                strDateTo = $"{PayDateTo_Year}-{PayDateTo_Month ?? "01"}-{PayDateTo_Day ?? "01"}";
            }
            if (!string.IsNullOrEmpty(PayDateFrom_Hour))
            {
                strTimeFrom = $"{PayDateFrom_Hour ?? "00"}:{PayDateFrom_Min ?? "00"}:00";
            }
            if (!string.IsNullOrEmpty(PayDateTo_Hour))
            {
                strTimeTo = $"{PayDateTo_Hour ?? "23"}:{PayDateTo_Min ?? "59"}:59";
            }
            var user = athenticationProvider.GetUser();

            var query = dbContext.Transactions.Where(f => f.ISPAccessToken != null).Where(f => f.GateWay.Wallet.UserId == user.Id);

            if (gatewayId.HasValue)
                query = query.Where(f => f.GateWayId == gatewayId.Value);

            if (walletId.HasValue)
                query = query.Where(f => f.GateWay.WalletId == walletId.Value);

            if (wageHistoryId.HasValue)
                query = query.Where(f => f.UserWageHistoryId.HasValue && f.UserWageHistoryId.Value == wageHistoryId.Value);


            if (!string.IsNullOrWhiteSpace(strDateFrom))
                query = query.Where(f => f.TransactionResponse != null && f.TransactionResponse.DatePaid.CompareTo(strDateFrom) >= 0);
            if (!string.IsNullOrWhiteSpace(strDateTo))
                query = query.Where(f => f.TransactionResponse != null && f.TransactionResponse.DatePaid.CompareTo(strDateTo) <= 0);

            if (!string.IsNullOrWhiteSpace(strTimeFrom))
                query = query.Where(f => f.TransactionResponse != null && f.TransactionResponse.DatePaid.Substring(11, 8).CompareTo(strTimeFrom) >= 0);
            if (!string.IsNullOrWhiteSpace(strTimeTo))
                query = query.Where(f => f.TransactionResponse != null && f.TransactionResponse.DatePaid.Substring(11, 8).CompareTo(strTimeTo) <= 0);


            if (!string.IsNullOrWhiteSpace(keyword))
                query = query.Where(f =>
                    f.InvoiceId.Contains(keyword)
                        ||
                    (f.TransactionResponse != null && (f.TransactionResponse.CardNumber.Contains(keyword) || f.TransactionResponse.Payload.Contains(keyword) || f.TransactionResponse.TraceNumber.ToString().Contains(keyword)))
                        ||
                    (f.GetTokenModel != null && (f.GetTokenModel.Description.Contains(keyword) || f.GetTokenModel.FactorNumber.Contains(keyword) || f.GetTokenModel.IPG.Contains(keyword)))
                        ||
                    (f.GetTokenModel != null && (f.GetTokenModel.PayerMail.Contains(keyword) || f.GetTokenModel.PayerMobile.Contains(keyword) || f.GetTokenModel.PayerName.Contains(keyword))));

            if (!string.IsNullOrWhiteSpace(customerKey))
                query = query.Where(f => dbContext.Transactions.Where(x => x.GateWay.Wallet.UserId == user.Id).Where(x => x.GetTokenModel.PayerUserId + x.GetTokenModel.PayerName + x.GetTokenModel.PayerMobile == customerKey).Any(x => x.Id == f.Id));

            if (success.HasValue)
                query = query.Where(f => (f.TransactionConfirmResult != null && f.TransactionConfirmResult.Status != TransactionConfirmResult.ConfirmStatus.NOK) == success.Value);

            var data = query.OrderByDescending(f => f.CreateDate).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(f => new
            {
                f.Id,
                f.GetTokenModel.Amount,
                GateWayTitle = f.GateWay.Title,
                f.GetTokenModel.PayerName,
                f.TransactionResponse.DatePaid,
                f.CreateDate,
                Success = f.TransactionConfirmResult != null && f.TransactionConfirmResult.Status != Framework.StorageModels.TransactionConfirmResult.ConfirmStatus.NOK
            }).ToList();

            var totalCount = query.Count();

            var viewModel = new TransactionsListViewModel
            {
                GateWayId = gatewayId,
                WalletId = walletId,
                Keyword = keyword,
                CustomerKey = customerKey,
                PageNumber = pageNumber,
                PageSize = pageSize,
                Success = success,
                PagesCount = totalCount / pageSize + (totalCount % pageSize == 0 ? 0 : 1),
                TotalCount = totalCount,
                TotalAmount = query.Where(f => f.TransactionConfirmResult != null && f.TransactionConfirmResult.Status != Framework.StorageModels.TransactionConfirmResult.ConfirmStatus.NOK).Sum(f => f.GetTokenModel.Amount),
                TotalPageAmount = data.Where(f => f.Success).Sum(f => f.Amount),
                PayDateFrom_Year = PayDateFrom_Year,
                PayDateFrom_Month = PayDateFrom_Month,
                PayDateFrom_Day = PayDateFrom_Day,
                PayDateFrom_Hour = PayDateFrom_Hour,
                PayDateFrom_Min = PayDateFrom_Min,
                PayDateTo_Year = PayDateTo_Year,
                PayDateTo_Month = PayDateTo_Month,
                PayDateTo_Day = PayDateTo_Day,
                PayDateTo_Hour = PayDateTo_Hour,
                PayDateTo_Min = PayDateTo_Min,
                Items = data.ConvertAll(f => new TransactionsListItemViewModel
                {
                    Id = f.Id,
                    Amount = f.Amount,
                    CreateDate = f.CreateDate,
                    GateWayTitle = f.GateWayTitle,
                    PayerName = f.PayerName,
                    PayDate = f.DatePaid,
                    Success = f.Success
                })
            };

            return View(viewModel);
        }

        public IActionResult TransactionModal(int id)
        {
            var viewModel = dbContext.Transactions
                .Include(f => f.GateWay)
                .Include(f => f.GetTokenModel)
                .Include(f => f.GetTokenResult)
                .Include(f => f.TransactionResponse)
                .Include(f => f.TransactionConfirmResult)
                .FirstOrDefault(f => f.Id == id);

            return PartialView(viewModel);
        }

        public async Task<IActionResult> SaveDescription(int id, string description)
        {
            try
            {
                var transaction = await dbContext.Transactions.Where(f => f.Id == id).FirstOrDefaultAsync();

                if (transaction != null)
                {
                    transaction.Description = description;

                    await dbContext.SaveChangesAsync();
                }

                return Json(new
                {
                    Success = transaction != null
                });
            }
            catch (Exception exception)
            {
                return Json(new
                {
                    Success = false,
                    ErrorMessage = exception.Message
                });
            }
        }

        public IActionResult Customers(int? gatewayId, int? walletId, string keyword, int pageNumber = 1, int pageSize = 10)
        {
            var user = athenticationProvider.GetUser();

            var query = dbContext.Transactions.Where(f => f.GateWay.Wallet.UserId == user.Id);

            if (gatewayId.HasValue)
                query = query.Where(f => f.GateWayId == gatewayId.Value);

            if (walletId.HasValue)
                query = query.Where(f => f.GateWay.WalletId == walletId.Value);

            if (!string.IsNullOrWhiteSpace(keyword))
                query = query.Where(f =>
                    f.InvoiceId.Contains(keyword)
                        ||
                    (f.TransactionResponse != null && (f.TransactionResponse.CardNumber.Contains(keyword) || f.TransactionResponse.Payload.Contains(keyword) || f.TransactionResponse.TraceNumber.ToString().Contains(keyword)))
                        ||
                    (f.GetTokenModel != null && (f.GetTokenModel.Description.Contains(keyword) || f.GetTokenModel.FactorNumber.Contains(keyword) || f.GetTokenModel.IPG.Contains(keyword)))
                        ||
                    (f.GetTokenModel != null && (f.GetTokenModel.PayerMail.Contains(keyword) || f.GetTokenModel.PayerMobile.Contains(keyword) || f.GetTokenModel.PayerName.Contains(keyword))));

            var subQuery = query
                .OrderByDescending(f => f.CreateDate)
                .Include(f => f.GetTokenModel)
                .Include(f => f.GateWay)
                .Include(f => f.TransactionResponse)
                .Include(f => f.TransactionConfirmResult)
                .ToList()
                .GroupBy(f => new { f.GetTokenModel.PayerMobile, f.GetTokenModel.PayerName, f.GetTokenModel.PayerUserId });

            var totalCount = subQuery.Count();

            var data = subQuery.Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(f => new
            {
                f.Key,
                TotalTransactions = f.Count(),
                PayerMobile = f.Key,
                Amount = f.Where(x => x.TransactionConfirmResult != null && x.TransactionConfirmResult.Status != Framework.StorageModels.TransactionConfirmResult.ConfirmStatus.NOK).Sum(x => x.GetTokenModel.Amount),
                SuccessTransactions = f.Where(x => x.TransactionConfirmResult != null && x.TransactionConfirmResult.Status != Framework.StorageModels.TransactionConfirmResult.ConfirmStatus.NOK).Count(),
                Payer = f.Select(x => new
                {
                    x.GetTokenModel.PayerName,
                    x.GetTokenModel.PayerMail
                }).ToList(),
                DateInfo = new
                {
                    FirstRequest = f.Min(x => x.CreateDate),
                    LastRequest = f.Max(x => x.CreateDate)
                }
            }).ToList();

            var viewModel = new CustomersListViewModel
            {
                GateWayId = gatewayId,
                WalletId = walletId,
                Keyword = keyword,
                PageSize = pageSize,
                PageNumber = pageNumber,
                PagesCount = totalCount / pageSize + (totalCount % pageSize == 0 ? 0 : 1),
                TotalCount = totalCount,
                Items = data.ConvertAll(f => new CustomersListItemViewModel
                {
                    Amount = f.Amount,
                    CreateDate = f.DateInfo.FirstRequest,
                    PayerMobile = f.Key.PayerMobile,
                    TotalTransactions = f.TotalTransactions,
                    SuccessTransactions = f.SuccessTransactions,
                    PayerName = string.Join("، ", f.Payer.Where(x => x.PayerName != null).Select(x => x.PayerName).Distinct())
                })
            };

            return View(viewModel);
        }

        public IActionResult Requests(int? gatewayId, int? walletId, string customerKey, string keyword, int pageNumber = 1, int pageSize = 10)
        {
            var user = athenticationProvider.GetUser();

            var query = dbContext.Transactions.Where(f => f.ISPAccessToken == null).Where(f => f.GateWay.Wallet.UserId == user.Id);

            if (gatewayId.HasValue)
                query = query.Where(f => f.GateWayId == gatewayId.Value);

            if (walletId.HasValue)
                query = query.Where(f => f.GateWay.WalletId == walletId.Value);

            if (!string.IsNullOrWhiteSpace(keyword))
                query = query.Where(f =>
                    f.InvoiceId.Contains(keyword)
                        ||
                    (f.TransactionResponse != null && (f.TransactionResponse.CardNumber.Contains(keyword) || f.TransactionResponse.Payload.Contains(keyword) || f.TransactionResponse.TraceNumber.ToString().Contains(keyword)))
                        ||
                    (f.GetTokenModel != null && (f.GetTokenModel.Description.Contains(keyword) || f.GetTokenModel.FactorNumber.Contains(keyword) || f.GetTokenModel.IPG.Contains(keyword)))
                        ||
                    (f.GetTokenModel != null && (f.GetTokenModel.PayerMail.Contains(keyword) || f.GetTokenModel.PayerMobile.Contains(keyword) || f.GetTokenModel.PayerName.Contains(keyword))));

            if (!string.IsNullOrWhiteSpace(customerKey))
                query = query.Where(f => dbContext.Transactions.Where(x => x.GateWay.Wallet.UserId == user.Id).Where(x => x.GetTokenModel.PayerUserId + x.GetTokenModel.PayerName + x.GetTokenModel.PayerMobile == customerKey).Any(x => x.Id == f.Id));

            var data = query.OrderByDescending(f => f.CreateDate).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(f => new
            {
                f.Id,
                f.GetTokenModel.Amount,
                GateWayTitle = f.GateWay.Title,
                f.GetTokenModel.PayerName,
                f.TransactionResponse.DatePaid,
                f.CreateDate,
                Success = f.TransactionConfirmResult != null && f.TransactionConfirmResult.Status != Framework.StorageModels.TransactionConfirmResult.ConfirmStatus.NOK
            }).ToList();

            var totalCount = query.Count();

            var viewModel = new TransactionsListViewModel
            {
                GateWayId = gatewayId,
                WalletId = walletId,
                Keyword = keyword,
                CustomerKey = customerKey,
                PageNumber = pageNumber,
                PageSize = pageSize,
                PagesCount = totalCount / pageSize + (totalCount % pageSize == 0 ? 0 : 1),
                TotalCount = totalCount,
                TotalAmount = query.Sum(f => f.GetTokenModel.Amount),
                TotalPageAmount = data.Sum(f => f.Amount),
                Items = data.ConvertAll(f => new TransactionsListItemViewModel
                {
                    Id = f.Id,
                    Amount = f.Amount,
                    CreateDate = f.CreateDate,
                    GateWayTitle = f.GateWayTitle,
                    PayerName = f.PayerName,
                    PayDate = f.DatePaid,
                    Success = f.Success
                })
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Settlements(int? minAmount, int? maxAmount, int? bankAccountId, int? walletId, int pageNumber = 1, int pageSize = 10)
        {
            var user = athenticationProvider.GetUser();

            var query = dbContext.Settlements.Where(f => f.UserId == user.Id);

            if (minAmount.HasValue)
                query = query.Where(f => f.Amount >= minAmount.Value);

            if (maxAmount.HasValue)
                query = query.Where(f => f.Amount <= maxAmount.Value);

            if (bankAccountId.HasValue)
                query = query.Where(f => f.BankAccountId == bankAccountId.Value);

            if (walletId.HasValue)
                query = query.Where(f => f.WalletId == walletId.Value);

            var data = await query.OrderByDescending(f => f.CreateDate).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(f => new
            {
                f.Amount,
                UserWageHistories = dbContext.UserWageHistories.Where(w => w.SettlementId == f.Id).ToList(),
                BankAccountFullName = f.BankAccount.FullName,
                QuickSettlement = f.QuickSettlement,
                BankAccountIban = f.BankAccount.Iban,
                f.CreateDate,
                f.SelectedDate,
                LastStatus = f.SettlementStatusHistories.OrderByDescending(x => x.CreateDate).Select(x => x.Status).FirstOrDefault(),
                f.RequestedUuid,
                f.Id,
                WalletTitle = f.Wallet.Title
            }).ToListAsync();

            var totalCount = query.Count();

            var viewModel = new SettlementsListViewModel
            {
                BankAccountId = bankAccountId,
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
                    Wage = f.UserWageHistories.Sum(w => w.Amount),
                    BankAccount = f.BankAccountFullName + "(" + f.BankAccountIban + ")",
                    QuickSettlement = f.QuickSettlement,
                    CreateDate = DateConverter.ToShamsy(f.CreateDate, true),
                    Id = f.Id,
                    LastStatus = f.LastStatus.ToDescription(),
                    RequestedUuid = f.RequestedUuid,
                    Wallet = f.WalletTitle,
                    SelectedDate = DateConverter.ToShamsy(f.SelectedDate, true),
                })
            };

            return View(viewModel);
        }
        public async Task<IActionResult> GetSettlementConfirm(int SettlementId)
        {
            try
            {
                var f = await dbContext.Settlements.Where(f => f.Id == SettlementId).Select(f => new
                {
                    f.OwnerName,
                    f.AccountNumber,
                    f.IbanNumber,
                    f.CardNumber,
                    f.NationalCode,
                    f.Amount,
                    Babat = f.Babat,
                    Sharh = f.Sharh,
                    Bank = f.Bank,
                    TransferType = f.TransferType,
                    CreateDate = f.CreateDate,
                    AmountInTipoulAfterSettlement = f.AmountInTipoulAfterSettlement,
                    TraceNumber=f.TraceNumber,
                    DocutmentURL = f.DocutmentURL,
                    PaymentID = f.PaymentID,
                }).FirstOrDefaultAsync();
                QuickSettlementResultFinishModel finishModel = new QuickSettlementResultFinishModel();
                finishModel.ownerName = f.OwnerName;
                finishModel.accountNumber = f.AccountNumber;
                finishModel.ibanNumber = f.IbanNumber;
                finishModel.cardNumber = f.CardNumber;
                finishModel.nationalCode = f.NationalCode;
                finishModel.amount = f.Amount;
                try { finishModel.babat = f.Babat.StringToEnum<BabatEnum>().ToDescription(); } catch (Exception ex) { };
                finishModel.sharh = f.Sharh;
                try { finishModel.bank = f.Bank.StringToEnum<BankEnum>().ToDescription(); } catch (Exception ex) { };
                try { finishModel.transferType = f.TransferType.StringToEnum<TransferTypeEnum>().ToDescription(); } catch (Exception ex) { };
                finishModel.settlementCreateDate = DateConverter.ToShamsy(f.CreateDate, true);
                finishModel.depositCreateDate = DateConverter.ToShamsy(f.CreateDate, true);
                finishModel.amountInTipoulAfterSettlement = f.AmountInTipoulAfterSettlement;
                finishModel.TraceNumber = f.TraceNumber;
                finishModel.DocutmentURL = f.DocutmentURL;
                finishModel.PaymentID = f.PaymentID;
                return Json(new { status = "success", message = finishModel });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", message = ex.Message });
            }
        }

        public async Task<IActionResult> WalletDepositRequests(int walletId, int? minAmount, int? maxAmount, int pageNumber = 1, int pageSize = 10)
        {
            var user = athenticationProvider.GetUser();

            var query = dbContext.WalletDepositRequests.Where(f => f.UserId == user.Id);
            query = query.Where(f => f.WalletId == walletId);

            if (minAmount.HasValue)
                query = query.Where(f => f.Amount >= minAmount.Value);

            if (maxAmount.HasValue)
                query = query.Where(f => f.Amount <= maxAmount.Value);

            var data = await query.OrderByDescending(f => f.CreateDate).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(f => new
            {
                f.Amount,
                f.AmountAfterDeposit,
                f.TransactionTrace,
                f.TransactionDate,
                f.SourceOwnerName,
                f.SourceIbanNumber,
                f.SourceBank,
                f.SourceOwnerNationalCode,
                f.DestIbanNumber,
                f.DepositerName,
                f.DepositerNationalCode,
                f.DepositType,
                f.Description,
                f.CreateDate,
                LastStatus = f.WalletDepositRequestStatusHistories.OrderByDescending(x => x.CreateDate).Select(x => x.Status).FirstOrDefault(),
                f.ConfirmDate,
                f.ConfirmDescription,
                f.Id,
                WalletTitle = f.Wallet.Title
            }).ToListAsync();

            var totalCount = query.Count();
            var viewModel = new WalletDepositRequestsListViewModel
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
                Items = data.ConvertAll(f => new WalletDepositRequestsListItemViewModel
                {
                    Amount = f.Amount,
                    AmountAfterDeposit = f.AmountAfterDeposit,
                    TransactionTrace = f.TransactionTrace,
                    TransactionDate = f.TransactionDate,
                    SourceOwnerName = f.SourceOwnerName,
                    SourceIbanNumber = f.SourceIbanNumber,
                    SourceBank = f.SourceBank,
                    SourceOwnerNationalCode = f.SourceOwnerNationalCode,
                    DestIbanNumber = f.DestIbanNumber,
                    DepositerName = f.DepositerName,
                    DepositerNationalCode = f.DepositerNationalCode,
                    DepositType = ((TransferTypeEnum)Enum.Parse(typeof(TransferTypeEnum), f.DepositType)).ToDescription(),
                    Description = f.Description,
                    CreateDate = DateConverter.ToShamsy(f.CreateDate, true),
                    Id = f.Id,
                    LastStatus = f.LastStatus.ToDescription(),
                    ConfirmDate = DateConverter.ToShamsy(f.ConfirmDate, true),
                    ConfirmDescription = f.ConfirmDescription,
                    Wallet = f.WalletTitle,
                })
            };

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddWalletDepositRequest(int walletId, long amount, string transactionDate, string transactionTrace,
             string sourceIban, string destIban, string depositerName, string depositerNationalCode, TransferTypeEnum depositType, string description)
        {
            try
            {
                var user = athenticationProvider.GetUser();
                string ibanFormat = "^IR[0-9]{24}";
                if (!Regex.IsMatch(sourceIban ?? "", ibanFormat))
                    return Json(new { status = "error", message = "شماره شبای حساب مبدا معتبر نمی باشد" });
                if (!Regex.IsMatch(destIban ?? "", ibanFormat))
                    return Json(new { status = "error", message = "شماره شبای حساب مقصد معتبر نمی باشد" });
                if (!Regex.IsMatch(transactionDate ?? "", "^[0-9]{8,8}$"))
                    return Json(new { status = "error", message = "تاریخ واریز را بدون فاصله و / و 6 رقمی واردکنید مثال 14010101" });

                var requests = dbContext.WalletDepositRequests.Where(f => f.WalletId == walletId && f.Amount == amount
                && f.TransactionTrace == transactionTrace && f.TransactionDate == transactionDate).ToList();
                foreach (var item in requests)
                {
                    if (item != null)
                    {
                        var LastStatus = dbContext.WalletDepositRequestStatusHistories.Where(w => w.WalletDepositRequestId == item.Id).OrderByDescending(x => x.CreateDate).Select(x => x.Status).FirstOrDefault();
                        if (LastStatus != WalletDepositRequestStatusHistory.DepositStatus.Reject)
                            return Json(new { status = "error", message = "درخواست واریزی با مشخصات وارد شده قبلا ثبت شده است" });
                    }
                }
                string fromDate, toDate, fromTime = "000000", toTime = "235959";
                fromDate = toDate = transactionDate;
                Framework.ShahinService.ShahinOperation.Models.GetTokenResult token = await shahinService.GetToken();

                var sourceIbanInfoModel = new IbanInfoModel(token.bank, token.user_name, sourceIban);
                IbanInfoResultModel sourceIbanInfo = await shahinService.GetIbanInfo(sourceIbanInfoModel, token.access_token, "");
                if (sourceIbanInfo.respObject.errorCode != null)
                    return Json(new { status = "error", message = "خطای سرویس استعلام شبا مبدا =>" + sourceIbanInfo.transactionState + ":" + sourceIbanInfo.respObject.message });

                var destIbanInfoModel = new IbanInfoModel(token.bank, token.user_name, destIban);
                IbanInfoResultModel destIbanInfo = await shahinService.GetIbanInfo(destIbanInfoModel, token.access_token, "");
                if (destIbanInfo.respObject.errorCode != null)
                    return Json(new { status = "error", message = "خطای سرویس استعلام شبا مقصد =>" + destIbanInfo.transactionState + ":" + destIbanInfo.respObject.message });

                var model = new AccountStatementModel(token.bank, token.user_name, token.accounts[0], fromDate, fromTime, toDate, toTime);
                AccountStatementResultModel resultmodel = await shahinService.GetAccountStatement(model, token.access_token, "");

                if (resultmodel.respObject.errorCode != null)
                {
                    return Json(new { status = "error", message = "خطای سرویس استعلام :" + resultmodel.respObject.errorCode + ":" + resultmodel.respObject.message });
                }
                else
                {
                    bool find = resultmodel.respObject.accountStatementList.Where(f => f.credit == amount && f.transactionDate == transactionDate).Any();
                    if (!find)
                        return Json(new { status = "error", message = string.Format("در تاریخ ({0}) مبلغ ({1}) به حساب شبای ({2}) واریز نشده است", transactionDate, amount, destIban) });
                    var walletDepositRequest = new WalletDepositRequest();
                    walletDepositRequest.UserId = user.Id;
                    walletDepositRequest.WalletId = walletId;
                    walletDepositRequest.Amount = amount;
                    walletDepositRequest.TransactionTrace = transactionTrace;
                    walletDepositRequest.TransactionDate = transactionDate;
                    walletDepositRequest.SourceOwnerName = sourceIbanInfo.respObject.firstName + " " + sourceIbanInfo.respObject.lastName;
                    walletDepositRequest.SourceOwnerNationalCode = sourceIbanInfo.respObject.nationalCode;
                    walletDepositRequest.SourceBank = sourceIbanInfo.respObject.bank;
                    walletDepositRequest.SourceAcountNumber = sourceIbanInfo.respObject.accountNumber;
                    walletDepositRequest.SourceIbanNumber = sourceIbanInfo.respObject.ibanNumber;
                    walletDepositRequest.DestIbanNumber = destIban;
                    walletDepositRequest.DepositerName = depositerName;
                    walletDepositRequest.DepositerNationalCode = depositerNationalCode;
                    walletDepositRequest.DepositType = depositType.ToString();
                    walletDepositRequest.Description = description;
                    dbContext.WalletDepositRequests.Add(walletDepositRequest);
                    dbContext.SaveChanges();
                    return Json(new { status = "success", message = "درخواست واریز ثبت شد و پس از بررسی و تایید به موجودی کیف پول افزوده خواهد شد" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", message = ex.Message });
            }
        }
        public IActionResult WalletDepositRequestModal(int walletId)
        {
            return PartialView(walletId);
        }
        public async Task<IActionResult> GetWalletDepositRequest(int walletDepositRequestsId)
        {
            try
            {
                var f = dbContext.WalletDepositRequests.Where(f => f.Id == walletDepositRequestsId).FirstOrDefault();
                var model = new WalletDepositRequestsListItemViewModel();
                if (f != null && f.Id > 0)
                {
                    model.Amount = f.Amount;
                    model.AmountAfterDeposit = f.AmountAfterDeposit;
                    model.TransactionTrace = f.TransactionTrace;
                    model.TransactionDate = f.TransactionDate;
                    model.SourceOwnerName = f.SourceOwnerName;
                    model.SourceIbanNumber = f.SourceIbanNumber;
                    model.SourceBank = f.SourceBank;
                    model.SourceOwnerNationalCode = f.SourceOwnerNationalCode;
                    model.DestIbanNumber = f.DestIbanNumber;
                    model.DepositerName = f.DepositerName;
                    model.DepositerNationalCode = f.DepositerNationalCode;
                    model.DepositType = ((TransferTypeEnum)Enum.Parse(typeof(TransferTypeEnum), f.DepositType)).ToDescription();
                    model.Description = f.Description;
                    model.CreateDate = DateConverter.ToShamsy(f.CreateDate, true);
                    model.Id = f.Id;
                    model.LastStatus = dbContext.WalletDepositRequestStatusHistories.OrderByDescending(x => x.CreateDate).Select(x => x.Status).FirstOrDefault().ToDescription();
                    model.ConfirmDate = DateConverter.ToShamsy(f.ConfirmDate, true);
                    model.ConfirmDescription = f.ConfirmDescription;
                    model.Wallet = dbContext.Wallets.Where(w => w.Id == f.WalletId).FirstOrDefault().Title;
                };
                return Json(new { status = "success", message = model });
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
