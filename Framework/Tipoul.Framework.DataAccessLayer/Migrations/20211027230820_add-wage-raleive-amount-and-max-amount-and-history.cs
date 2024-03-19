using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tipoul.Framework.DataAccessLayer.Migrations
{
    public partial class addwageraleiveamountandmaxamountandhistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxRelativeAmount",
                table: "UserWageTypeHistories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RelativeAmount",
                table: "UserWageTypeHistories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserWageHistoryId",
                table: "Settlements",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserWageHistoryId2",
                table: "Settlements",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserWageHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserWageTypeHistoryId = table.Column<int>(type: "int", nullable: false),
                    SettlementId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWageHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserWageHistories_Settlements_SettlementId",
                        column: x => x.SettlementId,
                        principalTable: "Settlements",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserWageHistories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserWageHistories_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserWageHistories_UserWageTypeHistories_UserWageTypeHistoryId",
                        column: x => x.UserWageTypeHistoryId,
                        principalTable: "UserWageTypeHistories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Settlements_UserWageHistoryId2",
                table: "Settlements",
                column: "UserWageHistoryId2");

            migrationBuilder.CreateIndex(
                name: "IX_UserWageHistories_SettlementId",
                table: "UserWageHistories",
                column: "SettlementId",
                unique: true,
                filter: "[SettlementId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserWageHistories_UserId",
                table: "UserWageHistories",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserWageHistories_UserId1",
                table: "UserWageHistories",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserWageHistories_UserWageTypeHistoryId",
                table: "UserWageHistories",
                column: "UserWageTypeHistoryId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Settlements_UserWageHistories_UserWageHistoryId2",
                table: "Settlements",
                column: "UserWageHistoryId2",
                principalTable: "UserWageHistories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Settlements_UserWageHistories_UserWageHistoryId2",
                table: "Settlements");

            migrationBuilder.DropTable(
                name: "UserWageHistories");

            migrationBuilder.DropIndex(
                name: "IX_Settlements_UserWageHistoryId2",
                table: "Settlements");

            migrationBuilder.DropColumn(
                name: "MaxRelativeAmount",
                table: "UserWageTypeHistories");

            migrationBuilder.DropColumn(
                name: "RelativeAmount",
                table: "UserWageTypeHistories");

            migrationBuilder.DropColumn(
                name: "UserWageHistoryId",
                table: "Settlements");

            migrationBuilder.DropColumn(
                name: "UserWageHistoryId2",
                table: "Settlements");
        }
    }
}
