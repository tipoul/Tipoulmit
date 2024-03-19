using System.Collections.Generic;

namespace Tipoul.Framework.StorageModels
{
    public class TransactionInquiry
    {
        public TransactionInquiry()
        {
        }
        public int Id { get; set; }
        public string Bank { get; set; }
        public string NationalCode { get; set; }
        public string SourceAccount { get; set; }
        public string DestinationAccountNumber { get; set; }
        public string RequestedUuid { get; set; }
        public string AccessToken { get; set; }
        public TransactionInquiryResponce TransactionInquiryResponce { get; set; }
    }
}
