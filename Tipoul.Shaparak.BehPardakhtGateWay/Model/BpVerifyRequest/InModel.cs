using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Shaparak.BehPardakhtGateWay.Model.BpVerifyRequest
{
    public class InModel
    {
        public long terminalId { get; set; }
        public string userName { get; set; }
        public string userPassword { get; set; }
        public long orderId { get; set; }
        public long saleOrderId { get; set; }
        public long saleReferenceId { get; set; }
      
    }
}
