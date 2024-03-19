using Microsoft.EntityFrameworkCore.Migrations;

namespace Tipoul.Framework.DataAccessLayer.Migrations
{
    public partial class settlement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AmountInBankAfterSettlement",
                table: "Settlements",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "AmountInTipoulAfterSettlement",
                table: "Settlements",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountInBankAfterSettlement",
                table: "Settlements");

            migrationBuilder.DropColumn(
                name: "AmountInTipoulAfterSettlement",
                table: "Settlements");
        }
    }
}
