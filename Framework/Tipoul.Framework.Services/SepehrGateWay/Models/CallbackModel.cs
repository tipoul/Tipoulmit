using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Framework.Services.SepehrGateWay.Models
{
    public class CallbackModel
    {
        public int RespCode { get; set; }

        public string RespMsg { get; set; }

        public long Amount { get; set; }

        public string InvoiceId { get; set; }

        public string Payload { get; set; }

        public long TerminalId { get; set; }

        public long TraceNumber { get; set; }

        public long RRN { get; set; }

        public string DatePaid { get; set; }

        public string DigitalReceipt { get; set; }

        public string IssuerBank { get; set; }

        public string CardNumber { get; set; }
    }
}
