using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tipoul.Framework.DataAccessLayer.Migrations
{
    public partial class addsomefieldstobankaccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "BankAccounts",
                newName: "NationalCode");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "BankAccounts",
                newName: "FullName");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "BankAccounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "BankAccounts");

            migrationBuilder.RenameColumn(
                name: "NationalCode",
                table: "BankAccounts",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "BankAccounts",
                newName: "FirstName");
        }
    }
}
