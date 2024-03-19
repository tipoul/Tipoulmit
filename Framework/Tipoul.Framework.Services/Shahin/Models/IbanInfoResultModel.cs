using System.Collections.Generic;

namespace Tipoul.Framework.Services.Shahin.Models
{
    public class IbanInfoResultModelObject
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
    public class IbanInfoResultModel
    {
        public string transactionState { get; set; }
        public long transactionTime { get; set; }
        public string uuid { get; set; }
        public IbanInfoResultModelObject respObject { get; set; }
    }

}
