using Microsoft.EntityFrameworkCore.Migrations;

namespace Tipoul.Framework.DataAccessLayer.Migrations.TipoulShahinDb
{
    public partial class ShahinMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountBalances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SourceAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccessToken = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountBalances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountBalanceResponces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionTime = table.Column<long>(type: "bigint", nullable: false),
                    UUID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvailableBalance = table.Column<long>(type: "bigint", nullable: false),
                    EffectiveBalance = table.Column<long>(type: "bigint", nullable: false),
                    AccountType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ErrorCode = table.Column<long>(type: "bigint", nullable: false),
                    AccountBalanceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountBalanceResponces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountBalanceResponces_AccountBalances_AccountBalanceId",
                        column: x => x.AccountBalanceId,
                        principalTable: "AccountBalances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountBalanceResponces_AccountBalanceId",
                table: "AccountBalanceResponces",
                column: "AccountBalanceId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountBalanceResponces");

            migrationBuilder.DropTable(
                name: "AccountBalances");
        }
    }
}
