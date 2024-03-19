using System;
using System.Collections.Generic;

namespace Tipoul.Framework.StorageModels
{
    public class LegalProfile
    {
        public LegalProfile()
        {
            CreateDate = DateTime.Now;
            IdentityDocuments = new List<IdentityDocument>();
            LegalProfileLogoHistories = new List<LegalProfileLogoHistory>();
        }

        public int Id { get; set; }

        public int UserId { get; set; }

        public string? CompanyName { get; set; }

        public string? CommertialName { get; set; }

        public int? CityId { get; set; }

        public int? BusinessSubCategoryId { get; set; }

        public string? CompanyAddress { get; set; }

        public string? WebSiteURL { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Description { get; set; }

        public string? NatitonalCode { get; set; }

        public string? RegisterNumber { get; set; }

        public string? LogoURL { get; set; }

        public int? WalletId { get; set; }

        public string? TaxCode { get; set; }

        public DateTime? RegisterDate { get; set; }

        public DateTime CreateDate { get; set; }

        public City City { get; set; }

        public User User { get; set; }

        public BusinessSubCategory BusinessSubCategory { get; set; }

        public Wallet Wallet { get; set; }

        public List<IdentityDocument> IdentityDocuments { get; set; }

        public List<LegalProfileLogoHistory> LegalProfileLogoHistories { get; set; }
    }
}
