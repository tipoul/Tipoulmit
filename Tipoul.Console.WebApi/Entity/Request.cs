namespace Tipoul.Console.WebApi.Entity
{
    public class Request
    {
        public long Id { get; set; }
        public string ?GateToken { get; set; }
        public long ?Amount { get; set; }
        public string ?CallBackUrl { get; set; }
        public long ?PayerUserId { get; set; }
        public string ?PayerName { get; set; }
        public string ?PayerMobile { get; set; }
        public long ?FactorNumber { get; set; }
        public string ?ValidCardNum { get; set; }
        public string ?BlankForPayer { get; set; }
        public string ?BlankForTransaction { get; set; }
        public string ?Description { get; set; }
        public string ?IPG { get; set; }
        public string ?AccessToken { get; set; }
        public string ?HashedToken { get; set; }
        public string ?IPGToken { get; set; }
        public string ?GTTN { get; set; }
        public DateTime? RegisterDate { get; set; }
        
    }
}
