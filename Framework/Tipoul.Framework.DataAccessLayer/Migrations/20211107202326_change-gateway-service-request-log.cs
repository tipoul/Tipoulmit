using Microsoft.EntityFrameworkCore.Migrations;

namespace Tipoul.Framework.DataAccessLayer.Migrations
{
    public partial class changegatewayservicerequestlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_TransactionModels_TransactionModelId",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "TransactionModelId",
                table: "Transactions",
                newName: "GetTokenResultId");

            migrationBuilder.RenameColumn(
                name: "TokenErrorMessage",
                table: "Transactions",
                newName: "ISPAccessTokenErrorMessage");

            migrationBuilder.RenameColumn(
                name: "Token",
                table: "Transactions",
                newName: "ISPAccessToken");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_TransactionModelId",
                table: "Transactions",
                newName: "IX_Transactions_GetTokenResultId");

            migrationBuilder.AddColumn<int>(
                name: "GetTokenModelId",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestId",
                table: "TransactionModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GetTokenResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoulAccessToken = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetTokenResult", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_GetTokenModelId",
                table: "Transactions",
                column: "GetTokenModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_GetTokenResult_GetTokenResultId",
                table: "Transactions",
                column: "GetTokenResultId",
                principalTable: "GetTokenResult",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_TransactionModels_GetTokenModelId",
                table: "Transactions",
                column: "GetTokenModelId",
                principalTable: "TransactionModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_GetTokenResult_GetTokenResultId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_TransactionModels_GetTokenModelId",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "GetTokenResult");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_GetTokenModelId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "GetTokenModelId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "TransactionModels");

            migrationBuilder.RenameColumn(
                name: "ISPAccessTokenErrorMessage",
                table: "Transactions",
                newName: "TokenErrorMessage");

            migrationBuilder.RenameColumn(
                name: "ISPAccessToken",
                table: "Transactions",
                newName: "Token");

            migrationBuilder.RenameColumn(
                name: "GetTokenResultId",
                table: "Transactions",
                newName: "TransactionModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_GetTokenResultId",
                table: "Transactions",
                newName: "IX_Transactions_TransactionModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_TransactionModels_TransactionModelId",
                table: "Transactions",
                column: "TransactionModelId",
                principalTable: "TransactionModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
