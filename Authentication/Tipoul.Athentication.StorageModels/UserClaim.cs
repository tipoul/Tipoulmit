namespace Tipoul.Athentication.StorageModels
{
    public class UserClaim
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public Claim Key { get; set; }

        public string Value { get; set; }

        public User User { get; set; }

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
