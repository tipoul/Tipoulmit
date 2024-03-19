using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Athentication.Agent.Models
{
    public class User
    {
        public User()
        {
            UserClaims = new List<UserClaim>();
        }

        public int Id { get; set; }

        public string FirtName { get; set; }

        public string LastName { get; set; }
        public List<UserClaim> UserClaims { get; set; }
    }
}
