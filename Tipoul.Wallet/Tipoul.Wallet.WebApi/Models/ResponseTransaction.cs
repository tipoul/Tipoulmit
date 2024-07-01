namespace Tipoul.Wallet.WebApi.Models
{
    public class ResponseTransaction
    {

        public string message { get; set; }
        public string statuscode { get; set; }
        public string messagecode { get; set; }
        public List<Payer> ?payerobject { get; set; }
    }
    public class Payer
    {
        public string name { get; set; }
        public string description { get; set; }
        public string price { get; set; }
        public string state { get; set; }
        public string date { get; set; }
        public string time { get; set; }
    }
    public class ResponseGttnTransaction
    {

        public string message { get; set; }
        public string statuscode { get; set; }
        public string messagecode { get; set; }
        public GttnResponse? payerobject { get; set; }
    }
    public class GttnResponse
    {
        public string name { get; set; }
        public string description { get; set; }
        public string price { get; set; }
        public string state { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string refnumber { get; set; }
        public string cart { get; set; }
        public string ipg { get; set; }
    }
}

