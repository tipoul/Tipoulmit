namespace Tipoul.Infrastructure.RequestLog.StorageModels
{
    public class RequestBody
    {
        public int Id { get; set; }

        public int RequestId { get; set; }

        public string Body { get; set; }

        public Request Request { get; set; }
    }
}
