namespace Tipoul.Framework.Services.RequestLog.StorageModels.SepehrGateWay
{
    public class SepehrGateWayRequestException
    {
        public int Id { get; set; }

        public int SepehrGateWayReuqestId { get; set; }

        public string Message { get; set; }

        public string StackTrace { get; set; }

        public string? InnerMessage { get; set; }

        public string? InnerStackTrace { get; set; }

        public SepehrGateWayRequest SepehrGateWayReuqest { get; set; }
    }
}
