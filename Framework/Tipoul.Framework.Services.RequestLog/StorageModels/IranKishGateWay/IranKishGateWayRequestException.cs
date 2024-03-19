namespace Tipoul.Framework.Services.RequestLog.StorageModels.IranKishGateWay
{
    public class IranKishGateWayRequestException
    {
        public int Id { get; set; }

        public int IranKishGateWayRequestId { get; set; }

        public string Message { get; set; }

        public string StackTrace { get; set; }

        public string? InnerMessage { get; set; }

        public string? InnerStackTrace { get; set; }

        public IranKishGateWayRequest IranKishGateWayRequest { get; set; }
    }
}
