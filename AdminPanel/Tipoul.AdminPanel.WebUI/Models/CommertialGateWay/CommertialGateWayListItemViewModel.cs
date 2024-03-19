using Tipoul.AdminPanel.WebUI.Infrastructure.Builder.Abstraction;
using Tipoul.Framework.StorageModels;

namespace Tipoul.AdminPanel.WebUI.Models.CommertialGateWay
{
    [Title("درگاه های تجاری")]
    public class CommertialGateWayListItemViewModel
    {
        public CommertialGateWayListItemViewModel(Framework.StorageModels.CommertialGateWay model)
        {
            Id = model.Id;
            Title = model.Title;
            WebSiteURL = model.WebSiteURL;
            SupportPhoneNumber = model.SupportPhoneNumber;
        }

        public int Id { get; set; }

        [HeaderTitle("عنوان")]
        public string Title { get; set; }

        [HeaderTitle("آدرس وبسایت")]
        public string WebSiteURL { get; set; }

        [HeaderTitle("شماره پشتیبانی")]
        public string SupportPhoneNumber { get; set; }
    }
}