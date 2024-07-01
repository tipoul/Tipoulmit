using Microsoft.EntityFrameworkCore;
using Tipoul.Wallet.WebApi.Entity;

namespace Tipoul.Wallet.WebApi.Data
{
    public class WalletWebApiContext : DbContext
    {
        public WalletWebApiContext(DbContextOptions<WalletWebApiContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
    }
}
