using Microsoft.EntityFrameworkCore;
using Tipoul.Console.WebApi.Entity;

namespace Tipoul.Console.WebApi.Data
{

    public class ConsoleContext : DbContext
    {
        public ConsoleContext(DbContextOptions<ConsoleContext> options) : base(options)
        {
        }
        public DbSet<Request> Request { get; set; }
        public DbSet<Response> Response { get; set; }
        public DbSet<Verify> Verify { get; set; }
    }
}
