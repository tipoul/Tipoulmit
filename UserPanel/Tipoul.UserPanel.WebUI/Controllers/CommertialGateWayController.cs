using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Tipoul.Athentication.Agent.Services;
using Tipoul.Framework.DataAccessLayer;
using Tipoul.Framework.StorageModels;
using Tipoul.Framework.Utilities.Utilities;
using Tipoul.UserPanel.WebUI.Models.CommertialGateWay;
using Tipoul.UserPanel.WebUI.Services;

namespace Tipoul.UserPanel.WebUI.Controllers
{
    public class CommertialGateWayController : Controller
    {
        private readonly AthenticationProvider athenticationProvider;

        private readonly TipoulFrameworkDbContext dbContext;

        public CommertialGateWayController(TipoulFrameworkDbContext dbContext, AthenticationProvider athenticationProvider)
        {
            this.dbContext = dbContext;
            this.athenticationProvider = athenticationProvider;
        }

        public async Task<IActionResult> Index()
        {
            var user = athenticationProvider.GetUser();

            var data = await dbContext.CommertialGateWays
                .Include(f => f.Wallet)
                .Include(f => f.CommertialGateWayStatuses).Where(f => f.Wallet.UserId == user.Id).ToListAsync();

            return View(data.ConvertAll(f => new ListViewModel
            {
                Id = f.Id,
                Status = f.CommertialGateWayStatuses.OrderByDescending(x => x.CreateDate).Select(x => x.Status.ToString()).FirstOrDefault(),
                WalletTitle = f.Wallet.Title,
                Token = f.Token,
                TransactionsCount = dbContext.Transactions.Where(x => x.GateWayId == f.Id).Count(),
                TransactionsAmount = dbContext.Transactions.Where(x => x.GateWayId == f.Id).Where(f => f.TransactionConfirmResult != null && f.TransactionConfirmResult.Status != Framework.StorageModels.TransactionConfirmResult.ConfirmStatus.NOK).Sum(x => x.GetTokenModel.Amount),
                Title = f.Title,
                LogoUrl = f.LogoUrl,
                Settlement = CommertialGateWay.GetSettlementName(f.Settlement),
                SettlementPeriod = f.Settlement == CommertialGateWay.SettlementType.Automatic ? CommertialGateWay.GetSettlementPeriodName(f.SettlementPeriod) : string.Empty,
                SupportPhoneNumber = f.SupportPhoneNumber,
                WageSide = CommertialGateWay.GetWagePayerSideName(f.WageSide),
                WebSiteURL = f.WebSiteURL
            }));
        }

        public async Task<IActionResult> Form(int? id)
        {
            var user = athenticationProvider.GetUser();

            var data = id.HasValue ? await dbContext.CommertialGateWays.Include(f => f.BusinessSubCategory).FirstOrDefaultAsync(f => f.Id == id.Value) : new Framework.StorageModels.CommertialGateWay();

            return View(new CommertialGateWayModel
            {
                BusinessCategoryId = data.BusinessSubCategory?.BusinessCategoryId ?? 0,
                BusinessSubCategoryId = data.BusinessSubCategoryId,
                Description = data.Description,
                Id = id.HasValue ? id.Value : 0,
                LogoUrl = data.LogoUrl,
                Settlement = (CommertialGateWayModel.SettlementType)data.Settlement,
                SettlementPeriod = (CommertialGateWayModel.SettlementPeriodType)data.SettlementPeriod,
                SupportPhoneNumberCode = ExceptionUtility.TryDo(() => data.SupportPhoneNumber?.Split("-")[0]),
                SupportPhoneNumberValue = ExceptionUtility.TryDo(() => data.SupportPhoneNumber?.Split("-")[1]),
                Title = data.Title,
                Token = data.Token,
                WageSide = (CommertialGateWayModel.WagePayerSide)data.WageSide,
                WalletId = data.WalletId,
                WebSiteURL = data.WebSiteURL,
                //HasETrust = data.HasETrust,
                //ETrustStarsCount = data.ETrustStarsCount,
                Wallets = (await dbContext.Wallets.Where(f => f.UserId == user.Id).ToListAsync()).ConvertAll(f => new CommertialGateWayModel.IdName { Id = f.Id, Name = f.Title }),
                BusinessCategories = (await dbContext.BusinessCategories.ToListAsync()).ConvertAll(f => new CommertialGateWayModel.IdName { Id = f.Id, Name = f.Title }),
                Banks = (await dbContext.BankAccounts.Where(f => f.UserId == user.Id).ToListAsync()).ConvertAll(f => new CommertialGateWayModel.IdName { Id = f.Id, Name = f.FullName }),
                SettlementBankId = data.DefaultBankAccountId,
                BusinessSelectedCategorySubCategories = data.BusinessSubCategoryId != 0
                    ? (await dbContext.BusinessSubCategories.Where(f => f.BusinessCategoryId == data.BusinessSubCategory.BusinessCategoryId).ToListAsync()).ConvertAll(f => new CommertialGateWayModel.IdName { Id = f.Id, Name = f.Title })
                    : new List<CommertialGateWayModel.IdName>()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Form([FromServices] IConfiguration configuration, [FromForm] CommertialGateWayModel model)
        {
            var dbModel = model.Id == 0 ? new CommertialGateWay() : await dbContext.CommertialGateWays.FirstOrDefaultAsync(f => f.Id == model.Id);

            dbModel.BusinessSubCategoryId = model.BusinessSubCategoryId;
            dbModel.Description = model.Description;
            dbModel.Settlement = (CommertialGateWay.SettlementType)model.Settlement;
            dbModel.SettlementPeriod = (CommertialGateWay.SettlementPeriodType)model.SettlementPeriod;
            dbModel.DefaultBankAccountId = model.SettlementBankId;
            dbModel.SupportPhoneNumber = model.SupportPhoneNumberCode + "-" + model.SupportPhoneNumberValue;
            dbModel.Title = model.Title;
            dbModel.WebSiteURL = model.WebSiteURL?.ToLower().Trim();
            dbModel.WalletId = model.WalletId;
            //dbModel.HasETrust = model.HasETrust;
            //dbModel.ETrustStarsCount = model.ETrustStarsCount;
            dbModel.WageSide = (CommertialGateWay.WagePayerSide)model.WageSide;
            if (string.IsNullOrWhiteSpace(dbModel.Token))
            {
                var claims = new Dictionary<string, string>();
                claims.Add(nameof(dbModel.Id), dbModel.Id.ToString());
                claims.Add(nameof(dbModel.Title), dbModel.Title);
                claims.Add(nameof(dbModel.SupportPhoneNumber), dbModel.SupportPhoneNumber.ToString());
                claims.Add(nameof(dbModel.WebSiteURL), dbModel.WebSiteURL.ToString());
                dbModel.Token = Guid.NewGuid().ToString();
            }

            var newLogoUrl = await SaveUploadedFileIfExists("commertial gate way", configuration);

            if (!string.IsNullOrWhiteSpace(newLogoUrl))
                dbModel.LogoUrl = newLogoUrl;

            if (dbModel.Id == 0)
            {
                CommertialGateWayRegistrationHostedService.Register(athenticationProvider.GetUser().Id);
                dbContext.CommertialGateWays.Add(dbModel);
            }

            await dbContext.SaveChangesAsync();

            return RedirectToAction("index");
        }

        private async Task<string> SaveUploadedFileIfExists(string directory, [FromServices] IConfiguration configuration, IFormFile file = null)
        {
            if (file == null && (Request.Form.Files == null || Request.Form.Files.Count == 0))
                return null;

            file = file ?? Request.Form.Files[0];

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
    }
}
