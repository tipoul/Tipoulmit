namespace Tipoul.Athentication.Agent.Models
{
    public class UserClaim
    {
        public Claim Key { get; set; }

        public string Value { get; set; }

        public enum Claim
        {
            UserName = 1,
            Email = 2,
            MobileNumber = 3,
            FirstName = 4,
            LastName = 5,
        }
    }
}
