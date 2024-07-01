using System.Numerics;

namespace Tipoul.Wallet.Switch.Entity
{
    public class Users
    {
        public long Id { get; set; }
        public string ?Name { get; set; }
        public string ?Lastname { get; set; }
        public string ?Nationalcode { get; set; }
        public string ?Tel { get; set; }
        public string ?Mobile { get; set; }
        public string ?Email { get; set; }
        public string ?Username { get; set; }
        public string ?Password { get; set; }
        public string ?Token { get; set; }
        public int ?Parent { get; set; }
        public long ?CustomerUserId { get; set; }
        public int ?CustomerUserType { get; set; }
        public DateTime ?RegisterDate { get; set; }

        
    }
}
