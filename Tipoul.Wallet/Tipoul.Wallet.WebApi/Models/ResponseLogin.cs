namespace Tipoul.Wallet.WebApi.Models
{
    public class ResponseLogin
    {
        public string message { get; set; }
        public string statuscode { get; set; }
        public string messagecode { get; set; }
        public ResultObjectUser resultobject { get; set; }
    }

    public class ResultObjectUser
    {
        public string FirtName { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; }
        public string UserId { get; set; }

    }
    public class ResponseInfo
    {
        public string message { get; set; }
        public string statuscode { get; set; }
        public string messagecode { get; set; }
        public ResultObjectDashboard resultobject { get; set; }
    }
    public class ResultObjectDashboard
    {
        public string FirtName { get; set; }
        public string LastName { get; set; }
        public long Id { get; set; }

    }
}
