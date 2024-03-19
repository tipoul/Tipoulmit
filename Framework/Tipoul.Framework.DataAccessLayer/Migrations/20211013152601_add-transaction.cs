using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tipoul.Framework.DataAccessLayer.Migrations
{
    public partial class addtransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransactionConfirmResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ReturnId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionConfirmResult", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GateToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    CallBackUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayerMobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FactorNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayerMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValidCardNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlankForPayer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlankForTransaction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IPG = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionResponses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RespCode = table.Column<int>(type: "int", nullable: false),
                    RespMsg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<long>(type: "bigint", nullable: false),
                    InvoiceId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Payload = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TerminalId = table.Column<long>(type: "bigint", nullable: false),
                    TraceNumber = table.Column<long>(type: "bigint", nullable: false),
                    RRN = table.Column<long>(type: "bigint", nullable: false),
                    DatePaid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DigitalReceipt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssuerBank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionResponses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TokenErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GateWayId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionModelId = table.Column<int>(type: "int", nullable: true),
                    TransactionResponseId = table.Column<int>(type: "int", nullable: true),
                    TransactionConfirmResultId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_CommertialGateWays_GateWayId",
                        column: x => x.GateWayId,
                        principalTable: "CommertialGateWays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_TransactionConfirmResult_TransactionConfirmResultId",
                        column: x => x.TransactionConfirmResultId,
                        principalTable: "TransactionConfirmResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_TransactionModels_TransactionModelId",
                        column: x => x.TransactionModelId,
                        principalTable: "TransactionModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_TransactionResponses_TransactionResponseId",
                        column: x => x.TransactionResponseId,
                        principalTable: "TransactionResponses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_GateWayId",
                table: "Transactions",
                column: "GateWayId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionConfirmResultId",
                table: "Transactions",
                column: "TransactionConfirmResultId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionModelId",
                table: "Transactions",
                column: "TransactionModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionResponseId",
                table: "Transactions",
                column: "TransactionResponseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "TransactionConfirmResult");

            migrationBuilder.DropTable(
                name: "TransactionModels");

            migrationBuilder.DropTable(
                name: "TransactionResponses");
        }
    }
}
