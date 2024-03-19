using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Framework.Services.OpenBanking.Shahin.Inquiry.Ibans.Models
{
    public class IbanInfo
    {      
        public string bank { get; set; }
        public string nationalCode { get; set; }
        public string sourceAccount { get; set; }
    }
    public class IbanInfoResultObject
    {
        public string bank { get; set; }
        public string accountNumber { get; set; }
        public string ibanNumber { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string accountStatus { get; set; }
        public string nationalCode { get; set; }
        public string? message { get; set; }
        public string? errorCode { get; set; }
    }
    public class IbanInfoResult
    {
        public string transactionState { get; set; }
        public long transactionTime { get; set; }
        public string uuid { get; set; }
        public IbanInfoResultObject respObject { get; set; }
    }
}
