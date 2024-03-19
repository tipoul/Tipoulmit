using Microsoft.EntityFrameworkCore.Migrations;

namespace Tipoul.Framework.DataAccessLayer.Migrations.TipoulShahinDb
{
    public partial class ShahinMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "AccountBalanceResponces",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<long>(
                name: "ErrorCode",
                table: "AccountBalanceResponces",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateTable(
                name: "Transfers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SourceAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DestinationAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DestinationBank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<long>(type: "bigint", nullable: false),
                    TransferType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Babat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransferID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepositDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WithdrawDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SmsPass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccessToken = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransferResponces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionTime = table.Column<long>(type: "bigint", nullable: false),
                    UUID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SourceAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DestinationAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<long>(type: "bigint", nullable: false),
                    SourceBank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DestinationBank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransferType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TraceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorCode = table.Column<long>(type: "bigint", nullable: true),
                    TransferId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferResponces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransferResponces_Transfers_TransferId",
                        column: x => x.TransferId,
                        principalTable: "Transfers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransferResponces_TransferId",
                table: "TransferResponces",
                column: "TransferId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransferResponces");

            migrationBuilder.DropTable(
                name: "Transfers");

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "AccountBalanceResponces",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ErrorCode",
                table: "AccountBalanceResponces",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);
        }
    }
}
