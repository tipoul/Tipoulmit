using System.Collections.Generic;

namespace Tipoul.Framework.StorageModels
{
    public class Transfer
    {
        public Transfer()
        {
        }
        public int Id { get; set; }
        public string Bank { get; set; }
        public string NationalCode { get; set; }
        public string SourceAccount { get; set; }
        public string DestinationAccountNumber { get; set; }
        public string DestinationBank { get; set; }
        public long Amount { get; set; }
        public string TransferType { get; set; }
        public string Babat { get; set; }
        public string PaymentID { get; set; }
        public string DocumentID { get; set; }
        public string TransferID { get; set; }
        public string DepositDescription { get; set; }
        public string WithdrawDescription { get; set; }
        public string SmsPass { get; set; }
        public string AccessToken { get; set; }
        public TransferResponce TransferResponce { get; set; }
    }
}
