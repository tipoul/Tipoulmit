using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Tipoul.Framework.ShahinService.DataAccessLayer
{
    public class TipoulShahinDbContext : DbContext
    {
        public TipoulShahinDbContext(DbContextOptions<TipoulShahinDbContext> options) : base(options)
        {
        }
        public DbSet<StorageModels.AccountBalance> AccountBalances { get; set; }
        public DbSet<StorageModels.AccountBalanceResponce> AccountBalanceResponces { get; set; }

        public DbSet<StorageModels.Transfer> Transfers { get; set; }
        public DbSet<StorageModels.TransferResponce> TransferResponces { get; set; }

        public DbSet<StorageModels.AccountStatement> AccountStatements { get; set; }
        public DbSet<StorageModels.AccountStatementResponce> AccountStatementResponces { get; set; }

        public DbSet<StorageModels.TransactionInquiry> TransactionInquirys { get; set; }
        public DbSet<StorageModels.TransactionInquiryResponce> TransactionInquiryResponces { get; set; }

        public DbSet<StorageModels.Iban> Ibans { get; set; }
        public DbSet<StorageModels.IbanResponce> IbanResponces { get; set; }

        public DbSet<StorageModels.IbanInfo> IbanInfos { get; set; }
        public DbSet<StorageModels.IbanInfoResponce> IbanInfoResponces { get; set; }

        public DbSet<StorageModels.CardInfo> CardInfos { get; set; }
        public DbSet<StorageModels.CardInfoResponce> CardInfoResponces { get; set; }

        public DbSet<StorageModels.Logs.ShahinRequest> ShahinRequests { get; set; }
        public DbSet<StorageModels.Logs.ShahinRequestException> ShahinRequestExceptions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<StorageModels.AccountBalance>()
                .HasOne(f => f.AccountBalanceResponce)
                .WithOne(f => f.AccountBalance)
                .HasForeignKey<StorageModels.AccountBalanceResponce>(f => f.AccountBalanceId)
                .IsRequired(false);

            modelBuilder
                .Entity<StorageModels.Transfer>()
                .HasOne(f => f.TransferResponce)
                .WithOne(f => f.Transfer)
                .HasForeignKey<StorageModels.TransferResponce>(f => f.TransferId)
                .IsRequired(false);

            modelBuilder
               .Entity<StorageModels.AccountStatement>()
               .HasOne(f => f.AccountStatementResponce)
               .WithOne(f => f.AccountStatement)
               .HasForeignKey<StorageModels.AccountStatementResponce>(f => f.AccountStatementId)
               .IsRequired(false);

            modelBuilder
             .Entity<StorageModels.TransactionInquiry>()
             .HasOne(f => f.TransactionInquiryResponce)
             .WithOne(f => f.TransactionInquiry)
             .HasForeignKey<StorageModels.TransactionInquiryResponce>(f => f.TransactionInquiryId)
             .IsRequired(false);

            modelBuilder
             .Entity<StorageModels.Iban>()
             .HasOne(f => f.IbanResponce)
             .WithOne(f => f.Iban)
             .HasForeignKey<StorageModels.IbanResponce>(f => f.IbanId)
             .IsRequired(false);

            modelBuilder
             .Entity<StorageModels.IbanInfo>()
             .HasOne(f => f.IbanInfoResponce)
             .WithOne(f => f.IbanInfo)
             .HasForeignKey<StorageModels.IbanInfoResponce>(f => f.IbanInfoId)
             .IsRequired(false);

            modelBuilder
            .Entity<StorageModels.CardInfo>()
            .HasOne(f => f.CardInfoResponce)
            .WithOne(f => f.CardInfo)
            .HasForeignKey<StorageModels.CardInfoResponce>(f => f.CardInfoId)
            .IsRequired(false);

            modelBuilder
                .Entity<StorageModels.Logs.ShahinRequest>()
                .HasOne(f => f.ShahinRequestException)
                .WithOne(f => f.ShahinRequest)
                .HasForeignKey<StorageModels.Logs.ShahinRequestException>(f => f.ShahinRequestId)
                .IsRequired(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
