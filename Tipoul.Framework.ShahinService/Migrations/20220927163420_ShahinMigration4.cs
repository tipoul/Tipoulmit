using Microsoft.EntityFrameworkCore.Migrations;

namespace Tipoul.Framework.DataAccessLayer.Migrations.TipoulShahinDb
{
    public partial class ShahinMigration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountStatementList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Debit = table.Column<long>(type: "bigint", nullable: false),
                    Credit = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Balance = table.Column<long>(type: "bigint", nullable: false),
                    TransactionTrace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionIdentity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatementStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SourceAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DestinationAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountStatementResponceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountStatementList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountStatementList_AccountStatementResponces_AccountStatementResponceId",
                        column: x => x.AccountStatementResponceId,
                        principalTable: "AccountStatementResponces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountStatementList_AccountStatementResponceId",
                table: "AccountStatementList",
                column: "AccountStatementResponceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountStatementList");
        }
    }
}
