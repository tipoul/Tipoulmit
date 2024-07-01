namespace Tipoul.Shaparak.Switch.Model.GetToken
{
    public class ResultModel
    {

        public string accessToken { get; set; }
        public long terminalId { get; set; }
        public string userName { get; set; }
        public string userPassword { get; set; }
        public long orderId { get; set; }
        public long saleOrderId { get; set; }
        public long saleReferenceId { get; set; }
        public string callbackurl { get; set; }
        public long amount { get; set; }
        public string resCode { get; set; }
        public string IPG { get; set; }
    }
    public class ResultModelUser
    {

        public string accessToken { get; set; }
     
        public long orderId { get; set; }
     
        public string callbackurl { get; set; }
        public long amount { get; set; }
      
        public string IPG { get; set; }
    }
}
