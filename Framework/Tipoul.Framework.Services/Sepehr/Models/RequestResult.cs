namespace Tipoul.Framework.Services.Sepehr.Models
{
    public class RequestResult
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public int ErrorCode { get; set; }

        public RequestResultData Data { get; set; }

        public class RequestResultData
        {
            public string TerminalNumber { get; set; }

            public string MerchantNumber { get; set; }
        }
    }
}
