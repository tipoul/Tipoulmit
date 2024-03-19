using System.Collections.Generic;

namespace Tipoul.Framework.Services.Sepehr.Models
{
    public class RequestModel
    {
        public string MerchantNumber { get; set; }

        public List<string> Ips { get; set; }

        public string WebSiteName { get; set; }

        public string WebSiteUrl { get; set; }

        public string SubBusinessCategoryCode { get; set; }

        public string Base64Img { get; set; }

        public bool IsAllow { get; set; }

        public PaymentType PayType { get; set; }

        public bool FetchPanEnable { get; set; }

        public enum PaymentType
        {
            Web = 0,
            Mobile = 1
        }
    }
}
