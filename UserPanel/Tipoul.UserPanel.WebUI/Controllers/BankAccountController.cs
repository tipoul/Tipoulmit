using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Tipoul.Athentication.Agent.Services;
using Tipoul.Framework.DataAccessLayer;
using Tipoul.Framework.StorageModels;
using Tipoul.UserPanel.WebUI.Models.BankAccount;

namespace Tipoul.UserPanel.WebUI.Controllers
{
    public class BankAccountController : Controller
    {
        private readonly AthenticationProvider athenticationProvider;

        private readonly TipoulFrameworkDbContext dbContext;

        public BankAccountController(AthenticationProvider athenticationProvider, TipoulFrameworkDbContext dbContext)
        {
            this.athenticationProvider = athenticationProvider;
            this.dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var user = athenticationProvider.GetUser();

            var data = await dbContext.BankAccounts.Include(f => f.Bank).Where(f => !f.Trashed && f.UserId == user.Id).ToListAsync();

            return View(data.ConvertAll(f => new ListViewModel
            {
                Id = f.Id,
                FullName = f.FullName,
                BankName = f.Bank.Name,
                BankLogoURL = f.Bank.LogoURL,
                IsActive = f.IsActive,
                Iban = f.Iban
            }));
        }

        public async Task<IActionResult> Form(int? id)
        {
            var viewModel = new FormViewModel();

            if (id.HasValue)
            {
                var user = athenticationProvider.GetUser();

                var dbModel = await dbContext.BankAccounts.FirstOrDefaultAsync(f => f.Id == id.Value && f.UserId == user.Id);

                if (dbModel == null)
                    return NotFound();

                viewModel.BankId = dbModel.BankId;
                viewModel.FullName = dbModel.FullName;
                viewModel.Iban = dbModel.Iban;
                viewModel.Id = dbModel.Id;
                viewModel.IsActive = dbModel.IsActive;
                viewModel.NationalCode = dbModel.NationalCode;
                viewModel.BirthDate = Tipoul.Framework.Utilities.Converters.DateConverter.ToShamsy(dbModel.BirthDate);
            }
            else
                viewModel.BirthDate = Tipoul.Framework.Utilities.Converters.DateConverter.ToShamsy(DateTime.Now);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Form([FromForm] FormViewModel model)
        {
            var dbModel = model.Id == 0 ? new BankAccount() : await dbContext.BankAccounts.FirstOrDefaultAsync(f => f.Id == model.Id);

            if (dbModel == null)
                return NotFound();

            dbModel.BankId = model.BankId;
            dbModel.FullName = model.FullName;
            dbModel.Iban = model.Iban;
            dbModel.IsActive = model.IsActive;
            dbModel.NationalCode = model.NationalCode;
            dbModel.BirthDate = DateTime.Parse(model.BirthDate);
            dbModel.UserId = athenticationProvider.GetUser().Id;

            if (dbModel.Id == 0)
                dbContext.BankAccounts.Add(dbModel);

            await dbContext.SaveChangesAsync();

            return RedirectToAction("index");
        }

        public async Task<IActionResult> Toggle(int id)
        {
            var bankAccount = await dbContext.BankAccounts.FirstOrDefaultAsync(f => f.Id == id);
            bankAccount.IsActive = !bankAccount.IsActive;

            await dbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
