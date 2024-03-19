namespace Tipoul.Framework.Services.OpenBanking.Shahin.StorageModels
{
    public class RequestQuery
    {
        public int Id { get; set; }

        public int RequestId { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public Request Request { get; set; }
    }
}
