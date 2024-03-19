using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

using Tipoul.AdminPanel.WebUI.Controllers.Abstraction;
using Tipoul.AdminPanel.WebUI.Models.User;
using Tipoul.Athentication.Agent.Services;
using Tipoul.Framework.DataAccessLayer;
using Tipoul.Framework.StorageModels;

namespace Tipoul.AdminPanel.WebUI.Controllers
{
    public class UserController : TipoulBaseController<User, UserListViewModel, UserFormViewModel>
    {
        public UserController(TipoulFrameworkDbContext dbContext, AthenticationProvider athenticationProvider) : base(dbContext, athenticationProvider)
        {
        }

        protected override async Task<UserFormViewModel> GetItemAsync(int? id)
        {
            if (id.HasValue)
                return new UserFormViewModel(await dbContext.Users
                    .Include(f => f.IdentityDocuments)
                    .Include(f => f.LegalProfile).ThenInclude(f => f.IdentityDocuments)
                    .FirstOrDefaultAsync(f => f.Id == id.Value));
            else
                return new UserFormViewModel();
        }

        protected override async Task<UserListViewModel> GetListAsync(int pageNumber)
        {
            var query = dbContext.Users
                .Where(f => f.Type == Framework.StorageModels.User.UserType.UserPanel)
                .OrderByDescending(f => f.Id)
                .AsQueryable();

            var count = await query.CountAsync();

            var data = await SkipTake(query, pageNumber).ToListAsync();

            return new UserListViewModel(count, pageNumber, data.ConvertAll(item => new UserListItemViewModel(item)));
        }

        protected override async Task SaveItemAsync([FromServices] IConfiguration configuration, UserFormViewModel model)
        {
            var dbModel = model.Id == 0 ? new User() : await dbContext.Users.Include(f => f.LegalProfile).FirstOrDefaultAsync(f => f.Id == model.Id);

            if (!string.IsNullOrWhiteSpace(model.FirstName))
            {
                var newAvatarPath = await TrySaveUploadedFileIfExists(configuration, "avatars", nameof(model.AvatarURL));

                dbModel.Address = model.Address;
                dbModel.AvatarURL = newAvatarPath ?? model.AvatarURL;
                dbModel.BirthDate = model.BirthDate;
                dbModel.BusinessSubCategoryId = model.BusinessSubCategoryId;
                dbModel.CityId = model.CityId;
                dbModel.Email = model.Email;
                dbModel.EmailConfirmed = model.EmailConfirmed;
                dbModel.FatherName = model.FatherName;
                dbModel.FirstName = model.FirstName;
                //dbModel.IdentityDocuments = null;//
                dbModel.JobAddress = model.BusinessAddress;
                dbModel.JobCityId = model.BusinessCityId;
                dbModel.JobPhoneNumber = model.BusinessPhoneNumber;
                dbModel.JobPostalCode = model.BusinessPostalCode;
                dbModel.LastName = model.LastName;
                dbModel.MobileNumber = model.MobileNumber;
                dbModel.MobileNumberConfirmed = model.MobileNumberConfirmed;
                dbModel.NationalCode = model.NationalCode;
                dbModel.PhoneNumber = model.PhoneNumber;
                dbModel.PostalCode = model.BusinessPostalCode;
                dbModel.TaxCode = model.TaxCode;
                dbModel.QuickSettlement = model.QuickSettlement;
                
                if (TrySaveUploadedFileIfExists(configuration, IdentityDocument.IdentityDocumentType.NationalCard.ToString(), nameof(model.NationalCardPicture), out string nationalCardPicture))
                    dbModel.IdentityDocuments.Add(new IdentityDocument
                    {
                        Type = IdentityDocument.IdentityDocumentType.NationalCard,
                        FileUrl = nationalCardPicture,
                        IdentityDocumentStatusHistories = new List<IdentityDocumentStatusHistory> { new IdentityDocumentStatusHistory { UserId = athenticationProvider.GetUser().Id, Status = IdentityDocumentStatusHistory.StatusType.Pending } }
                    });

                if (TrySaveUploadedFileIfExists(configuration, IdentityDocument.IdentityDocumentType.BirthCertificate.ToString(), nameof(model.BirthCertificatePicture), out string birthCertificate))
                    dbModel.IdentityDocuments.Add(new IdentityDocument
                    {
                        Type = IdentityDocument.IdentityDocumentType.BirthCertificate,
                        FileUrl = birthCertificate,
                        IdentityDocumentStatusHistories = new List<IdentityDocumentStatusHistory> { new IdentityDocumentStatusHistory { UserId = athenticationProvider.GetUser().Id, Status = IdentityDocumentStatusHistory.StatusType.Pending } }
                    });

                if (TrySaveUploadedFileIfExists(configuration, IdentityDocument.IdentityDocumentType.Verification.ToString(), nameof(model.ApprovalPicture), out string verification))
                    dbModel.IdentityDocuments.Add(new IdentityDocument
                    {
                        Type = IdentityDocument.IdentityDocumentType.Verification,
                        FileUrl = verification,
                        IdentityDocumentStatusHistories = new List<IdentityDocumentStatusHistory> { new IdentityDocumentStatusHistory { UserId = athenticationProvider.GetUser().Id, Status = IdentityDocumentStatusHistory.StatusType.Pending } }
                    });

                if (!string.IsNullOrWhiteSpace(newAvatarPath))
                    dbModel.UserAvatarHistories.Add(new UserAvatarHistory { AvatarURL = newAvatarPath });
            }


            if (!string.IsNullOrWhiteSpace(model.CompanyName))
            {
                if (dbModel.LegalProfile == null)
                    dbModel.LegalProfile = new LegalProfile
                    {
                        Wallet = new Wallet { UserId = dbModel.Id, Title = "حساب تیپول حقوقی", WalletCode = string.Concat(model.NatitonalCode.Reverse()) }
                    };

                dbModel.LegalProfile.BusinessSubCategoryId = model.LegalBusinessBusinessSubCategoryId;
                dbModel.LegalProfile.CityId = model.LegalBusinessAddressCityId;
                dbModel.LegalProfile.CommertialName = model.CommertialName;
                dbModel.LegalProfile.CompanyAddress = model.LegalBusinessAddressAddress;
                dbModel.LegalProfile.CompanyName = model.CompanyName;
                dbModel.LegalProfile.Description = model.Description;
                dbModel.LegalProfile.NatitonalCode = model.NationalCode;
                dbModel.LegalProfile.PhoneNumber = model.LegalInfoPhoneNumber;
                dbModel.LegalProfile.RegisterDate = model.RegisterDate;
                dbModel.LegalProfile.RegisterNumber = model.RegisterNumber;
                dbModel.LegalProfile.WebSiteURL = model.WebSiteURL;
                dbModel.LegalProfile.TaxCode = model.TaxCode;

                if (TrySaveUploadedFileIfExists(configuration, IdentityDocument.IdentityDocumentType.Newsletter.ToString(), nameof(model.NewsLetterPicture), out string newsletterPath))
                    dbModel.IdentityDocuments.Add(new IdentityDocument
                    {
                        FileUrl = newsletterPath,
                        Type = IdentityDocument.IdentityDocumentType.Newsletter,
                        IdentityDocumentStatusHistories = new List<IdentityDocumentStatusHistory> { new IdentityDocumentStatusHistory { UserId = athenticationProvider.GetUser().Id, Status = IdentityDocumentStatusHistory.StatusType.Pending } }
                    });

                if (TrySaveUploadedFileIfExists(configuration, "LegalProfileLogo", nameof(model.LogoURL), out string logoPath))
                {
                    dbModel.LegalProfile.LogoURL = logoPath;
                    dbModel.LegalProfile.LegalProfileLogoHistories.Add(new LegalProfileLogoHistory
                    {
                        LogoUrl = logoPath
                    });
                }
            }

            if (dbModel.Id == 0)
                await dbContext.Users.AddAsync(dbModel);

            await dbContext.SaveChangesAsync();
        }

        protected override void DoDelete(User item)
        {
            item.Trashed = true;
        }
    }
}
