using System.Collections.Generic;
using System.IO;
using System.Linq;

using Tipoul.AdminPanel.WebUI.Infrastructure.Builder;
using Tipoul.AdminPanel.WebUI.Infrastructure.Builder.Abstraction;
using Tipoul.Framework.StorageModels;

namespace Tipoul.AdminPanel.WebUI.Models.Verification
{
    [Title("احراز هویت")]
    public class VerificationFormViewModel : FormViewModel
    {

        public VerificationFormViewModel(int userId, List<IdentityDocument> identityDocuments)
        {
            Id = userId;
            Verification = identityDocuments.Where(f => f.Type == IdentityDocument.IdentityDocumentType.Verification).OrderByDescending(f => f.CreateDate).Select(f => f.FileUrl).FirstOrDefault();
            VerificationStatus = identityDocuments.Where(f => f.Type == IdentityDocument.IdentityDocumentType.Verification).OrderByDescending(f => f.CreateDate)
                .Select(f => f.IdentityDocumentStatusHistories.OrderByDescending(x => x.CreateDate).Select(x => x.Status).FirstOrDefault()).FirstOrDefault().ToString();
            BirthCertificate = identityDocuments.Where(f => f.Type == IdentityDocument.IdentityDocumentType.BirthCertificate).OrderByDescending(f => f.CreateDate).Select(f => f.FileUrl).FirstOrDefault();
            BirthCertificateStatus = identityDocuments.Where(f => f.Type == IdentityDocument.IdentityDocumentType.BirthCertificate).OrderByDescending(f => f.CreateDate)
                .Select(f => f.IdentityDocumentStatusHistories.OrderByDescending(x => x.CreateDate).Select(x => x.Status).FirstOrDefault()).FirstOrDefault().ToString();
            NationalCard = identityDocuments.Where(f => f.Type == IdentityDocument.IdentityDocumentType.NationalCard).OrderByDescending(f => f.CreateDate).Select(f => f.FileUrl).FirstOrDefault();
            NationalCardStatus = identityDocuments.Where(f => f.Type == IdentityDocument.IdentityDocumentType.NationalCard).OrderByDescending(f => f.CreateDate)
                .Select(f => f.IdentityDocumentStatusHistories.OrderByDescending(x => x.CreateDate).Select(x => x.Status).FirstOrDefault()).FirstOrDefault().ToString();
            NewsLetter = identityDocuments.Where(f => f.Type == IdentityDocument.IdentityDocumentType.Newsletter).OrderByDescending(f => f.CreateDate).Select(f => f.FileUrl).FirstOrDefault();
            NewsLetterStatus = identityDocuments.Where(f => f.Type == IdentityDocument.IdentityDocumentType.Newsletter).OrderByDescending(f => f.CreateDate)
                .Select(f => f.IdentityDocumentStatusHistories.OrderByDescending(x => x.CreateDate).Select(x => x.Status).FirstOrDefault()).FirstOrDefault().ToString();
        }

        public VerificationFormViewModel()
        {
        }

        [File]
        [Label("اعتبار سنجی")]
        [HasButton("Confirm(4, {id}, '{uniqeId}')", "تأیید", "success", DataKey = "type", DataValue = "Verification")]
        [HasButton("Reject(4, {id}, '{uniqeId}')", "عدم تأیید", "danger", DataKey = "type", DataValue = "Verification")]
        public string Verification { get; set; }

        [Hidden]
        public string VerificationStatus { get; set; }

        [File]
        [Label("شناسنامه")]
        [HasButton("Confirm(3, {id}, '{uniqeId}')", "تأیید", "success", DataKey = "type", DataValue = "BirthCertificate")]
        [HasButton("Reject(3, {id}, '{uniqeId}')", "عدم تأیید", "danger", DataKey = "type", DataValue = "BirthCertificate")]
        public string BirthCertificate { get; set; }

        [Hidden]
        public string BirthCertificateStatus { get; set; }

        [File]
        [Label("کارت ملی")]
        [HasButton("Confirm(2, {id}, '{uniqeId}')", "تأیید", "success", DataKey = "type", DataValue = "NationalCard")]
        [HasButton("Reject(2, {id}, '{uniqeId}')", "عدم تأیید", "danger", DataKey = "type", DataValue = "NationalCard")]
        public string NationalCard { get; set; }

        [Hidden]
        public string NationalCardStatus { get; set; }

        [File]
        [Label("روزنامه رسمی")]
        [HasButton("Confirm(1, {id}, '{uniqeId}')", "تأیید", "success", DataKey = "type", DataValue = "NewsLetter")]
        [HasButton("Reject(1, {id}, '{uniqeId}')", "عدم تأیید", "danger", DataKey = "type", DataValue = "NewsLetter")]
        public string NewsLetter { get; set; }

        [Hidden]
        public string NewsLetterStatus { get; set; }
    }
}
