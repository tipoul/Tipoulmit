using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tipoul.PersonalGateWay.WebUI.ViewModels
{
    public class CallBackViewModel
    {
        public string Title { get; set; }

        public string LogoUrl { get; set; }

        public bool Success { get; set; }

        public string PayerName { get; set; }

        public long Amount { get; set; }

        public string? CardNumber { get; set; }

        public string? IssuerBank { get; set; }

        public string RRN { get; set; }

        public string? DatePaid { get; set; }

        public long TraceNumber { get; set; }

        public string? FactorNumber { get; set; }

        public int RespCode { get; set; }

        public string? RespMsg { get; set; }

        public string TipoulTrackNumber { get; set; }

        public string TipoulTraceNumber { get; set; }

        public string ReturnId { get; set; }
    }
}
