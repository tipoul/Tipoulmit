using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tipoul.Framework.DataAccessLayer.Migrations
{
    public partial class somechangesinsepehrrequestlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MerchantNumber",
                table: "CommertialGateWays",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TerminalNumber",
                table: "CommertialGateWays",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "UserCommertialGateWayRegisterRequestLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CommertialGateWayId = table.Column<int>(type: "int", nullable: false),
                    SepehrLoginId = table.Column<int>(type: "int", nullable: true),
                    SepehrLoginUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Service = table.Column<int>(type: "int", nullable: false),
                    ErrorCode = table.Column<int>(type: "int", nullable: true),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TerminalNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MerchantNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCommertialGateWayRegisterRequestLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCommertialGateWayRegisterRequestLogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCommertialGateWayRegisterRequestLogs_UserId",
                table: "UserCommertialGateWayRegisterRequestLogs",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCommertialGateWayRegisterRequestLogs");

            migrationBuilder.DropColumn(
                name: "MerchantNumber",
                table: "CommertialGateWays");

            migrationBuilder.DropColumn(
                name: "TerminalNumber",
                table: "CommertialGateWays");
        }
    }
}
