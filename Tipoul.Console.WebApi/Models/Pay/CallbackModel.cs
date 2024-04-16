namespace Tipoul.Services.Shared.Models.Pay
{
    public class CallbackModel
    {
        public long Amount { get; set; }

        public string? CardNumber { get; set; }
        
        public string? IssuerBank { get; set; }
        
        public string RRN { get; set; }
        
        public string? DatePaid { get; set; }
        
        public long TraceNumber { get; set; }
        
        public string? FactorNumber { get; set; }
        
        public int RespCode { get; set; }
        
        public string? RespMsg { get; set; }

        public string TipoulTrackNumber { get; set; }

        public string TipoulTraceNumber { get; set; }
    }
}