using Microsoft.EntityFrameworkCore;
using Wallet.Hub.WebApi.Entity;

namespace Wallet.Hub.WebApi.Data
{

    public class HubWebApiContext : DbContext
    {
        public HubWebApiContext(DbContextOptions<HubWebApiContext> options) : base(options)
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
