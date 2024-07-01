namespace Wallet.Hub.Apis.Entity
{
    public class LetRequestLog
    {
        public long Id { get; set; }
        public string IpServer { get; set; }
       
        public string HashedToken { get; set; }
      
        public DateTime RegisterDate { get; set; }
    }
}
