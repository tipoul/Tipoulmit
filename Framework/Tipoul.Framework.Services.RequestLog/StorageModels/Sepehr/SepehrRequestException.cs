namespace Tipoul.Framework.Services.RequestLog.StorageModels.Sepehr
{
    public class SepehrRequestException
    {
        public int Id { get; set; }

        public int SepehrRequestId { get; set; }

        public string Message { get; set; }

        public string StackTrace { get; set; }

        public string? InnerMessage { get; set; }

        public string? InnerStackTrace { get; set; }

        public SepehrRequest SepehrRequest { get; set; }
    }
}
