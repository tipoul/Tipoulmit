namespace Wallet.Hub.Apis.Entity
{
    public class GetTokenRequest
    {
        public long Id { get; set; }
        public string IpServer { get; set; }
        public long WalletId { get; set; }
        public long FactorNo { get; set; }
        public long Amount { get; set; }
        public Boolean BalanceEffect { get; set; }
        public string CallBackUrl { get; set; }
        public string Mobile { get; set; }
        public string NationalCode { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
