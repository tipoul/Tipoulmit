using Microsoft.EntityFrameworkCore.Migrations;

namespace Tipoul.Framework.DataAccessLayer.Migrations
{
    public partial class wagetype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuickSettlementWagePercent",
                table: "Users");

            migrationBuilder.AddColumn<double>(
                name: "QuickSettlementWagePercent",
                table: "UserWageTypeHistories",
                type: "float",
                nullable: true);

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuickSettlementWagePercent",
                table: "UserWageTypeHistories");

            migrationBuilder.DropColumn(
                name: "requestedUuid",
                table: "Settlements");

            migrationBuilder.AddColumn<double>(
                name: "QuickSettlementWagePercent",
                table: "Users",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
