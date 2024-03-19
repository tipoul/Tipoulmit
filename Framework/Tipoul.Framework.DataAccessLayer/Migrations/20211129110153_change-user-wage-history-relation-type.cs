using Microsoft.EntityFrameworkCore.Migrations;

namespace Tipoul.Framework.DataAccessLayer.Migrations
{
    public partial class changeuserwagehistoryrelationtype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserWageHistories_Users_UserId",
                table: "UserWageHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_UserWageHistories_Users_UserId1",
                table: "UserWageHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_UserWageHistories_UserWageTypeHistories_UserWageTypeHistoryId",
                table: "UserWageHistories");

            migrationBuilder.DropIndex(
                name: "IX_UserWageHistories_UserId",
                table: "UserWageHistories");

            migrationBuilder.DropIndex(
                name: "IX_UserWageHistories_UserWageTypeHistoryId",
                table: "UserWageHistories");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "UserWageHistories",
                newName: "UserWageTypeHistoryId1");

            migrationBuilder.RenameIndex(
                name: "IX_UserWageHistories_UserId1",
                table: "UserWageHistories",
                newName: "IX_UserWageHistories_UserWageTypeHistoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserWageHistories_UserId",
                table: "UserWageHistories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWageHistories_UserWageTypeHistoryId",
                table: "UserWageHistories",
                column: "UserWageTypeHistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserWageHistories_Users_UserId",
                table: "UserWageHistories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserWageHistories_Users_UserWageTypeHistoryId",
                table: "UserWageHistories",
                column: "UserWageTypeHistoryId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserWageHistories_UserWageTypeHistories_UserWageTypeHistoryId1",
                table: "UserWageHistories",
                column: "UserWageTypeHistoryId1",
                principalTable: "UserWageTypeHistories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserWageHistories_Users_UserId",
                table: "UserWageHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_UserWageHistories_Users_UserWageTypeHistoryId",
                table: "UserWageHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_UserWageHistories_UserWageTypeHistories_UserWageTypeHistoryId1",
                table: "UserWageHistories");

            migrationBuilder.DropIndex(
                name: "IX_UserWageHistories_UserId",
                table: "UserWageHistories");

            migrationBuilder.DropIndex(
                name: "IX_UserWageHistories_UserWageTypeHistoryId",
                table: "UserWageHistories");

            migrationBuilder.RenameColumn(
                name: "UserWageTypeHistoryId1",
                table: "UserWageHistories",
                newName: "UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_UserWageHistories_UserWageTypeHistoryId1",
                table: "UserWageHistories",
                newName: "IX_UserWageHistories_UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserWageHistories_UserId",
                table: "UserWageHistories",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserWageHistories_UserWageTypeHistoryId",
                table: "UserWageHistories",
                column: "UserWageTypeHistoryId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserWageHistories_Users_UserId",
                table: "UserWageHistories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserWageHistories_Users_UserId1",
                table: "UserWageHistories",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserWageHistories_UserWageTypeHistories_UserWageTypeHistoryId",
                table: "UserWageHistories",
                column: "UserWageTypeHistoryId",
                principalTable: "UserWageTypeHistories",
                principalColumn: "Id");
        }
    }
}
