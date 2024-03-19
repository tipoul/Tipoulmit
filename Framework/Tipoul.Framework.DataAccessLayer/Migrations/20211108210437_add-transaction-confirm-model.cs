using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tipoul.Framework.DataAccessLayer.Migrations
{
    public partial class addtransactionconfirmmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RedirectToGateWay",
                table: "Transactions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransactionConfirmModelId",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "TransactionModels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "GetTokenResult",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "TransactionConfirmModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactorNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionConfirmModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionConfirmModelId",
                table: "Transactions",
                column: "TransactionConfirmModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_TransactionConfirmModel_TransactionConfirmModelId",
                table: "Transactions",
                column: "TransactionConfirmModelId",
                principalTable: "TransactionConfirmModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_TransactionConfirmModel_TransactionConfirmModelId",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "TransactionConfirmModel");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_TransactionConfirmModelId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "RedirectToGateWay",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "TransactionConfirmModelId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "TransactionModels");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "GetTokenResult");
        }
    }
}
