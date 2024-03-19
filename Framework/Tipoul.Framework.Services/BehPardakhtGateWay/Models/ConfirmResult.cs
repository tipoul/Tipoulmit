namespace Tipoul.Framework.Services.IranKishGateWay.Models
{
    public class ConfirmResult
    {
        public string ResponseCode { get; set; }

        public string Description { get; set; }

        public bool Status { get; set; }

        public ConfirmResultResult Result { get; set; }

        public class ConfirmResultResult
        {
            public string ResponseCode { get; set; }

            public string SystemTrqaceAuditNumber { get; set; }

            public string RetrievalReferenceNumber { get; set; }

            public long TransactionDate { get; set; }

            public long TransactionTime { get; set; }

            public string ProcessCode { get; set; }

            public string PaymentId { get; set; }

            public string Amount { get; set; }
        }
    }
}
