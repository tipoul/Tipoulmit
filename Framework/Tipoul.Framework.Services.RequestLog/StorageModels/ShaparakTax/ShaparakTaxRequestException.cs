namespace Tipoul.Framework.Services.RequestLog.StorageModels.ShaparakTax
{
    public class ShaparakTaxRequestException
    {
        public int Id { get; set; }

        public int ShaparakTaxRequestId { get; set; }

        public string Message { get; set; }

        public string StackTrace { get; set; }

        public string? InnerMessage { get; set; }

        public string? InnerStackTrace { get; set; }

        public ShaparakTaxRequest ShaparakTaxRequest { get; set; }
    }
}
