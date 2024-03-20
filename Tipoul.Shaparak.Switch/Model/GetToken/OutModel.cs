using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Shaparak.Switch.Model.GetToken
{
    public class IranKishOutModel
    {
        public string acceptorId { get; set; }
        public long amount { get; set; }
        public string paymentId { get; set; }       
        public string requestId { get; set; }
        public string revertUri { get; set; }
        public string terminalId { get; set; }
        public string rsaPublicKey { get; set; }
        public string passPhrase { get; set; }

    }
    public class BehPardakhtOutModel
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
    public class SepehrOutModel
    {
        public long amount { get; set; }
        public string callbackURL { get; set; }
        public string invoiceId { get; set; }
        public long terminalId { get; set; }
        public string payload { get; set; }
    }
}
