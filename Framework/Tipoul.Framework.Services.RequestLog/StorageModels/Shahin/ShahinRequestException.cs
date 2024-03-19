namespace Tipoul.Framework.Services.RequestLog.StorageModels.Shahin
{
    public class ShahinRequestException
    {
        public int Id { get; set; }

        public int ShahinRequestId { get; set; }

        public string Message { get; set; }

        public string StackTrace { get; set; }

        public string? InnerMessage { get; set; }

        public string? InnerStackTrace { get; set; }

        public ShahinRequest ShahinRequest { get; set; }
    }
}
