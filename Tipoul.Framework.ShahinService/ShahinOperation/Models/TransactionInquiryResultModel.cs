using System.Collections.Generic;

namespace Tipoul.Framework.ShahinService.ShahinOperation.Models
{
    public class TransactionInquiryResultModelObject
    {
        public string requestedUuid { get; set; }
        public string transactionState { get; set; }
        public string service { get; set; }
        public string sourceAccountNumber { get; set; }
        public string destinationAccountNumber { get; set; }
        public long amount { get; set; }
        public long transactionDate { get; set; }
        public string sourceBank { get; set; }
        public string destinationBank { get; set; }
        public string traceNumber { get; set; }
        public string respCode { get; set; }
        public string transferType { get; set; }
        public string? message { get; set; }
        public string? errorCode { get; set; }
    }
    public class TransactionInquiryResultModel
    {
        public string transactionState { get; set; }
        public long transactionTime { get; set; }
        public string uuid { get; set; }
        public TransactionInquiryResultModelObject respObject { get; set; }
    }

}
