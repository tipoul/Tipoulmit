namespace Wallet.Hub.WebApi.Entity
{
    public class GetTokenRequest
    {
        public long Id { get; set; }
        public string ?IpServer { get; set; }
        public int ?SourceWalletNo { get; set; }
        public int ?DestinationWalletNo { get; set; }
        public long ?FactorNo { get; set; }
        public long ?Amount { get; set; }
        public Boolean BalanceEffect { get; set; }
        public string ?CallBackUrl { get; set; }
      
        public DateTime RegisterDate { get; set; }
    }
}
