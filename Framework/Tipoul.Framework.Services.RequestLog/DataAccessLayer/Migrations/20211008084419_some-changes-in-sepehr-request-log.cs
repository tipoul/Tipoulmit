using Microsoft.EntityFrameworkCore.Migrations;

namespace Tipoul.Framework.Services.RequestLog.Migrations
{
    public partial class somechangesinsepehrrequestlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SepehrRequestLogId",
                table: "SepehrRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SepehrRequestLogId",
                table: "SepehrRequests");
        }
    }
}
