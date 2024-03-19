using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Athentication.StorageModels
{
    public class User
    {
        public User()
        {
            UserClaims = new List<UserClaim>();
        }

        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string? Email { get; set; }

        public bool IsEmailConfirmed { get; set; }

        public string? MobileNumber { get; set; }

        public bool IsMobileNumberConfirmed { get; set; }

        public List<UserClaim> UserClaims { get; set; }
    }
}
