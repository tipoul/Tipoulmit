using System.Collections.Generic;

namespace Tipoul.Framework.Services.Shaparak.Models
{
    public class ShaparakRequestResult
    {
        public string TrackingNumber { get; set; }

        public string TrackingNumberPsp { get; set; }

        public string ServiceRequestType { get; set; }

        public string ServiceRequestStatus { get; set; }

        public bool Success { get; set; }

        public int RequestLogId { get; set; }

        public List<ShaparakError> RequestRejectionReasons { get; set; }
    }
}
