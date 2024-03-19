using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using System.Linq;
using System.Threading.Tasks;

using Tipoul.AdminPanel.WebUI.Controllers.Abstraction;
using Tipoul.AdminPanel.WebUI.Models.BankAccount;
using Tipoul.Athentication.Agent.Services;
using Tipoul.Framework.DataAccessLayer;
using Tipoul.Framework.StorageModels;

namespace Tipoul.AdminPanel.WebUI.Controllers
{
    public class BankAccountController : TipoulBaseController<BankAccount, BankAccountListViewModel, BankAccountFormViewModel>
    {
        public BankAccountController(TipoulFrameworkDbContext dbContext, AthenticationProvider athenticationProvider) : base(dbContext, athenticationProvider)
        {
        }

        protected override async Task<BankAccountFormViewModel> GetItemAsync(int? id)
        {
            if (id.HasValue)
                return new BankAccountFormViewModel(await dbContext.BankAccounts.FirstOrDefaultAsync(f => f.Id == id.Value));
            else
                return new BankAccountFormViewModel();
        }

        protected override async Task<BankAccountListViewModel> GetListAsync(int pageNumber)
        {
            var query = dbContext.BankAccounts
                .Include(f => f.User)
                .Include(f => f.Bank)
                .OrderByDescending(f => f.Id)
                .AsQueryable();

            var count = await query.CountAsync();

            var data = await SkipTake(query, pageNumber).ToListAsync();

            return new BankAccountListViewModel(count, pageNumber, data.ConvertAll(item => new BankAccountListItemViewModel(item)));
        }

        protected override async Task SaveItemAsync([FromServices] IConfiguration configuration, BankAccountFormViewModel model)
        {
            var dbModel = model.Id == 0 ? new BankAccount() : await dbContext.BankAccounts.FirstOrDefaultAsync(f => f.Id == model.Id);

            dbModel.Id = model.Id;
            dbModel.FullName = model.FullName;
            dbModel.NationalCode = model.NationalCode;
            dbModel.BankId = model.BankId;
            dbModel.Iban = model.Iban;
            dbModel.UserId = model.UserId;
            dbModel.BirthDate = model.BirthDate;

            if (dbModel.Id == 0)
                await dbContext.BankAccounts.AddAsync(dbModel);

            await dbContext.SaveChangesAsync();
        }
    }

}