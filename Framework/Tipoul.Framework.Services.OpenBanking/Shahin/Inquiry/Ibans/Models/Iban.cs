using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Framework.Services.OpenBanking.Shahin.Inquiry.Ibans.Models
{
    public class Iban
    {
        public string bank { get; set; }
        public string nationalCode { get; set; }
        public string sourceAccount { get; set; }
    }
    public class IbanResultObject
    {
        public string accountNumber { get; set; }
        public string ibanNumber { get; set; }
        public string? message { get; set; }
        public string? errorCode { get; set; }
    }
    public class IbanResult
    {
        public string transactionState { get; set; }
        public long transactionTime { get; set; }
        public string uuid { get; set; }
        public IbanResultObject respObject { get; set; }
    }
}
