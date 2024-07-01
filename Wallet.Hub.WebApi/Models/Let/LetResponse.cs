namespace Wallet.Hub.WebApi.Models.Let
{
    public class LetResponse
    {
        public string IpServer { get; set; }
        public int Status { get; set; }
        public int StatusCode { get; set; }
        public DateTime RegisterDate { get; set; }
        public LetResultObject resObject { get; set; }
    }

    public class LetResultObject
    {
        public string ResMessage { get; set; }

        public string SourceName { get; set; }
        public string SourceLastName { get; set; }
        public string Sourcenatonalcode { get; set; }
        public string SourceMobile { get; set; }
        public int SourceWalletNo { get; set; }
        public double EndUserWageAmount { get; set; }

        public long CustomerUserId { get; set; }

        public string DestinationName { get; set; }
        public string DestinationLastName { get; set; }
        public string Destinationatonalcode { get; set; }
        public string DestinationeMobile { get; set; }
        public int DestinationeWalletNo { get; set; }
        public double UserWageAmount { get; set; }
        public long? FactorNo { get; set; }
        public long Amount { get; set; }
        public Boolean BalanceEffect { get; set; }
        public double AmountPayAble { get; set; }

    }
}
