namespace Tipoul.Framework.Services.IranKishGateWay.Models
{
    public class GetTokenResult
    {
        public string Description { get; set; }

        public string ResponseCode { get; set; }

        public GetTokenResultResult Result { get; set; }

        public bool Status { get; set; }

        public class GetTokenResultResult
        {
            public long ExpiryTimestamp { get; set; }

            public long InitiateTimestamp { get; set; }

            public string Token { get; set; }

            public string TransactionType { get; set; }
        }
    }
}
