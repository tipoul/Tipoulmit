using System.Collections.Generic;

namespace Tipoul.Framework.Services.Shaparak.Models
{
    public class ShaparakStatusReportResult
    {
        public string TrackingNumber { get; set; }

        public string TrackingNumberPsp { get; set; }

        public Enums.Status Status { get; set; }

        public long RequestDate { get; set; }

        public string Description { get; set; }

        public Enums.ShaparakRequestType RequestType { get; set; }

        public ShaparakMerchantModel Merchant { get; set; }

        public List<ShaparakMerchantRelatedModel> RelatedMerchants { get; set; }

        public List<ShaparakError> RequestRejectionReasons { get; set; }
    }
}
