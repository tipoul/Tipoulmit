using System.Collections.Generic;

namespace Tipoul.Framework.Services.Shahin.Models
{
    public class IbanResultModelObject
    {
        public string accountNumber { get; set; }
        public string ibanNumber { get; set; }
        public string? message { get; set; }
        public string? errorCode { get; set; }
    }
    public class IbanResultModel
    {
        public string transactionState { get; set; }
        public long transactionTime { get; set; }
        public string uuid { get; set; }
        public IbanResultModelObject respObject { get; set; }
    }

}
