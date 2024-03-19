namespace Tipoul.Framework.Services.RequestLog.StorageModels.Shaparak
{
    public class ShaparakRequestException
    {
        public int Id { get; set; }

        public int ShaparakRequestId { get; set; }

        public string Message { get; set; }

        public string StackTrace { get; set; }

        public string? InnerMessage { get; set; }

        public string? InnerStackTrace { get; set; }

        public ShaparakRequest ShaparakRequest { get; set; }
    }
}
