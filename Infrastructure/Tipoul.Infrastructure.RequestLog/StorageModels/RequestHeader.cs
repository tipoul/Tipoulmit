namespace Tipoul.Infrastructure.RequestLog.StorageModels
{
    public class RequestHeader
    {
        public int Id { get; set; }

        public int RequestId { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public Request Request { get; set; }
    }
}
