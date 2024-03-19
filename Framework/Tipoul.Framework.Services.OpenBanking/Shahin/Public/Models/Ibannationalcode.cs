using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Framework.Services.OpenBanking.Shahin.Public.Models
{
    public class Ibannationalcode
    {              
        public string nationalCode { get; set; }
        public string iban { get; set; }
        public string birthDate { get; set; }
    }
    public class IbannationalcodeResultObject
    {
        public string ibanCheckResult { get; set; }       
        public string? message { get; set; }
        public string? errorCode { get; set; }
    }
    public class IbannationalcodeResult
    {
        public string transactionState { get; set; }
        public long transactionTime { get; set; }
        public string uuid { get; set; }
        public IbannationalcodeResultObject respObject { get; set; }
    }
}
