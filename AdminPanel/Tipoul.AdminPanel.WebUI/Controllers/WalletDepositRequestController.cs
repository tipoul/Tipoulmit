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
using static Tipoul.Framework.StorageModels.WalletDepositRequestStatusHistory;
using Tipoul.Framework.Utilities.Converters;
using Tipoul.AdminPanel.WebUI.Models.WalletDepositRequest;
using Tipoul.Framework.Utilities.Utilities;
using Tipoul.Framework.Utilities.Enums;
using Org.BouncyCastle.Bcpg;
using ICSharpCode.SharpZipLib.Zip;

namespace Tipoul.UserPanel.WebUI.Controllers
{
    public class WalletDepositRequestController : Controller
    {
        private readonly TipoulFrameworkDbContext dbContext;
        private readonly AthenticationProvider athenticationProvider;
        public WalletDepositRequestController(TipoulFrameworkDbContext dbContext, AthenticationProvider athenticationProvider)
        {
            this.dbContext = dbContext;
            this.athenticationProvider = athenticationProvider;
        }
        public async Task<IActionResult> WalletDepositRequests(int? minAmount, int? maxAmount, int? bankAccountId, int? walletId, int pageNumber = 1, int pageSize = 10)
        {
            var user = athenticationProvider.GetUser();

            var query = dbContext.WalletDepositRequests.Where(f => f.UserId > 0);
            if (minAmount.HasValue)
                query = query.Where(f => f.Amount >= minAmount.Value);

            if (maxAmount.HasValue)
                query = query.Where(f => f.Amount <= maxAmount.Value);

            if (walletId.HasValue)
                query = query.Where(f => f.WalletId == walletId.Value);
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
                    model.LastStatus = dbContext.WalletDepositRequestStatusHistories.Where(h => h.WalletDepositRequestId == f.Id).OrderByDescending(x => x.CreateDate).Select(x => x.Status).FirstOrDefault().ToDescription();
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

        public async Task<IActionResult> ChangeStatus(int walletDepositRequestsId, DepositStatus status, string confirmDescription)
        {
            try
            {
                var user = athenticationProvider.GetUser();
                var request = dbContext.WalletDepositRequests.Where(f => f.Id == walletDepositRequestsId).FirstOrDefault();
                if (request == null)
                    return Json(new { status = "error", message = "درخواست واریز به حسابی با مشخصات وارد شده یافت نشد" });
                else
                {
                    var LastStatus = dbContext.WalletDepositRequestStatusHistories.Where(w => w.WalletDepositRequestId == request.Id).OrderByDescending(x => x.CreateDate).Select(x => x.Status).FirstOrDefault();
                    if (LastStatus != DepositStatus.Created)
                        return Json(new { status = "error", message = "درخواست واریز به حساب بررسی شده و امکان بررسی مجدد وجود ندارد" });
                    request.ConfirmDescription = confirmDescription;
                    request.ConfirmDate = DateTime.Now;
                    var history = new WalletDepositRequestStatusHistory();
                    history.UserId = user.Id;
                    history.Status = status;
                    history.CreateDate = DateTime.Now;
                    request.WalletDepositRequestStatusHistories.Add(history);

                    long AmountInTipoulBefor = dbContext.Wallets.Where(w => w.Id == request.WalletId).FirstOrDefault().AmountInTipoul;
                    if (status == DepositStatus.Confirm)
                    {
                        dbContext.Wallets.Where(f => f.Id == request.WalletId).ToList().ForEach(f => { f.AmountInTipoul += request.Amount; });
                        request.AmountAfterDeposit = AmountInTipoulBefor + request.Amount;
                    }
                    else
                        request.AmountAfterDeposit = AmountInTipoulBefor;

                    dbContext.SaveChanges();
                };
                return Json(new { status = "success", message = true });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", message = ex.Message });
            }
        }


    }
}
