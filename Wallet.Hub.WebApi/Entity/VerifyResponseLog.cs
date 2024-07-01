namespace Wallet.Hub.WebApi.Entity
{
    public class VerifyResponseLog
    {
        public long Id { get; set; }
        public string ?IpServer { get; set; }
       
        public int ?Status { get; set; }
        public int ?StatusCode { get; set; }
        public string ?ResMessage { get; set; }

        public DateTime RegisterDate { get; set; }
    }
}
