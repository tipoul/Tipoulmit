using Microsoft.EntityFrameworkCore.Migrations;

namespace Tipoul.Framework.DataAccessLayer.Migrations
{
    public partial class addtracktracenumbertogatewayservice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FactorNumber",
                table: "TransactionConfirmModel",
                newName: "TipoulTraceNumber");

            migrationBuilder.AddColumn<string>(
                name: "TipoulTraceNumber",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TipoulTrackNumber",
                table: "TransactionResponses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TipoulTrackNumber",
                table: "TransactionConfirmResult",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TipoulTrackNumber",
                table: "GetTokenResult",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoulTraceNumber",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "TipoulTrackNumber",
                table: "TransactionResponses");

            migrationBuilder.DropColumn(
                name: "TipoulTrackNumber",
                table: "TransactionConfirmResult");

            migrationBuilder.DropColumn(
                name: "TipoulTrackNumber",
                table: "GetTokenResult");

            migrationBuilder.RenameColumn(
                name: "TipoulTraceNumber",
                table: "TransactionConfirmModel",
                newName: "FactorNumber");
        }
    }
}
