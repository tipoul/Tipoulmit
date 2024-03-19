using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Tipoul.Framework.StorageModels
{
    public class IdentityDocument
    {
        public IdentityDocument()
        {
            CreateDate = DateTime.Now;
            IdentityDocumentStatusHistories = new List<IdentityDocumentStatusHistory>();
        }

        public int Id { get; set; }

        public string FileUrl { get; set; }

        public IdentityDocumentType Type { get; set; }

        public int? UserId { get; set; }

        public int? LegalProfileId { get; set; }

        public DateTime CreateDate { get; set; }

        public User User { get; set; }

        public LegalProfile LegalProfile { get; set; }

        public List<IdentityDocumentStatusHistory> IdentityDocumentStatusHistories { get; set; }

        public enum IdentityDocumentType
        {
            Newsletter = 1,
            NationalCard = 2,
            BirthCertificate = 3,
            Verification = 4
        }

        public static string GetIdentityDocumentTypeName(IdentityDocumentType identityDocumentType)
        {
            switch (identityDocumentType)
            {
                case IdentityDocumentType.Newsletter:
                    return "روزنامه رسمی";
                case IdentityDocumentType.NationalCard:
                    return "کارت ملی";
                case IdentityDocumentType.BirthCertificate:
                    return "شناسنامه";
                case IdentityDocumentType.Verification:
                    return "اعتبار سنجی";
                default:
                    throw new InvalidEnumArgumentException(nameof(identityDocumentType));
            }
        }
    }
}
