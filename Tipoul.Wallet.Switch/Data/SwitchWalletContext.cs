using Microsoft.EntityFrameworkCore;
using Tipoul.Wallet.Switch.Entity;

namespace Tipoul.Wallet.Switch.Data
{
    public class SwitchWalletContext : DbContext
    {
        public SwitchWalletContext(DbContextOptions<SwitchWalletContext> options) : base(options)
        {
        }
        public DbSet<Balance> Balance { get; set; }  
        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<TransactionDetail> TransactionDetail { get; set; }
        public DbSet<TransactionTypes> TransactionTypes { get; set; }
        public DbSet<TransactionTypeUser> TransactionTypeUser { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Wallets> Wallets { get; set; }
      
    }
}
