namespace Wallet.Hub.Apis.Entity
{
    public class GetTokenResponse
    {
        public long Id { get; set; }
        public string IpServer { get; set; }
        public int Status { get; set; }
        public int StatusCode { get; set; }
        public string ResMessage { get; set; }
        public string ResponseToken { get; set; }
        public string HashedToken { get; set; }
        public string WTTN { get; set; }
        public string WTTRN { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
