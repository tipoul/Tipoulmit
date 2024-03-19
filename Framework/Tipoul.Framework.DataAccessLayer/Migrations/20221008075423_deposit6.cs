using Microsoft.EntityFrameworkCore.Migrations;

namespace Tipoul.Framework.DataAccessLayer.Migrations
{
    public partial class deposit6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WalletDepositRequests_WalletId",
                table: "WalletDepositRequests");

            migrationBuilder.AlterColumn<string>(
                name: "TransactionTrace",
                table: "WalletDepositRequests",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "TransactionDate",
                table: "WalletDepositRequests",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_WalletDepositRequests_WalletId_Amount_TransactionTrace_TransactionDate",
                table: "WalletDepositRequests",
                columns: new[] { "WalletId", "Amount", "TransactionTrace", "TransactionDate" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WalletDepositRequests_WalletId_Amount_TransactionTrace_TransactionDate",
                table: "WalletDepositRequests");

            migrationBuilder.AlterColumn<string>(
                name: "TransactionTrace",
                table: "WalletDepositRequests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "TransactionDate",
                table: "WalletDepositRequests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_WalletDepositRequests_WalletId",
                table: "WalletDepositRequests",
                column: "WalletId");
        }
    }
}
