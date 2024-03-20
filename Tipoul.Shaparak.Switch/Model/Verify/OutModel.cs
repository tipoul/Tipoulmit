using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Shaparak.Switch.Model.Verify
{
    public class IranKishOutModel
    {

        public string TerminalId { get; set; }
        public string RetrievalReferenceNumber { get; set; }
        public string SystemTraceAuditNumber { get; set; }
        public string TokenIdentity { get; set; }

    }
    public class BehPardakhtOutModel
    {
        public long terminalId { get; set; }
        public string userName { get; set; }
        public string userPassword { get; set; }
        public long orderId { get; set; }
        public long saleOrderId { get; set; }
        public long saleReferenceId { get; set; }
    }
    public class SepehrOutModel
    {
        public string digitalreceipt { get; set; }
        public long terminalId { get; set; }
    }
}
