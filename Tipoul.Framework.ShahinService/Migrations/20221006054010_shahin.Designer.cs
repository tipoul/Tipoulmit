﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tipoul.Framework.ShahinService.DataAccessLayer;

namespace Tipoul.Framework.DataAccessLayer.Migrations.TipoulShahinDb
{
    [DbContext(typeof(TipoulShahinDbContext))]
    [Migration("20221006054010_shahin")]
    partial class shahin
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "6.0.0-preview.5.21301.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Tipoul.Framework.StorageModels.AccountBalance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccessToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SourceAccount")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AccountBalances");
                });

            modelBuilder.Entity("Tipoul.Framework.StorageModels.AccountBalanceResponce", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountBalanceId")
                        .HasColumnType("int");

                    b.Property<string>("AccountType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("AvailableBalance")
                        .HasColumnType("bigint");

                    b.Property<long>("EffectiveBalance")
                        .HasColumnType("bigint");

                    b.Property<string>("ErrorCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TransactionTime")
                        .HasColumnType("bigint");

                    b.Property<string>("UUID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountBalanceId")
                        .IsUnique();

                    b.ToTable("AccountBalanceResponces");
                });

            modelBuilder.Entity("Tipoul.Framework.StorageModels.AccountStatement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccessToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FromDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FromTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SourceAccount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ToDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ToTime")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AccountStatements");
                });

            modelBuilder.Entity("Tipoul.Framework.StorageModels.AccountStatementList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountStatementResponceId")
                        .HasColumnType("int");

                    b.Property<long>("Balance")
                        .HasColumnType("bigint");

                    b.Property<string>("BranchCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Credit")
                        .HasColumnType("bigint");

                    b.Property<long>("Debit")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DestinationAccount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SourceAccount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatementStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionIdentity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionTrace")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountStatementResponceId");

                    b.ToTable("AccountStatementList");
                });

            modelBuilder.Entity("Tipoul.Framework.StorageModels.AccountStatementResponce", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountStatementId")
                        .HasColumnType("int");

                    b.Property<string>("ErrorCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TransactionTime")
                        .HasColumnType("bigint");

                    b.Property<string>("UUID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountStatementId")
                        .IsUnique();

                    b.ToTable("AccountStatementResponces");
                });

            modelBuilder.Entity("Tipoul.Framework.StorageModels.CardInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccessToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SourceAccount")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CardInfos");
                });

            modelBuilder.Entity("Tipoul.Framework.StorageModels.CardInfoResponce", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CardInfoId")
                        .HasColumnType("int");

                    b.Property<string>("ErrorCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Iban")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TransactionTime")
                        .HasColumnType("bigint");

                    b.Property<string>("UUID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CardInfoId")
                        .IsUnique();

                    b.ToTable("CardInfoResponces");
                });

            modelBuilder.Entity("Tipoul.Framework.StorageModels.Iban", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccessToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SourceAccount")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ibans");
                });

            modelBuilder.Entity("Tipoul.Framework.StorageModels.IbanInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccessToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SourceAccount")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IbanInfos");
                });

            modelBuilder.Entity("Tipoul.Framework.StorageModels.IbanInfoResponce", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccountStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ErrorCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IbanInfoId")
                        .HasColumnType("int");

                    b.Property<string>("IbanNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TransactionTime")
                        .HasColumnType("bigint");

                    b.Property<string>("Uuid")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IbanInfoId")
                        .IsUnique();

                    b.ToTable("IbanInfoResponces");
                });

            modelBuilder.Entity("Tipoul.Framework.StorageModels.IbanResponce", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ErrorCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IbanId")
                        .HasColumnType("int");

                    b.Property<string>("IbanNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TransactionTime")
                        .HasColumnType("bigint");

                    b.Property<string>("Uuid")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IbanId")
                        .IsUnique();

                    b.ToTable("IbanResponces");
                });

            modelBuilder.Entity("Tipoul.Framework.StorageModels.TransactionInquiry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccessToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DestinationAccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RequestedUuid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SourceAccount")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TransactionInquirys");
                });

            modelBuilder.Entity("Tipoul.Framework.StorageModels.TransactionInquiryResponce", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Amount")
                        .HasColumnType("bigint");

                    b.Property<string>("DestinationAccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DestinationBank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ErrorCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RequestedUuid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RespCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Service")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SourceAccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SourceBank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TraceNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TransactionDate")
                        .HasColumnType("bigint");

                    b.Property<int>("TransactionInquiryId")
                        .HasColumnType("int");

                    b.Property<string>("TransactionState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TransactionTime")
                        .HasColumnType("bigint");

                    b.Property<string>("TransferType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Uuid")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TransactionInquiryId")
                        .IsUnique();

                    b.ToTable("TransactionInquiryResponces");
                });

            modelBuilder.Entity("Tipoul.Framework.StorageModels.Transfer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccessToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Amount")
                        .HasColumnType("bigint");

                    b.Property<string>("Babat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepositDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DestinationAccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DestinationBank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocumentID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SmsPass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SourceAccount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransferID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransferType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WithdrawDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Transfers");
                });

            modelBuilder.Entity("Tipoul.Framework.StorageModels.TransferResponce", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Amount")
                        .HasColumnType("bigint");

                    b.Property<string>("DestinationAccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DestinationBank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ErrorCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SourceAccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SourceBank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TraceNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TransactionTime")
                        .HasColumnType("bigint");

                    b.Property<int>("TransferId")
                        .HasColumnType("int");

                    b.Property<string>("TransferType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UUID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TransferId")
                        .IsUnique();

                    b.ToTable("TransferResponces");
                });

            modelBuilder.Entity("Tipoul.Framework.StorageModels.AccountBalanceResponce", b =>
                {
                    b.HasOne("Tipoul.Framework.StorageModels.AccountBalance", "AccountBalance")
                        .WithOne("AccountBalanceResponce")
                        .HasForeignKey("Tipoul.Framework.StorageModels.AccountBalanceResponce", "AccountBalanceId");

                    b.Navigation("AccountBalance");
                });

            modelBuilder.Entity("Tipoul.Framework.StorageModels.AccountStatementList", b =>
                {
                    b.HasOne("Tipoul.Framework.StorageModels.AccountStatementResponce", "AccountStatementResponce")
                        .WithMany("AccountStatementLists")
                        .HasForeignKey("AccountStatementResponceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccountStatementResponce");
                });

            modelBuilder.Entity("Tipoul.Framework.StorageModels.AccountStatementResponce", b =>
                {
                    b.HasOne("Tipoul.Framework.StorageModels.AccountStatement", "AccountStatement")
                        .WithOne("AccountStatementResponce")
                        .HasForeignKey("Tipoul.Framework.StorageModels.AccountStatementResponce", "AccountStatementId");

                    b.Navigation("AccountStatement");
                });

            modelBuilder.Entity("Tipoul.Framework.StorageModels.CardInfoResponce", b =>
                {
                    b.HasOne("Tipoul.Framework.StorageModels.CardInfo", "CardInfo")
                        .WithOne("CardInfoResponce")
                        .HasForeignKey("Tipoul.Framework.StorageModels.CardInfoResponce", "CardInfoId");

                    b.Navigation("CardInfo");
                });

            modelBuilder.Entity("Tipoul.Framework.StorageModels.IbanInfoResponce", b =>
                {
                    b.HasOne("Tipoul.Framework.StorageModels.IbanInfo", "IbanInfo")
                        .WithOne("IbanInfoResponce")
                        .HasForeignKey("Tipoul.Framework.StorageModels.IbanInfoResponce", "IbanInfoId");

                    b.Navigation("IbanInfo");
                });

            modelBuilder.Entity("Tipoul.Framework.StorageModels.IbanResponce", b =>
                {
                    b.HasOne("Tipoul.Framework.StorageModels.Iban", "Iban")
                        .WithOne("IbanResponce")
                        .HasForeignKey("Tipoul.Framework.StorageModels.IbanResponce", "IbanId");

                    b.Navigation("Iban");
                });

            modelBuilder.Entity("Tipoul.Framework.StorageModels.TransactionInquiryResponce", b =>
                {
                    b.HasOne("Tipoul.Framework.StorageModels.TransactionInquiry", "TransactionInquiry")
                        .WithOne("TransactionInquiryResponce")
                        .HasForeignKey("Tipoul.Framework.StorageModels.TransactionInquiryResponce", "TransactionInquiryId");

                    b.Navigation("TransactionInquiry");
                });

            modelBuilder.Entity("Tipoul.Framework.StorageModels.TransferResponce", b =>
                {
                    b.HasOne("Tipoul.Framework.StorageModels.Transfer", "Transfer")
                        .WithOne("TransferResponce")
                        .HasForeignKey("Tipoul.Framework.StorageModels.TransferResponce", "TransferId");

                    b.Navigation("Transfer");
                });

            modelBuilder.Entity("Tipoul.Framework.StorageModels.AccountBalance", b =>
                {
                    b.Navigation("AccountBalanceResponce");
                });

            modelBuilder.Entity("Tipoul.Framework.StorageModels.AccountStatement", b =>
                {
                    b.Navigation("AccountStatementResponce");
                });

            modelBuilder.Entity("Tipoul.Framework.StorageModels.AccountStatementResponce", b =>
                {
                    b.Navigation("AccountStatementLists");
                });

            modelBuilder.Entity("Tipoul.Framework.StorageModels.CardInfo", b =>
                {
                    b.Navigation("CardInfoResponce");
                });

            modelBuilder.Entity("Tipoul.Framework.StorageModels.Iban", b =>
                {
                    b.Navigation("IbanResponce");
                });

            modelBuilder.Entity("Tipoul.Framework.StorageModels.IbanInfo", b =>
                {
                    b.Navigation("IbanInfoResponce");
                });

            modelBuilder.Entity("Tipoul.Framework.StorageModels.TransactionInquiry", b =>
                {
                    b.Navigation("TransactionInquiryResponce");
                });

            modelBuilder.Entity("Tipoul.Framework.StorageModels.Transfer", b =>
                {
                    b.Navigation("TransferResponce");
                });
#pragma warning restore 612, 618
        }
    }
}
