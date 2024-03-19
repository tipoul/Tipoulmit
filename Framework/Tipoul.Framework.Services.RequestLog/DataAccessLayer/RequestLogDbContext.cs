using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Framework.Services.RequestLog.DataAccessLayer
{
    public class RequestLogDbContext : DbContext
    {
        public RequestLogDbContext(DbContextOptions<RequestLogDbContext> options) : base(options)
        {
        }

        public DbSet<StorageModels.Sepehr.SepehrRequest> SepehrRequests { get; set; }
        public DbSet<StorageModels.Sepehr.SepehrRequestException> SepehrRequestExceptions { get; set; }
        public DbSet<StorageModels.SepehrGateWay.SepehrGateWayRequest> SepehrGateWayRequests { get; set; }
        public DbSet<StorageModels.SepehrGateWay.SepehrGateWayRequestException> SepehrGateWayRequestExceptions { get; set; }

        public DbSet<StorageModels.IranKishGateWay.IranKishGateWayRequest> IranKishGateWayRequests { get; set; }
        public DbSet<StorageModels.IranKishGateWay.IranKishGateWayRequestException> IranKishGateWayRequestExceptions { get; set; }

        public DbSet<StorageModels.Shaparak.ShaparakRequest> ShaparakRequests { get; set; }
        public DbSet<StorageModels.Shaparak.ShaparakRequestException> ShaparakRequestExceptions { get; set; }
        public DbSet<StorageModels.ShaparakTax.ShaparakTaxRequest> ShaparakTaxRequests { get; set; }
        public DbSet<StorageModels.ShaparakTax.ShaparakTaxRequestException> ShaparakTaxRequestExceptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<StorageModels.Sepehr.SepehrRequest>()
                .HasOne(f => f.SepehrRequestException)
                .WithOne(f => f.SepehrRequest)
                .HasForeignKey<StorageModels.Sepehr.SepehrRequestException>(f => f.SepehrRequestId)
                .IsRequired(false);

            modelBuilder
                .Entity<StorageModels.SepehrGateWay.SepehrGateWayRequest>()
                .HasOne(f => f.SepehrgateWayRequestException)
                .WithOne(f => f.SepehrGateWayReuqest)
                .HasForeignKey<StorageModels.SepehrGateWay.SepehrGateWayRequestException>(f => f.SepehrGateWayReuqestId)
                .IsRequired(false);

            modelBuilder
                .Entity<StorageModels.IranKishGateWay.IranKishGateWayRequest>()
                .HasOne(f => f.IranKishGateWayRequestException)
                .WithOne(f => f.IranKishGateWayRequest)
                .HasForeignKey<StorageModels.IranKishGateWay.IranKishGateWayRequestException>(f => f.IranKishGateWayRequestId)
                .IsRequired(false);

            modelBuilder
                .Entity<StorageModels.Shaparak.ShaparakRequest>()
                .HasOne(f => f.ShaparakRequestException)
                .WithOne(f => f.ShaparakRequest)
                .HasForeignKey<StorageModels.Shaparak.ShaparakRequestException>(f => f.ShaparakRequestId)
                .IsRequired(false);

            modelBuilder
                .Entity<StorageModels.ShaparakTax.ShaparakTaxRequest>()
                .HasOne(f => f.ShaparakTaxRequestException)
                .WithOne(f => f.ShaparakTaxRequest)
                .HasForeignKey<StorageModels.ShaparakTax.ShaparakTaxRequestException>(f => f.ShaparakTaxRequestId)
                .IsRequired(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
