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
using Tipoul.UserPanel.WebUI.Models.Wizard.Profile;
using Tipoul.UserPanel.WebUI.Models.Wizard;
using Tipoul.UserPanel.WebUI.Services;
using Tipoul.Framework.Utilities.Utilities;
using Tipoul.Athentication.Agent;
using System.Collections.Immutable;

namespace Tipoul.UserPanel.WebUI.Controllers
{
    public class WizardController : Controller
    {
        private readonly TipoulFrameworkDbContext dbContext;

        private readonly AthenticationProvider athenticationProvider;

        public WizardController(TipoulFrameworkDbContext dbContext, AthenticationProvider athenticationProvider)
        {
            this.dbContext = dbContext;
            this.athenticationProvider = athenticationProvider;
        }

        public IActionResult Index() => Redirect("/wizard/Profile?sender=index");

        public async Task<IActionResult> Profile(string sender)
        {
            if (string.IsNullOrWhiteSpace(sender) || sender != "index")
                return RedirectToAction("ProfilePersonalInfo");

            var user = athenticationProvider.GetUser();

            var dbUser = await dbContext.Users
                .Include(f => f.BankAccounts)
                .Include(f => f.IdentityDocuments)
                .Include(f => f.Wallet).ThenInclude(f => f.CommertialGateWays)
                .FirstOrDefaultAsync(f => f.Id == user.Id);

            #region profile

            if (string.IsNullOrWhiteSpace(dbUser.FirstName))
                return RedirectToAction("ProfilePersonalInfo");

            if (string.IsNullOrWhiteSpace(dbUser.Address))
                return RedirectToAction("ProfileAddress");

            if (!dbUser.BusinessSubCategoryId.HasValue)
                return RedirectToAction("ProfileBusiness");

            if (dbUser.IdentityDocuments.Count == 0)
                return RedirectToAction("ProfileVerify");

            if (!await dbContext.LegalProfiles.AnyAsync(f => f.UserId == user.Id))
                return RedirectToAction("ProfileLegal");

            #endregion

            if (dbUser.BankAccounts.Count == 0)
                return RedirectToAction("BankAccount");

            if (string.IsNullOrWhiteSpace(dbUser.TaxCode))
                return RedirectToAction("TaxCode");

            if (dbUser.Wallet.CommertialGateWays.Count == 0)
                return RedirectToAction("CommertialGateWay");

            return Redirect("/");
        }

        #region profile

        public async Task<IActionResult> ProfilePersonalInfo()
        {
            var user = await GetUserAsync();

            return View(new PersonalInfoModel
            {
                AvatarURL = user.AvatarURL,
                BirthDate = user.BirthDate,
                Email = user.Email,
                FatherName = user.FatherName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MobileNumber = user.MobileNumber,
                NationalCode = user.NationalCode
            });
        }

        [HttpPost]
        public async Task<IActionResult> ProfilePersonalInfo([FromServices] IConfiguration configuration, [FromForm] PersonalInfoModel model)
        {
            var user = await GetUserAsync();

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.FatherName = model.FatherName;
            if (!user.BirthDate.HasValue)
                user.BirthDate = model.BirthDate.HasValue ? model.BirthDate.Value.AddDays(1) : null;
            user.NationalCode = model.NationalCode;
            if (user.Email != model.Email)
                user.EmailConfirmed = false;
            user.Email = model.Email;
            if (user.MobileNumber != model.MobileNumber)
                user.MobileNumberConfirmed = false;
            user.MobileNumber = model.MobileNumber;

            var avatarPath = await SaveUploadedFileIfExists("avatars", configuration);

            if (!string.IsNullOrWhiteSpace(avatarPath))
            {
                user.AvatarURL = avatarPath;
                user.UserAvatarHistories.Add(new UserAvatarHistory { AvatarURL = user.AvatarURL });
            }

            await dbContext.SaveChangesAsync();

            return RedirectToAction("ProfileAddress", new { saved = true });
        }

        public async Task<IActionResult> ProfileAddress()
        {
            var user = await GetUserAsync(nameof(Framework.StorageModels.User.City));

            return View(new AddressModel
            {
                Address = user.Address,
                StateId = user.City?.StateId,
                CityId = user.CityId,
                PhoneNumberCode = ExceptionUtility.TryDo(() => user.PhoneNumber?.Split("-")[0]),
                PhoneNumberValue = ExceptionUtility.TryDo(() => user.PhoneNumber?.Split("-")[1]),
                PostalCode = user.PostalCode,
                States = (await dbContext.States.ToListAsync()).ConvertAll(f => new AddressModel.StateCityModel { Id = f.Id, Name = f.Name }),
                SelectedStateCities = user.CityId.HasValue ? (await dbContext.Cities.Where(f => f.StateId == user.City.StateId).ToListAsync()).ConvertAll(f => new AddressModel.StateCityModel { Id = f.Id, Name = f.Name }) : new List<AddressModel.StateCityModel>()
            });
        }

        [HttpPost]
        public async Task<IActionResult> ProfileAddress([FromForm] AddressModel model)
        {
            var user = await GetUserAsync();

            user.Address = model.Address;
            user.PostalCode = model.PostalCode;
            user.CityId = model.CityId;
            user.PhoneNumber = model.PhoneNumberCode + "-" + model.PhoneNumberValue;

            await dbContext.SaveChangesAsync();

            return RedirectToAction("profileBusiness", new { saved = true });
        }

        public async Task<IActionResult> ProfileBusiness()
        {
            var user = await GetUserAsync(nameof(Framework.StorageModels.User.JobCity), nameof(Framework.StorageModels.User.BusinessSubCategory));

            return View(new BusinessModel
            {
                BusinessCategoryId = user.BusinessSubCategory?.BusinessCategoryId,
                BusinessSubCategoryId = user.BusinessSubCategoryId,
                JobAddress = user.JobAddress,
                StateId = user.JobCity?.StateId,
                CityId = user.JobCityId,
                JobPhoneNumberCode = ExceptionUtility.TryDo(() => user.JobPhoneNumber?.Split("-")[0]),
                JobPhoneNumberValue = ExceptionUtility.TryDo(() => user.JobPhoneNumber?.Split("-")[1]),
                JobPostalCode = user.JobPostalCode,
                BusinessCategories = (await dbContext.BusinessCategories.ToListAsync()).ConvertAll(f => new BusinessModel.IdName { Id = f.Id, Name = f.Title }),
                BusinessSelectedCaqtegorySubCategories = user.BusinessSubCategoryId.HasValue
                    ? (await dbContext.BusinessSubCategories.Where(f => f.BusinessCategoryId == user.BusinessSubCategory.BusinessCategoryId).ToListAsync()).ConvertAll(f => new BusinessModel.IdName { Id = f.Id, Name = f.Title })
                    : new List<BusinessModel.IdName>(),
                JobStates = (await dbContext.States.ToListAsync()).ConvertAll(f => new BusinessModel.IdName { Id = f.Id, Name = f.Name }),
                JobSelectedStateCities = user.JobCityId.HasValue ? (await dbContext.Cities.Where(f => f.StateId == user.JobCity.StateId).ToListAsync()).ConvertAll(f => new BusinessModel.IdName { Id = f.Id, Name = f.Name }) : new List<BusinessModel.IdName>()
            });
        }

        [HttpPost]
        public async Task<IActionResult> ProfileBusiness([FromForm] BusinessModel model)
        {
            var user = await GetUserAsync();

            user.JobAddress = model.JobAddress;
            user.JobCityId = model.CityId;
            user.JobPostalCode = model.JobPostalCode;
            user.JobPhoneNumber = model.JobPhoneNumberCode + "-" + model.JobPhoneNumberValue;
            user.BusinessSubCategoryId = model.BusinessSubCategoryId;

            await dbContext.SaveChangesAsync();

            return RedirectToAction("profileVerify", new { saved = true });
        }

        public async Task<IActionResult> ProfileVerify()
        {
            var user = await GetUserAsync(nameof(Framework.StorageModels.User.IdentityDocuments), nameof(Framework.StorageModels.User.IdentityDocuments) + "." + nameof(IdentityDocument.IdentityDocumentStatusHistories));

            var identityData = user.IdentityDocuments.OrderByDescending(f => f.CreateDate).Select(f => new
            {
                f.Type,
                f.FileUrl,
                LastStatus = f.IdentityDocumentStatusHistories.OrderByDescending(x => x.CreateDate).Select(x => new
                {
                    x.Status,
                    x.Description
                }).FirstOrDefault()
            }).ToList();

            return View(new VerifyModel
            {
                IsVerificationPictureAccepted = identityData.Where(f => f.Type == IdentityDocument.IdentityDocumentType.Verification).Select(x => x.LastStatus.Status).FirstOrDefault() == IdentityDocumentStatusHistory.StatusType.Accepted,
                VerificationPictureURL = identityData.Where(f => f.Type == IdentityDocument.IdentityDocumentType.Verification).Select(x => x.FileUrl).FirstOrDefault(),
                VerificationPictureRejectReson = identityData.Where(f => f.Type == IdentityDocument.IdentityDocumentType.Verification).Select(x => x.LastStatus.Status == IdentityDocumentStatusHistory.StatusType.Rejected ? x.LastStatus.Description : string.Empty).FirstOrDefault(),
                IsBirthCertificatePictureAccepted = identityData.Where(f => f.Type == IdentityDocument.IdentityDocumentType.BirthCertificate).Select(x => x.LastStatus.Status).FirstOrDefault() == IdentityDocumentStatusHistory.StatusType.Accepted,
                BirthCertificatePictureURL = identityData.Where(f => f.Type == IdentityDocument.IdentityDocumentType.BirthCertificate).Select(x => x.FileUrl).FirstOrDefault(),
                BirthCertificatePictureRejectReason = identityData.Where(f => f.Type == IdentityDocument.IdentityDocumentType.BirthCertificate).Select(x => x.LastStatus.Status == IdentityDocumentStatusHistory.StatusType.Rejected ? x.LastStatus.Description : string.Empty).FirstOrDefault(),
                IsNationalCardPictureAccepted = identityData.Where(f => f.Type == IdentityDocument.IdentityDocumentType.NationalCard).Select(x => x.LastStatus.Status).FirstOrDefault() == IdentityDocumentStatusHistory.StatusType.Accepted,
                NationalCardPictureURL = identityData.Where(f => f.Type == IdentityDocument.IdentityDocumentType.NationalCard).Select(x => x.FileUrl).FirstOrDefault(),
                NationalCardPictureRejectReason = identityData.Where(f => f.Type == IdentityDocument.IdentityDocumentType.NationalCard).Select(x => x.LastStatus.Status == IdentityDocumentStatusHistory.StatusType.Rejected ? x.LastStatus.Description : string.Empty).FirstOrDefault()
            });
        }

        public async Task<IActionResult> UploadIdentityDocument([FromServices] IConfiguration configuration, VerifyModel.IdentityDocumentType type, IFormFile file)
        {
            var path = await SaveUploadedFileIfExists(type.ToString(), configuration);

            if (!string.IsNullOrWhiteSpace(path))
            {
                var user = await GetUserAsync();

                user.IdentityDocuments.Add(new IdentityDocument
                {
                    FileUrl = path,
                    Type = (IdentityDocument.IdentityDocumentType)type,
                    IdentityDocumentStatusHistories = new List<IdentityDocumentStatusHistory> { new IdentityDocumentStatusHistory { UserId = user.Id, Status = IdentityDocumentStatusHistory.StatusType.Pending } }
                });

                await dbContext.SaveChangesAsync();
            }

            return Ok();
        }

        public async Task<IActionResult> ProfileLegal()
        {
            var user = athenticationProvider.GetUser();

            var data = await dbContext.LegalProfiles
                .Include(f => f.City)
                .Include(f => f.BusinessSubCategory)
                .Include(f => f.IdentityDocuments)
                .ThenInclude(f => f.IdentityDocumentStatusHistories)
                .FirstOrDefaultAsync(f => f.UserId == user.Id);

            var newsLetter = data?.IdentityDocuments.OrderByDescending(f => f.CreateDate).Where(f => f.Type == Framework.StorageModels.IdentityDocument.IdentityDocumentType.Newsletter).Select(f => new
            {
                f.FileUrl,
                LastStatus = f.IdentityDocumentStatusHistories.OrderByDescending(x => x.CreateDate).Select(x => new { x.Status, x.Description }).FirstOrDefault()
            }).FirstOrDefault();

            return View(new LegalProfileModel
            {
                BusinessCategoryId = data?.BusinessSubCategory?.BusinessCategoryId,
                BusinessSubCategoryId = data?.BusinessSubCategoryId,
                StateId = data?.City?.StateId,
                CityId = data?.CityId,
                CommertialName = data?.CommertialName,
                CompanyAddress = data?.CompanyAddress,
                CompanyName = data?.CompanyName,
                Description = data?.Description,
                LogoURL = data?.LogoURL,
                NatitonalCode = data?.NatitonalCode,
                PhoneNumberCode = ExceptionUtility.TryDo(() => data?.PhoneNumber?.Split("-")[0]),
                PhoneNumberValue = ExceptionUtility.TryDo(() => data?.PhoneNumber?.Split("-")[1]),
                RegisterDate = data?.RegisterDate,
                RegisterNumber = data?.RegisterNumber,
                WebSiteURL = data?.WebSiteURL,
                NewsleterPictureUrl = newsLetter != null ? newsLetter.FileUrl : string.Empty,
                IsNewsleterPictureAccepted = newsLetter != null && newsLetter.LastStatus.Status == Framework.StorageModels.IdentityDocumentStatusHistory.StatusType.Accepted,
                NewsleterPictureRejectReason = newsLetter != null ? newsLetter.LastStatus.Description : string.Empty,
                States = (await dbContext.States.ToListAsync()).ConvertAll(f => new LegalProfileModel.IdName { Id = f.Id, Name = f.Name }),
                SelectedStateCities = (data?.CityId).HasValue ? (await dbContext.Cities.Where(f => f.StateId == data.City.StateId).ToListAsync()).ConvertAll(f => new LegalProfileModel.IdName { Id = f.Id, Name = f.Name }) : new List<LegalProfileModel.IdName>(),
                BusinessCategories = (await dbContext.BusinessCategories.ToListAsync()).ConvertAll(f => new LegalProfileModel.IdName { Id = f.Id, Name = f.Title }),
                SelectedBusinessCategoryBusinessSubCategories = (data?.BusinessSubCategoryId).HasValue
                    ? (await dbContext.BusinessSubCategories.Where(f => f.BusinessCategoryId == data.BusinessSubCategory.BusinessCategoryId).ToListAsync()).ConvertAll(f => new LegalProfileModel.IdName { Id = f.Id, Name = f.Title })
                    : new List<LegalProfileModel.IdName>()
            });
        }

        [HttpPost]
        public async Task<IActionResult> ProfileLegal([FromServices] IConfiguration configuration, [FromForm] LegalProfileModel model, IFormFile logo, IFormFile identityNewsletter)
        {
            var user = athenticationProvider.GetUser();

            var legalProfile = await dbContext.LegalProfiles.FirstOrDefaultAsync(f => f.UserId == user.Id);

            if (legalProfile == null)
            {
                dbContext.LegalProfiles.Add(legalProfile = new LegalProfile { UserId = user.Id });
                await dbContext.SaveChangesAsync();
                legalProfile.Wallet = new Wallet { UserId = user.Id, Title = "حساب تیپول حقوقی", WalletCode = string.Concat(model.NatitonalCode.Reverse()), LegalProfileId = legalProfile.Id };
            }

            legalProfile.BusinessSubCategoryId = model.BusinessSubCategoryId;
            legalProfile.CityId = model.CityId;
            legalProfile.CommertialName = model.CommertialName;
            legalProfile.CompanyAddress = model.CompanyAddress;
            legalProfile.CompanyName = model.CompanyName;
            legalProfile.Description = model.Description;
            legalProfile.NatitonalCode = model.NatitonalCode;
            legalProfile.PhoneNumber = model.PhoneNumberCode + "-" + model.PhoneNumberValue;
            legalProfile.RegisterDate = model.RegisterDate.HasValue ? model.RegisterDate.Value.AddDays(1) : null;
            legalProfile.RegisterNumber = model.RegisterNumber;
            legalProfile.WebSiteURL = model.WebSiteURL?.ToLower().Trim();

            var logoPath = await SaveUploadedFileIfExists("LegalProfileLogo".ToString(), configuration, logo ?? new FormFile(null, 0, 0, string.Empty, string.Empty));

            if (!string.IsNullOrWhiteSpace(logoPath))
            {
                legalProfile.LogoURL = logoPath;
                legalProfile.LegalProfileLogoHistories.Add(new LegalProfileLogoHistory { LogoUrl = logoPath });
            }

            var identityNewsletterPath = await SaveUploadedFileIfExists(IdentityDocument.IdentityDocumentType.Newsletter.ToString(), configuration, identityNewsletter ?? new FormFile(null, 0, 0, string.Empty, string.Empty));

            if (!string.IsNullOrWhiteSpace(identityNewsletterPath))
            {
                legalProfile.IdentityDocuments.Add(new IdentityDocument
                {
                    Type = IdentityDocument.IdentityDocumentType.Newsletter,
                    FileUrl = identityNewsletterPath,
                    UserId = user.Id,
                    IdentityDocumentStatusHistories = new List<IdentityDocumentStatusHistory>
                    {
                        new IdentityDocumentStatusHistory
                        {
                            UserId = user.Id,
                            Status = IdentityDocumentStatusHistory.StatusType.Pending
                        }
                    }
                });
            }

            await dbContext.SaveChangesAsync();

            return RedirectToAction("bankAccount", new { saved = true });
        }

        public async Task<JsonResult> GetBusinessSubCategories(int BusinessCategoryId)
        {
            return Json(await dbContext.BusinessSubCategories.Where(f => f.BusinessCategoryId == BusinessCategoryId).Select(f => new { f.Id, Name = f.Title }).ToListAsync());
        }

        public async Task<JsonResult> GetCities(int stateid)
        {
            return Json(await dbContext.Cities.Where(f => f.StateId == stateid).Select(f => new { f.Id, f.Name }).ToListAsync());
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

        private async Task<User> GetUserAsync(params string[] includes)
        {
            var athenticatedUser = athenticationProvider.GetUser();

            var query = dbContext.Users.AsQueryable();

            if (includes != null && includes.Length > 0)
                foreach (var include in includes)
                    query = query.Include(include);

            return await query.FirstOrDefaultAsync(f => f.Id == athenticatedUser.Id);
        }

        #endregion

        public async Task<IActionResult> BankAccount()
        {
            var viewModel = new FormViewModel();

            var user = athenticationProvider.GetUser();

            var dbModel = await dbContext.BankAccounts.FirstOrDefaultAsync(f => f.UserId == user.Id);

            if (dbModel == null)
                dbModel = new BankAccount();

            viewModel.BankId = dbModel.BankId;
            viewModel.FullName = dbModel.FullName;
            viewModel.Iban = dbModel.Iban;
            viewModel.Id = dbModel.Id;
            viewModel.IsActive = dbModel.IsActive;
            viewModel.NationalCode = dbModel.NationalCode;
            viewModel.BirthDate = Tipoul.Framework.Utilities.Converters.DateConverter.ToShamsy(dbModel.Id == 0 ? DateTime.Now : dbModel.BirthDate);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> BankAccount([FromForm] FormViewModel model)
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

            return RedirectToAction("taxCode", new { saved = true });
        }

        public async Task<IActionResult> TaxCode()
        {
            var user = athenticationProvider.GetUser();

            var dbUser = await dbContext.Users.FirstOrDefaultAsync(f => f.Id == user.Id);

            return View(model: dbUser.TaxCode);
        }

        [HttpPost]
        public async Task<IActionResult> TaxCode(string taxCode)
        {
            var user = athenticationProvider.GetUser();

            var dbUser = await dbContext.Users.FirstOrDefaultAsync(f => f.Id == user.Id);

            dbUser.TaxCode = taxCode;

            await dbContext.SaveChangesAsync();

            VerificationHostedService.Register(dbUser.Id);

            return RedirectToAction("commertialGateWay", new { saved = true });
        }

        public IActionResult GetTaxCode()
        {
            TaxRegistrationHostedService.Register(athenticationProvider.GetUser().Id);

            return RedirectToAction("commertialGateWay", new { inprogress = true });
        }

        public async Task<IActionResult> CommertialGateWay()
        {
            var user = athenticationProvider.GetUser();

            var data = await dbContext.CommertialGateWays.Include(f => f.BusinessSubCategory).FirstOrDefaultAsync(f => f.Wallet.UserId == user.Id);

            if (data == null)
                data = new CommertialGateWay();

            return View(new CommertialGateWayModel
            {
                BusinessCategoryId = data.BusinessSubCategory?.BusinessCategoryId ?? 0,
                BusinessSubCategoryId = data.BusinessSubCategoryId,
                Description = data.Description,
                Id = data.Id,
                LogoUrl = data.LogoUrl,
                Settlement = (CommertialGateWayModel.SettlementType)data.Settlement,
                SettlementPeriod = (CommertialGateWayModel.SettlementPeriodType)data.SettlementPeriod,
                SupportPhoneNumberCode = ExceptionUtility.TryDo(() => data.SupportPhoneNumber?.Split("-")[0]),
                SupportPhoneNumberValue = ExceptionUtility.TryDo(() => data.SupportPhoneNumber?.Split("-")[1]),
                Title = data.Title,
                Token = data.Token,
                //HasETrust = data.HasETrust,
                //ETrustStarsCount = data.ETrustStarsCount,
                WageSide = (CommertialGateWayModel.WagePayerSide)data.WageSide,
                WalletId = data.WalletId,
                WebSiteURL = data.WebSiteURL,
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
        public async Task<IActionResult> CommertialGateWay([FromServices] IConfiguration configuration, [FromForm] CommertialGateWayModel model)
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
                dbContext.CommertialGateWays.Add(dbModel);

            if (dbModel.Id == 0 || dbContext.Entry(dbModel).State == EntityState.Modified)
                CommertialGateWayRegistrationHostedService.Register(athenticationProvider.GetUser().Id);

            await dbContext.SaveChangesAsync();

            return Redirect("/");
        }
    }
}
