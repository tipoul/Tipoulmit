namespace Wallet.Hub.Apis.Models.Token
{
    public class Response
    {
        public string IpServer { get; set; }
        public int Status { get; set; }
        public int StatusCode { get; set; }
        public DateTime RegisterDate { get; set; }        
        public ResultObject resObject { get; set; }
    }
    
    public class ResultObject
    {
        public string ResMessage { get; set; }
        public string ResponseToken { get; set; }
        public string HashedToken { get; set; }
        public string WTTN { get; set; }
        public string WTTRN { get; set; }
        
    }
   
}
