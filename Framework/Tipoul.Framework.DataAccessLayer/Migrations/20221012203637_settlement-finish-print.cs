using Microsoft.EntityFrameworkCore.Migrations;

namespace Tipoul.Framework.DataAccessLayer.Migrations
{
    public partial class settlementfinishprint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "QuickSettlementWagePercent",
                table: "UserWageTypeHistories",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "AccountNumber",
                table: "Settlements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Babat",
                table: "Settlements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Bank",
                table: "Settlements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CardNumber",
                table: "Settlements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IbanNumber",
                table: "Settlements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OwnerName",
                table: "Settlements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sharh",
                table: "Settlements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TransferType",
                table: "Settlements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "Settlements");

            migrationBuilder.DropColumn(
                name: "Babat",
                table: "Settlements");

            migrationBuilder.DropColumn(
                name: "Bank",
                table: "Settlements");

            migrationBuilder.DropColumn(
                name: "CardNumber",
                table: "Settlements");

            migrationBuilder.DropColumn(
                name: "IbanNumber",
                table: "Settlements");

            migrationBuilder.DropColumn(
                name: "OwnerName",
                table: "Settlements");

            migrationBuilder.DropColumn(
                name: "Sharh",
                table: "Settlements");

            migrationBuilder.DropColumn(
                name: "TransferType",
                table: "Settlements");

            migrationBuilder.AlterColumn<double>(
                name: "QuickSettlementWagePercent",
                table: "UserWageTypeHistories",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);
        }
    }
}
