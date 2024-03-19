using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.CoreBanking.Services.KYC.Iban.Inquiry
{
    public class InModel
    {
        public int bankId { get; set; }
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
