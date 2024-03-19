using Microsoft.EntityFrameworkCore.Migrations;

namespace Tipoul.Framework.DataAccessLayer.Migrations
{
    public partial class addwagehistoryreferencetotransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserWageHistoryId",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserWageHistoryId",
                table: "Transactions",
                column: "UserWageHistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_UserWageHistories_UserWageHistoryId",
                table: "Transactions",
                column: "UserWageHistoryId",
                principalTable: "UserWageHistories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_UserWageHistories_UserWageHistoryId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_UserWageHistoryId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "UserWageHistoryId",
                table: "Transactions");
        }
    }
}
