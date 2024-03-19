using Microsoft.EntityFrameworkCore.Migrations;

namespace Tipoul.Framework.DataAccessLayer.Migrations
{
    public partial class addwagetypehistorytodbcontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserWageTypeHistory_Users_UserId",
                table: "UserWageTypeHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserWageTypeHistory",
                table: "UserWageTypeHistory");

            migrationBuilder.RenameTable(
                name: "UserWageTypeHistory",
                newName: "UserWageTypeHistories");

            migrationBuilder.RenameIndex(
                name: "IX_UserWageTypeHistory_UserId",
                table: "UserWageTypeHistories",
                newName: "IX_UserWageTypeHistories_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserWageTypeHistories",
                table: "UserWageTypeHistories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserWageTypeHistories_Users_UserId",
                table: "UserWageTypeHistories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserWageTypeHistories_Users_UserId",
                table: "UserWageTypeHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserWageTypeHistories",
                table: "UserWageTypeHistories");

            migrationBuilder.RenameTable(
                name: "UserWageTypeHistories",
                newName: "UserWageTypeHistory");

            migrationBuilder.RenameIndex(
                name: "IX_UserWageTypeHistories_UserId",
                table: "UserWageTypeHistory",
                newName: "IX_UserWageTypeHistory_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserWageTypeHistory",
                table: "UserWageTypeHistory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserWageTypeHistory_Users_UserId",
                table: "UserWageTypeHistory",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
