using System.Collections.Generic;

namespace Tipoul.Framework.ShahinService.ShahinOperation.Models
{
    public class CardInfoResultModelObject
    {
        public string ownerName { get; set; }
        public string accountNumber { get; set; }
        public string bank { get; set; }
        public string iban { get; set; }
        public string? message { get; set; }
        public string? errorCode { get; set; }
    }
    public class CardInfoResultModel
    {
        public string transactionState { get; set; }
        public long transactionTime { get; set; }
        public string uuid { get; set; }
        public CardInfoResultModelObject respObject { get; set; }
    }

}
