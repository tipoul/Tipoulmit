using System.Collections.Generic;

namespace Tipoul.Framework.Services.Shahin.Models
{
    public class TransferResultObject
    {
        public string sourceAccountNumber { get; set; }
        public string destinationAccountNumber { get; set; }
        public long amount { get; set; }
        public string sourceBank { get; set; }
        public string destinationBank { get; set; }
        public string transferType { get; set; }
        public string traceNumber { get; set; }
        public string message { get; set; }
        public string errorCode { get; set; }
    }
    public class TransferResultModel
    {
        public string transactionState { get; set; }
        public long transactionTime { get; set; }
        public string uuid { get; set; }
        public TransferResultObject respObject { get; set; }
    }
}
