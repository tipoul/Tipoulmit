using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Framework.Services.OpenBanking.Shahin.Financial.Models
{
    public class Transfers
    {
        public string bank { get; set; }
        public string nationalCode { get; set; }
        public string sourceAccount { get; set; }
        public string destinationAccountNumber { get; set; }
        public string destinationBank { get; set; }
        public string ?destinationAccountName { get; set; }
        public long amount { get; set; }
        public TransferTypeEnum transferType { get; set; }
        public BabatEnum babat { get; set; }
        public string paymentID { get; set; }
        public string documentID { get; set; }
        public string transferID { get; set; }
        public string depositDescription { get; set; }
        public string withdrawDescription { get; set; }
        public string smsPass { get; set; }
    }
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
    public class TransferResult
    {
        public string transactionState { get; set; }
        public long transactionTime { get; set; }
        public string uuid { get; set; }
        public TransferResultObject respObject { get; set; }
    }
}
