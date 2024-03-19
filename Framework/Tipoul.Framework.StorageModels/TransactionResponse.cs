using System;

namespace Tipoul.Framework.StorageModels
{
    public class TransactionResponse
    {
        public TransactionResponse()
        {
            CreateDate = DateTime.Now;
        }

        public int Id { get; set; }

        public int RespCode { get; set; }

        public string? RespMsg { get; set; }

        public long Amount { get; set; }

        public string? InvoiceId { get; set; }

        public string? Payload { get; set; }

        public long TerminalId { get; set; }

        public long TraceNumber { get; set; }

        public string TipoulTrackNumber { get; set; }

        public string RRN { get; set; }
        public string SAN { get; set; }
        public string? DatePaid { get; set; }

        public string? DigitalReceipt { get; set; }

        public string? IssuerBank { get; set; }

        public string? CardNumber { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
