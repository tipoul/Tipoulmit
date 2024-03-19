using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tipoul.UserPanel.WebUI.Models.CommertialGateWay
{
    public class CommertialGateWayModel
    {
        public CommertialGateWayModel()
        {
            BusinessCategories = new List<IdName>();
            BusinessSelectedCategorySubCategories = new List<IdName>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string WebSiteURL { get; set; }

        public string SupportPhoneNumberCode { get; set; }

        public string SupportPhoneNumberValue { get; set; }

        public string? LogoUrl { get; set; }

        public string? Description { get; set; }

        public string Token { get; set; }

        public WagePayerSide WageSide { get; set; }

        public SettlementType Settlement { get; set; }

        public SettlementPeriodType SettlementPeriod { get; set; }

        public int? SettlementBankId { get; set; }

        public int BusinessCategoryId { get; set; }

        public int BusinessSubCategoryId { get; set; }

        public int WalletId { get; set; }

        public bool HasETrust { get; set; }

        public int? ETrustStarsCount { get; set; }

        public List<IdName> BusinessCategories { get; set; }

        public List<IdName> BusinessSelectedCategorySubCategories { get; set; }

        public List<IdName> Wallets { get; set; }

        public List<IdName> Banks { get; set; }

        public enum SettlementType
        {
            Automatic = 1,
            Manual = 2
        }

        public enum SettlementPeriodType
        {
            Daily = 1,
            ThreeDays = 3,
            Weekly = 7,
            FiftheenDays = 15,
            Monthly = 30
        }

        public enum WagePayerSide
        {
            FromMe = 1,
            FromPayer = 2
        }

        public class IdName
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }
    }
}
