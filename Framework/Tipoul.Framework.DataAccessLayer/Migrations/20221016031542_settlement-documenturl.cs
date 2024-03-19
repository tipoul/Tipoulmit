using Microsoft.EntityFrameworkCore.Migrations;

namespace Tipoul.Framework.DataAccessLayer.Migrations
{
    public partial class settlementdocumenturl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "requestedUuid",
                table: "Settlements",
                newName: "RequestedUuid");

            migrationBuilder.AddColumn<string>(
                name: "DocutmentURL",
                table: "Settlements",
                type: "nvarchar(max)",
                nullable: true);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocutmentURL",
                table: "Settlements");

            migrationBuilder.RenameColumn(
                name: "RequestedUuid",
                table: "Settlements",
                newName: "requestedUuid");
        }
    }
}
