using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.CoreBanking.Services.KYC.Iban.MatchNationalCode
{
    public class InModel
    {
        public string cardNumber { get; set; }
        public string iban { get; set; }
        public string birthDate { get; set; }
    }
}
