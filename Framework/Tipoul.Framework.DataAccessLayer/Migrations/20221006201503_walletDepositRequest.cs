using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tipoul.Framework.DataAccessLayer.Migrations
{
    public partial class walletDepositRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WalletDepositRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    WalletId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<long>(type: "bigint", nullable: false),
                    AmountAfterDeposit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionTrace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SourceOwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SourceOwnerNationalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SourceBank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SourceAcountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SourceIbanNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DestIbanNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepositType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletDepositRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WalletDepositRequests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WalletDepositRequests_Wallets_WalletId",
                        column: x => x.WalletId,
                        principalTable: "Wallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WalletDepositRequestStatusHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WalletDepositRequestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletDepositRequestStatusHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WalletDepositRequestStatusHistories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WalletDepositRequestStatusHistories_WalletDepositRequests_WalletDepositRequestId",
                        column: x => x.WalletDepositRequestId,
                        principalTable: "WalletDepositRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WalletDepositRequests_UserId",
                table: "WalletDepositRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WalletDepositRequests_WalletId",
                table: "WalletDepositRequests",
                column: "WalletId");

            migrationBuilder.CreateIndex(
                name: "IX_WalletDepositRequestStatusHistories_UserId",
                table: "WalletDepositRequestStatusHistories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WalletDepositRequestStatusHistories_WalletDepositRequestId",
                table: "WalletDepositRequestStatusHistories",
                column: "WalletDepositRequestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WalletDepositRequestStatusHistories");

            migrationBuilder.DropTable(
                name: "WalletDepositRequests");
        }
    }
}
