using Microsoft.EntityFrameworkCore;
using Wallet.Hub.Apis.Entity;

namespace Wallet.Hub.Apis.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }
        public DbSet<GetTokenRequest> GetTokenRequest { get; set; }
        public DbSet<GetTokenResponse> GetTokenResponse { get; set; }
        public DbSet<LetRequestLog> LetRequestLog { get; set; }
        public DbSet<LetResponseLog> LetResponseLog { get; set; }
        public DbSet<VerifyRequestLog> VerifyRequestLog { get; set; }
        public DbSet<VerifyResponseLog> VerifyResponseLog { get; set; }
        
    }
}
