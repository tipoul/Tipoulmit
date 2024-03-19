using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Framework.Services.OpenBanking.Shahin.Financial.Models
{
    public class TransactionInquiries
    {
        public string bank { get; set; }
        public string nationalCode { get; set; }
        public string sourceAccount { get; set; }
        public string requestedUuid { get; set; }
    }
    public class TransactionInquiryResultObject
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
    public class TransactionInquiryResult
    {
        public string transactionState { get; set; }
        public long transactionTime { get; set; }
        public string uuid { get; set; }
        public TransactionInquiryResultObject respObject { get; set; }
    }
}
