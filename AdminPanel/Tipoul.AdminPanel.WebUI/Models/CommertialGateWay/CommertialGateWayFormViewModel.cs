
using System.Collections.Generic;
using System.Linq;

using Tipoul.AdminPanel.WebUI.Infrastructure.Builder;
using Tipoul.AdminPanel.WebUI.Infrastructure.Builder.Abstraction;

namespace Tipoul.AdminPanel.WebUI.Models.CommertialGateWay
{
    [Title("درگاه تجاری")]
    public class CommertialGateWayFormViewModel : FormViewModel
    {
        public CommertialGateWayFormViewModel(Framework.StorageModels.CommertialGateWay model)
        {
            Id = model.Id;
            Title = model.Title;
            WebSiteURL = model.WebSiteURL;
            SupportPhoneNumber = model.SupportPhoneNumber;
            LogoUrl = model.LogoUrl;
            Description = model.Description;
            WageSide = (WagePayerSide)model.WageSide;
            Settlement = (SettlementType)model.Settlement;
            BusinessSubCategoryId = model.BusinessSubCategoryId;
        }

        public CommertialGateWayFormViewModel()
        {
        }

        [Label("عنوان")]
        public string Title { get; set; }

        [Label("آدرس وبسایت")]
        public string WebSiteURL { get; set; }

        [Label("شماره تماس پشتیبانی")]
        public string SupportPhoneNumber { get; set; }

        [Label("لوگو")]
        public string? LogoUrl { get; set; }

        [Label("توضیحات")]
        public string? Description { get; set; }

        [Label("کسر کارمزد")]
        public WagePayerSide WageSide { get; set; }


        [Label("تسویه")]
        public SettlementType Settlement { get; set; }

        [Label("صنف")]
        [Partial("formComponents/business")]
        public int BusinessSubCategoryId { get; set; }

        public enum SettlementType
        {
            Automatic = 1,
            FromWallet = 2
        }

        public enum WagePayerSide
        {
            FromMe = 1,
            FromPayer = 2
        }

        public static Dictionary<int, string> GetSettlementValues()
        {
            return Framework.StorageModels.CommertialGateWay.GetAllSettlementTypes().ToDictionary(settlementType => (int)settlementType, settlementType => Framework.StorageModels.CommertialGateWay.GetSettlementName(settlementType));
        }

        public static Dictionary<int, string> GetWageSideValues()
        {
            return Framework.StorageModels.CommertialGateWay.GetAllWagePayerSides().ToDictionary(wageSideType => (int)wageSideType, wageSidetype => Framework.StorageModels.CommertialGateWay.GetWagePayerSideName(wageSidetype));
        }
    }
}