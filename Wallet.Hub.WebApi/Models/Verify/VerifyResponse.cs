namespace Wallet.Hub.WebApi.Models.Verify
{
    public class VerifyResponse
    {
        public string IpServer { get; set; }
        public int Status { get; set; }
        public int StatusCode { get; set; }
        public DateTime RegisterDate { get; set; }
        public VerifyResultObject resObject { get; set; }
    }

    public class VerifyResultObject
    {
        public string ResMessage { get; set; }
        public string SourceName { get; set; }
        public string SourceLastName { get; set; }
        public string Sourcenatonalcode { get; set; }
        public string SourceMobile { get; set; }
        public int SourceWalletNo { get; set; }
        public long CustomerUserId { get; set; }
        public string DestinationName { get; set; }
        public string DestinationLastName { get; set; }
        public string Destinationatonalcode { get; set; }
        public string DestinationeMobile { get; set; }
        public int DestinationeWalletNo { get; set; }
        public long? FactorNo { get; set; }
        public long Amount { get; set; }
        public bool BalanceEffect { get; set; }
        public double WageAmount { get; set; }

    }
}
