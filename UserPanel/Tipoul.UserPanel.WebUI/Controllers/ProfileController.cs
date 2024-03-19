using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

using Tipoul.Athentication.Agent.Services;
using Tipoul.Framework.DataAccessLayer;
using Tipoul.Framework.StorageModels;
using Tipoul.Framework.Utilities.Utilities;
using Tipoul.UserPanel.WebUI.Models.Profile;

namespace Tipoul.UserPanel.WebUI.Controllers
{
    public class ProfileController : Controller
    {
        private readonly AthenticationProvider athenticationProvider;

        private readonly TipoulFrameworkDbContext dbContext;

        public ProfileController(AthenticationProvider athenticationProvider, TipoulFrameworkDbContext dbContext)
        {
            this.athenticationProvider = athenticationProvider;
            this.dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
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
                NationalCode = user.NationalCode,
                TaxCode = user.TaxCode
            });
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromServices] IConfiguration configuration, [FromForm] PersonalInfoModel model)
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

            return RedirectToAction("index");
        }

        public async Task<IActionResult> Address()
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
        public async Task<IActionResult> Address([FromForm] AddressModel model)
        {
            var user = await GetUserAsync();

            user.Address = model.Address;
            user.PostalCode = model.PostalCode;
            user.CityId = model.CityId;
            user.PhoneNumber = model.PhoneNumberCode + "-" + model.PhoneNumberValue;

            await dbContext.SaveChangesAsync();

            return RedirectToAction("address");
        }

        public async Task<IActionResult> Business()
        {
            var user = await GetUserAsync(nameof(Framework.StorageModels.User.JobCity), nameof(Framework.StorageModels.User.BusinessSubCategory));

            return View(new BusinessModel
            {
                BusinessCategoryId = user.BusinessSubCategory?.BusinessCategoryId,
                BusinessSubCategoryId = user.BusinessSubCategoryId,
                JobAddress = user.JobAddress,
                JobStateId = user.JobCity?.StateId,
                JobCityId = user.JobCityId,
                JobPhoneNumber = user.JobPhoneNumber,
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
        public async Task<IActionResult> Business([FromForm] BusinessModel model)
        {
            var user = await GetUserAsync();

            user.JobAddress = model.JobAddress;
            user.JobCityId = model.JobCityId;
            user.JobPostalCode = model.JobPostalCode;
            user.JobPhoneNumber = model.JobPhoneNumber;
            user.BusinessSubCategoryId = model.BusinessSubCategoryId;

            await dbContext.SaveChangesAsync();

            return RedirectToAction("business");
        }

        public async Task<IActionResult> Verify()
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

        public async Task<IActionResult> Legal()
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
                PhoneNumber = data?.PhoneNumber,
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
        public async Task<IActionResult> Legal([FromServices] IConfiguration configuration, [FromForm] LegalProfileModel model, IFormFile logo, IFormFile identityNewsletter)
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
            legalProfile.PhoneNumber = model.PhoneNumber;
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

            return RedirectToAction("legal");
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
    }
}
