using Microsoft.EntityFrameworkCore.Migrations;

namespace Tipoul.Framework.DataAccessLayer.Migrations.TipoulShahinDb
{
    public partial class ShahinMigration7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IbanInfos",
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
                    table.PrimaryKey("PK_IbanInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ibans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SourceAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccessToken = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ibans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionInquirys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SourceAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DestinationAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestedUuid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccessToken = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionInquirys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IbanInfoResponces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionTime = table.Column<long>(type: "bigint", nullable: false),
                    Uuid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IbanNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IbanInfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IbanInfoResponces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IbanInfoResponces_IbanInfos_IbanInfoId",
                        column: x => x.IbanInfoId,
                        principalTable: "IbanInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IbanResponces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionTime = table.Column<long>(type: "bigint", nullable: false),
                    Uuid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IbanNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IbanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IbanResponces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IbanResponces_Ibans_IbanId",
                        column: x => x.IbanId,
                        principalTable: "Ibans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransactionInquiryResponces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionTime = table.Column<long>(type: "bigint", nullable: false),
                    Uuid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestedUuid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Service = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SourceAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DestinationAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<long>(type: "bigint", nullable: false),
                    TransactionDate = table.Column<long>(type: "bigint", nullable: false),
                    SourceBank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DestinationBank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TraceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RespCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransferType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionInquiryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionInquiryResponces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionInquiryResponces_TransactionInquirys_TransactionInquiryId",
                        column: x => x.TransactionInquiryId,
                        principalTable: "TransactionInquirys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IbanInfoResponces_IbanInfoId",
                table: "IbanInfoResponces",
                column: "IbanInfoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IbanResponces_IbanId",
                table: "IbanResponces",
                column: "IbanId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionInquiryResponces_TransactionInquiryId",
                table: "TransactionInquiryResponces",
                column: "TransactionInquiryId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IbanInfoResponces");

            migrationBuilder.DropTable(
                name: "IbanResponces");

            migrationBuilder.DropTable(
                name: "TransactionInquiryResponces");

            migrationBuilder.DropTable(
                name: "IbanInfos");

            migrationBuilder.DropTable(
                name: "Ibans");

            migrationBuilder.DropTable(
                name: "TransactionInquirys");
        }
    }
}
