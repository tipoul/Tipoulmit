namespace Tipoul.Framework.Services.IranKishGateWay.Models
{
    public class ConfirmModel
    {
        public ConfirmModel(string terminalId, string retrievalReferenceNumber, string systemTraceAuditNumber, string tokenIdentity)
        {
            TerminalId = terminalId;
            RetrievalReferenceNumber = retrievalReferenceNumber;
            SystemTraceAuditNumber = systemTraceAuditNumber;
            TokenIdentity = tokenIdentity;
        }

        public string TerminalId { get; set; }

        public string RetrievalReferenceNumber { get; set; }

        public string SystemTraceAuditNumber { get; set; }

        public string TokenIdentity { get; set; }
    }
}
