using System;
using System.IO;
using System.Linq;

using Tipoul.AdminPanel.WebUI.Infrastructure.Builder.Abstraction;
using Tipoul.Framework.StorageModels;

namespace Tipoul.AdminPanel.WebUI.Models.Verification
{
    [Title("احراز هویت")]
    public class VerificationListItemViewModel
    {
        public VerificationListItemViewModel(IdentityDocument item)
        {
            Id = item.UserId ?? throw new InvalidDataException(nameof(item.UserId));
            UserFullName = item.User?.FirstName + " " + item.User?.LastName;
            LegalProfileCompanyName = item.LegalProfile?.CompanyName;
            Type = IdentityDocument.GetIdentityDocumentTypeName(item.Type);
            Status = IdentityDocumentStatusHistory.GetStatusTypeName(item.IdentityDocumentStatusHistories.OrderByDescending(f => f.CreateDate).Select(f => f.Status).FirstOrDefault());
            CreateDate = item.CreateDate;
        }

        public VerificationListItemViewModel()
        {
        }

        public int Id { get; set; }

        [HeaderTitle("نام کاربر")]
        public string UserFullName { get; set; }

        [HeaderTitle("نام شرکت")]
        public string LegalProfileCompanyName { get; set; }

        [HeaderTitle("نوع")]
        public string Type { get; set; }

        [HeaderTitle("وضعیت")]
        public string Status { get; set; }

        [HeaderTitle("تاریخ ثبت")]
        public DateTime CreateDate { get; set; }
    }
}
