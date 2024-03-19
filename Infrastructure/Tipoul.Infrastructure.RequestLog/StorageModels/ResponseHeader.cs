namespace Tipoul.Infrastructure.RequestLog.StorageModels
{
    public class ResponseHeader
    {
        public int Id { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public Response Response { get; set; }
    }
}
