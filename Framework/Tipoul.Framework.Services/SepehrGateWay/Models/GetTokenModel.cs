using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Framework.Services.SepehrGateWay.Models
{
    public class GetTokenModel
    {
        public GetTokenModel(long amount, string callbackURL, string invoiceId, long terminalId, string payload)
        {
           
            if (amount < 1000)
                throw new Exception("حداقل مبلغ تراکنش 1000 ریال است");
            if (callbackURL.Length > 500)
                throw new Exception("حداکثر طول رشته آدرس صفحه برگشت 500 کاراکتر است");
            if (invoiceId.Length > 100)
                throw new Exception("حداکثر طول رشته شماره فاکتور 100 کاراکتر است");
            if (terminalId.ToString().Length != 8)
                throw new Exception("شماره ترمینال باید 8 رقمی باشد");

            Amount = amount;
            CallbackURL = callbackURL;
            InvoiceId = invoiceId;
            TerminalId = terminalId;
            Payload = payload;
        }

        public long Amount { get; set; }

        public string CallbackURL { get; set; }

        public string InvoiceId { get; set; }

        public long TerminalId { get; set; }

        public string Payload { get; set; }
    }
}
