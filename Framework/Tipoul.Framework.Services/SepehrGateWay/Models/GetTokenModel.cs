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
        public long Amount { get; set; }

        public string CallbackURL { get; set; }

        public string InvoiceId { get; set; }

        public long TerminalId { get; set; }

        public string Payload { get; set; }
    }
}
