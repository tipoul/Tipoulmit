using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tipoul.Framework.StorageModels;

namespace Tipoul.Framework.DataAccessLayer
{
    public class TipoulFrameworkDbContext : DbContext
    {
        public TipoulFrameworkDbContext(DbContextOptions<TipoulFrameworkDbContext> options) : base(options)
        {
        }

        public DbSet<StorageModels.State> States { get; set; }

        public DbSet<StorageModels.City> Cities { get; set; }

        public DbSet<StorageModels.Bank> Banks { get; set; }

        public DbSet<StorageModels.BusinessCategory> BusinessCategories { get; set; }

        public DbSet<StorageModels.BusinessSubCategory> BusinessSubCategories { get; set; }

        public DbSet<StorageModels.Wallet> Wallets { get; set; }

        public DbSet<StorageModels.User> Users { get; set; }

        public DbSet<StorageModels.UserVerificationHistory> UserVerificationHistories { get; set; }

        public DbSet<StorageModels.UserVerificationHistoryError> UserVerificationHistoryErrors { get; set; }

        public DbSet<StorageModels.UserTaxRequestHistory> UserTaxRequestHistories { get; set; }

        public DbSet<StorageModels.UserCommertialGateWayRegisterRequestLog> UserCommertialGateWayRegisterRequestLogs { get; set; }

        public DbSet<StorageModels.UserWageTypeHistory> UserWageTypeHistories { get; set; }

        public DbSet<StorageModels.UserWageHistory> UserWageHistories { get; set; }

        public DbSet<StorageModels.LegalProfile> LegalProfiles { get; set; }

        public DbSet<StorageModels.LegalProfileLogoHistory> LegalProfileLogoHistories { get; set; }

        public DbSet<StorageModels.UserAvatarHistory> UserAvatarHistories { get; set; }

        public DbSet<StorageModels.IdentityDocument> IdentityDocuments { get; set; }

        public DbSet<StorageModels.CommertialGateWay> CommertialGateWays { get; set; }

        public DbSet<StorageModels.CommertialGateWayStatus> CommertialGateWayStatuses { get; set; }

        public DbSet<StorageModels.Transaction> Transactions { get; set; }
        public DbSet<StorageModels.TransactionConfirmResult> TransactionConfirmResult { get; set; }

        public DbSet<StorageModels.GetTokenModel> TransactionModels { get; set; }

        public DbSet<StorageModels.TransactionResponse> TransactionResponses { get; set; }

        public DbSet<StorageModels.BankAccount> BankAccounts { get; set; }

        public DbSet<StorageModels.Ticket> Tickets { get; set; }

        public DbSet<StorageModels.TicketMessage> TicketMessages { get; set; }

        public DbSet<StorageModels.TicketStatusHistory> TicketStatusHistories { get; set; }

        public DbSet<StorageModels.Notification> Notifications { get; set; }

        public DbSet<StorageModels.NotificationUser> NotificationUsers { get; set; }

        public DbSet<StorageModels.SMSLog> SMSLogs { get; set; }

        public DbSet<StorageModels.Settlement> Settlements { get; set; }
        public DbSet<StorageModels.WalletDepositRequest> WalletDepositRequests { get; set; }
        public DbSet<StorageModels.WalletDepositRequestStatusHistory> WalletDepositRequestStatusHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StorageModels.User>()
                .HasOne(f => f.LegalProfile)
                .WithOne(f => f.User)
                .HasForeignKey<StorageModels.LegalProfile>(f => f.UserId)
                .IsRequired(false);

            modelBuilder.Entity<StorageModels.LegalProfile>()
                .HasOne(f => f.Wallet)
                .WithOne(f => f.LegalProfile)
                .HasForeignKey<StorageModels.LegalProfile>(f => f.WalletId)
                .IsRequired(false);

            modelBuilder.Entity<StorageModels.User>()
                .HasOne(f => f.Wallet)
                .WithOne(f => f.User)
                .HasForeignKey<StorageModels.User>(f => f.WalletId)
                .IsRequired(false);

            modelBuilder.Entity<StorageModels.TicketMessage>()
                .HasOne(f => f.User)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StorageModels.TicketStatusHistory>()
                .HasOne(f => f.User)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StorageModels.NotificationUser>()
                .HasOne(f => f.User)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StorageModels.Settlement>()
                .HasOne(f => f.User)
                .WithMany()
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StorageModels.SettlementStatusHistory>()
                .HasOne(f => f.User)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StorageModels.WalletDepositRequest>()
            .HasOne(f => f.User)
            .WithMany()
            .HasForeignKey(f => f.UserId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StorageModels.WalletDepositRequestStatusHistory>()
                .HasOne(f => f.User)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<StorageModels.UserWageHistory>()
                .HasOne(f => f.UserWageTypeHistory)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            modelBuilder.Entity<StorageModels.UserWageHistory>()
                .HasOne(f => f.Settlement)
                .WithOne()
                .HasForeignKey<StorageModels.UserWageHistory>(f => f.SettlementId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            modelBuilder.Entity<StorageModels.User>()
                .HasMany(f => f.UserWageHistories)
                .WithOne()
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Transactionv1> Transactionv1 { get; set; }
    }
}
