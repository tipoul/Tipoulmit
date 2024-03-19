using Microsoft.EntityFrameworkCore.Migrations;

namespace Tipoul.Framework.DataAccessLayer.Migrations
{
    public partial class addpsptotransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SelectedPSP",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SelectedPSP",
                table: "Transactions");
        }
    }
}
