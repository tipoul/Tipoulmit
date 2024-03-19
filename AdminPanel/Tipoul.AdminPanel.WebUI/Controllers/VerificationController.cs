using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Tipoul.AdminPanel.WebUI.Controllers.Abstraction;
using Tipoul.AdminPanel.WebUI.Models.Verification;
using Tipoul.Athentication.Agent.Services;
using Tipoul.Framework.DataAccessLayer;
using Tipoul.Framework.StorageModels;

namespace Tipoul.AdminPanel.WebUI.Controllers
{
    public class VerificationController : TipoulBaseController<IdentityDocument, VerificationListViewModel, VerificationFormViewModel>
    {
        public VerificationController(TipoulFrameworkDbContext dbContext, AthenticationProvider athenticationProvider) : base(dbContext, athenticationProvider)
        {
        }

        protected override async Task<VerificationFormViewModel> GetItemAsync([FromRoute(Name = "Id")] int? userId)
        {
            if (userId.HasValue)
                return new VerificationFormViewModel(userId ?? throw new InvalidDataException(nameof(userId)), await dbContext.IdentityDocuments.Include(f => f.IdentityDocumentStatusHistories).Where(f => f.UserId == userId).ToListAsync());
            else
                return new VerificationFormViewModel();
        }

        protected override async Task<VerificationListViewModel> GetListAsync(int pageNumber)
        {
            var query = dbContext.IdentityDocuments.Include(f => f.IdentityDocumentStatusHistories).Include(f => f.User).Include(f => f.LegalProfile).OrderByDescending(f => f.Id).AsQueryable();

            var count = await query.CountAsync();

            var data = await SkipTake(query, pageNumber).ToListAsync();

            return new VerificationListViewModel(count, pageNumber, data.ConvertAll(item => new VerificationListItemViewModel(item)));
        }

        protected override async Task SaveItemAsync([FromServices] IConfiguration configuration, VerificationFormViewModel model)
        {
            if (TrySaveUploadedFileIfExists(configuration, IdentityDocument.IdentityDocumentType.Verification.ToString(), nameof(model.Verification), out string verificationPath))
                dbContext.IdentityDocuments.Add(new IdentityDocument
                {
                    FileUrl = verificationPath,
                    Type = IdentityDocument.IdentityDocumentType.Verification,
                    UserId = model.Id,
                    IdentityDocumentStatusHistories = new List<IdentityDocumentStatusHistory>
                    {
                        new IdentityDocumentStatusHistory { UserId = athenticationProvider.GetUser().Id, Status = IdentityDocumentStatusHistory.StatusType.Pending }
                    }
                });

            if (TrySaveUploadedFileIfExists(configuration, IdentityDocument.IdentityDocumentType.BirthCertificate.ToString(), nameof(model.BirthCertificate), out string birthCertificatePath))
                dbContext.IdentityDocuments.Add(new IdentityDocument
                {
                    FileUrl = birthCertificatePath,
                    Type = IdentityDocument.IdentityDocumentType.BirthCertificate,
                    UserId = model.Id,
                    IdentityDocumentStatusHistories = new List<IdentityDocumentStatusHistory>
                    {
                        new IdentityDocumentStatusHistory { UserId = athenticationProvider.GetUser().Id, Status = IdentityDocumentStatusHistory.StatusType.Pending }
                    }
                });

            if (TrySaveUploadedFileIfExists(configuration, IdentityDocument.IdentityDocumentType.NationalCard.ToString(), nameof(model.NationalCard), out string nationalCardPath))
                dbContext.IdentityDocuments.Add(new IdentityDocument
                {
                    FileUrl = nationalCardPath,
                    Type = IdentityDocument.IdentityDocumentType.NationalCard,
                    UserId = model.Id,
                    IdentityDocumentStatusHistories = new List<IdentityDocumentStatusHistory>
                    {
                        new IdentityDocumentStatusHistory { UserId = athenticationProvider.GetUser().Id, Status = IdentityDocumentStatusHistory.StatusType.Pending }
                    }
                });

            if (TrySaveUploadedFileIfExists(configuration, IdentityDocument.IdentityDocumentType.Newsletter.ToString(), nameof(model.NewsLetter), out string newsletterPath))
                dbContext.IdentityDocuments.Add(new IdentityDocument
                {
                    FileUrl = newsletterPath,
                    Type = IdentityDocument.IdentityDocumentType.Newsletter,
                    UserId = model.Id,
                    IdentityDocumentStatusHistories = new List<IdentityDocumentStatusHistory>
                    {
                        new IdentityDocumentStatusHistory { UserId = athenticationProvider.GetUser().Id, Status = IdentityDocumentStatusHistory.StatusType.Pending }
                    }
                });

            await dbContext.SaveChangesAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Confirm(IdentityDocument.IdentityDocumentType type, int userId)
        {
            var identityDocument = await dbContext.IdentityDocuments.Where(f => f.UserId == userId && f.Type == type).OrderByDescending(f => f.CreateDate).FirstOrDefaultAsync();

            identityDocument.IdentityDocumentStatusHistories.Add(new IdentityDocumentStatusHistory
            {
                UserId = userId,
                Status = IdentityDocumentStatusHistory.StatusType.Accepted
            });

            await dbContext.SaveChangesAsync();

            return Success(new
            {
                type,
                userId
            });
        }

        [HttpPost]
        public async Task<IActionResult> Reject(IdentityDocument.IdentityDocumentType type, int userId, string description)
        {
            var identityDocument = await dbContext.IdentityDocuments.Where(f => f.UserId == userId && f.Type == type).OrderByDescending(f => f.CreateDate).FirstOrDefaultAsync();

            identityDocument.IdentityDocumentStatusHistories.Add(new IdentityDocumentStatusHistory
            {
                UserId = userId,
                Description = description,
                Status = IdentityDocumentStatusHistory.StatusType.Rejected
            });

            await dbContext.SaveChangesAsync();

            return Success();
        }

        protected override void DoDelete(IdentityDocument item)
        {
            //item.IdentityDocumentStatusHistories.Add()
        }
    }
}
