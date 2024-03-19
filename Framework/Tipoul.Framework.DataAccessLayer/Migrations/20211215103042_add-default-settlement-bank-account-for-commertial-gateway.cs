using Microsoft.EntityFrameworkCore.Migrations;

namespace Tipoul.Framework.DataAccessLayer.Migrations
{
    public partial class adddefaultsettlementbankaccountforcommertialgateway : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DefaultBankAccountId",
                table: "CommertialGateWays",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommertialGateWays_DefaultBankAccountId",
                table: "CommertialGateWays",
                column: "DefaultBankAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommertialGateWays_BankAccounts_DefaultBankAccountId",
                table: "CommertialGateWays",
                column: "DefaultBankAccountId",
                principalTable: "BankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommertialGateWays_BankAccounts_DefaultBankAccountId",
                table: "CommertialGateWays");

            migrationBuilder.DropIndex(
                name: "IX_CommertialGateWays_DefaultBankAccountId",
                table: "CommertialGateWays");

            migrationBuilder.DropColumn(
                name: "DefaultBankAccountId",
                table: "CommertialGateWays");
        }
    }
}
