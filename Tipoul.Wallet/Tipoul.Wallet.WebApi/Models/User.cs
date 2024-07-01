namespace Tipoul.Wallet.WebApi.Models
{
    public class UserRequest
    {
        public long Id { get; set; }
        public string FirtName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }

    }
    public class User
    {
        public string FirtName { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; }
        public long Id { get; set; }
    }
}
