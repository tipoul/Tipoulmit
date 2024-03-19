using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tipoul.Athentication.StorageModels;

namespace Tipoul.Athentication.DataAccessLayer
{
    public class AthenticationDbContext : DbContext
    {
        public AthenticationDbContext(DbContextOptions<AthenticationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<UserClaim> UserClaims { get; set; }
    }
}
