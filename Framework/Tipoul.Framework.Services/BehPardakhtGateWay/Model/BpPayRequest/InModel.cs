using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Shaparak.Services.BehPardakhtGateWay.Model.BpPayRequest
{
    public class InModel
    {
        public long terminalId { get; set; }
        public string userName { get; set; }
        public string userPassword { get; set; }
        public long orderId { get; set; }
        public long amount { get; set; }
        public string localDate { get; set; }
        public string localTime { get; set; }
        public string additionalData { get; set; }
        public string callBackUrl { get; set; }
        public long payerId { get; set; }

    }
}
