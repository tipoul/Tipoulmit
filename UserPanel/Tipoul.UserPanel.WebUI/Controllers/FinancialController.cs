using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Tipoul.Athentication.Agent.Services;
using Tipoul.Framework.DataAccessLayer;
using Tipoul.Framework.StorageModels;
using Tipoul.UserPanel.WebUI.Models.Financial;

namespace Tipoul.UserPanel.WebUI.Controllers
{
    public class FinancialController : Controller
    {
        private readonly TipoulFrameworkDbContext dbContext;

        private readonly AthenticationProvider athenticationProvider;

        public FinancialController(TipoulFrameworkDbContext dbContext, AthenticationProvider athenticationProvider)
        {
            this.dbContext = dbContext;
            this.athenticationProvider = athenticationProvider;
        }

        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10)
        {
            var user = athenticationProvider.GetUser();

            var wageData = await dbContext.UserWageTypeHistories.Where(f => f.UserId == user.Id).OrderByDescending(x => x.CreateDate).FirstOrDefaultAsync();

            var historyQuery = dbContext.UserWageHistories
                .Include(f => f.Settlement).Include(f => f.UserWageTypeHistory)
                .Where(f => dbContext.Transactions.Any(x => x.UserWageHistoryId == f.Id && x.TransactionConfirmResult != null && x.TransactionConfirmResult.Status != TransactionConfirmResult.ConfirmStatus.NOK))
                .Where(f => f.UserId == user.Id).OrderByDescending(f => f.CreateDate);

            var historyData = await historyQuery.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            var totalCount = await historyQuery.CountAsync();

            var historyIds = historyData.Select(f => f.Id).ToList();

            var transactionIds = await dbContext.Transactions
                .Where(f => f.TransactionConfirmResult != null && f.TransactionConfirmResult.Status != TransactionConfirmResult.ConfirmStatus.NOK)
                .Where(f => f.UserWageHistoryId.HasValue && historyIds.Contains(f.UserWageHistoryId.Value)).Select(f => new
                {
                    f.Id,
                    f.UserWageHistoryId
                }).ToListAsync();

            var viewModel = new FinancialViewModel
            {
                PagesCount = totalCount / pageSize + (totalCount % pageSize == 0 ? 0 : 1),
                PageNumber = pageNumber,
                WageType = ((int?)wageData?.WageType) ?? 0,
                StaticAmount = wageData?.StaticAmount ?? 0,
                Items = historyData.ConvertAll(f => new FinantialWageHistoryViewModel
                {
                    Id = f.Id,
                    WageType = UserWageTypeHistory.GetUserTypeName(f.UserWageTypeHistory.WageType),
                    Amount = f.Amount,
                    CreateDate = f.CreateDate,
                    SettlementDate = f.Settlement?.CreateDate,
                    TransactionIds = transactionIds.Where(x => x.UserWageHistoryId.HasValue && x.UserWageHistoryId.Value == f.Id).Select(x => x.Id).ToList()
                })
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(int wageType, int? amount)
        {
            var userWageType = (UserWageTypeHistory.UserWageType)wageType;

            var newWageType = new UserWageTypeHistory
            {
                WageType = userWageType,
                MaxRelativeAmount = userWageType == UserWageTypeHistory.UserWageType.FromSettlement ? 500000 : userWageType == UserWageTypeHistory.UserWageType.FromTransaction ? 25000 : null,
                RelativeAmount = userWageType == UserWageTypeHistory.UserWageType.FromTransactionStaticAmount ? null : 1,
                StaticAmount = userWageType == UserWageTypeHistory.UserWageType.FromTransactionStaticAmount ? 6000 : null,
                UserId = athenticationProvider.GetUser().Id
            };

            dbContext.UserWageTypeHistories.Add(newWageType);

            await dbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
