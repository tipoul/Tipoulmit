using System.Collections.Generic;

namespace Tipoul.Framework.StorageModels
{
    public class TransactionInquiryResponce
    {
        public TransactionInquiryResponce()
        {
        }
        public int Id { get; set; }
        public string TransactionState { get; set; }
        public long TransactionTime { get; set; }
        public string Uuid { get; set; }
        public string? RequestedUuid { get; set; }
        public string? Service { get; set; }
        public string? SourceAccountNumber { get; set; }
        public string? DestinationAccountNumber { get; set; }
        public long Amount { get; set; }
        public long TransactionDate { get; set; }
        public string? SourceBank { get; set; }
        public string? DestinationBank { get; set; }
        public string? TraceNumber { get; set; }
        public string? RespCode { get; set; }
        public string? TransferType { get; set; }
        public string? Message { get; set; }
        public string? ErrorCode { get; set; }
        public int TransactionInquiryId { get; set; }
        public TransactionInquiry TransactionInquiry { get; set; }
    }
}
