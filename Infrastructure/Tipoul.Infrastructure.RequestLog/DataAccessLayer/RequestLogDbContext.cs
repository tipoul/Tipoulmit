using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Infrastructure.RequestLog.DataAccessLayer
{
    public class RequestLogDbContext : DbContext
    {
        public RequestLogDbContext(DbContextOptions<RequestLogDbContext> options) : base(options)
        {
        }

        public DbSet<StorageModels.Request> Requests { get; set; }

        public DbSet<StorageModels.RequestBody> RequestBodies { get; set; }

        public DbSet<StorageModels.RequestCookie> RequestCookies { get; set; }

        public DbSet<StorageModels.RequestException> RequestExceptions { get; set; }

        public DbSet<StorageModels.RequestForm> RequestForms { get; set; }

        public DbSet<StorageModels.RequestHeader> RequestHeaders { get; set; }

        public DbSet<StorageModels.RequestInnerException> RequestInnerExceptions { get; set; }

        public DbSet<StorageModels.RequestQuery> RequestQueries { get; set; }

        public DbSet<StorageModels.Response> Responses { get; set; }

        public DbSet<StorageModels.ResponseHeader> ResponseHeaders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<StorageModels.Request>()
                .HasOne(f => f.RequestException)
                .WithOne(f => f.Request)
                .HasForeignKey<StorageModels.RequestException>(f => f.RequestId)
                .IsRequired(false);

            modelBuilder
                .Entity<StorageModels.Request>()
                .HasOne(f => f.Response)
                .WithOne(f => f.Request)
                .HasForeignKey<StorageModels.Response>(f => f.RequestId)
                .IsRequired(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
