using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tipoul.Framework.Services.RequestLog.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IranKishGateWayRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Success = table.Column<bool>(type: "bit", nullable: false),
                    Response = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IranKishGateWayRequestExceptionId = table.Column<int>(type: "int", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraParameter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IranKishGateWayRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SepehrGateWayRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Success = table.Column<bool>(type: "bit", nullable: false),
                    Response = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SepehrgateWayRequestExceptionId = table.Column<int>(type: "int", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraParameter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SepehrGateWayRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SepehrRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Success = table.Column<bool>(type: "bit", nullable: false),
                    Response = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SepehrRequestExceptionId = table.Column<int>(type: "int", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraParameter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SepehrRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShaparakRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Success = table.Column<bool>(type: "bit", nullable: false),
                    Response = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShaparakRequestExceptionId = table.Column<int>(type: "int", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraParameter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShaparakRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShaparakTaxRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackingCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Success = table.Column<bool>(type: "bit", nullable: false),
                    Response = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShaparakTaxRequestExceptionId = table.Column<int>(type: "int", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraParameter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShaparakTaxRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IranKishGateWayRequestExceptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IranKishGateWayRequestId = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StackTrace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InnerMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InnerStackTrace = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IranKishGateWayRequestExceptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IranKishGateWayRequestExceptions_IranKishGateWayRequests_IranKishGateWayRequestId",
                        column: x => x.IranKishGateWayRequestId,
                        principalTable: "IranKishGateWayRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SepehrGateWayRequestExceptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SepehrGateWayReuqestId = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StackTrace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InnerMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InnerStackTrace = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SepehrGateWayRequestExceptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SepehrGateWayRequestExceptions_SepehrGateWayRequests_SepehrGateWayReuqestId",
                        column: x => x.SepehrGateWayReuqestId,
                        principalTable: "SepehrGateWayRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SepehrRequestExceptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SepehrRequestId = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StackTrace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InnerMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InnerStackTrace = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SepehrRequestExceptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SepehrRequestExceptions_SepehrRequests_SepehrRequestId",
                        column: x => x.SepehrRequestId,
                        principalTable: "SepehrRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShaparakRequestExceptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShaparakRequestId = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StackTrace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InnerMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InnerStackTrace = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShaparakRequestExceptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShaparakRequestExceptions_ShaparakRequests_ShaparakRequestId",
                        column: x => x.ShaparakRequestId,
                        principalTable: "ShaparakRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShaparakTaxRequestExceptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShaparakTaxRequestId = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StackTrace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InnerMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InnerStackTrace = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShaparakTaxRequestExceptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShaparakTaxRequestExceptions_ShaparakTaxRequests_ShaparakTaxRequestId",
                        column: x => x.ShaparakTaxRequestId,
                        principalTable: "ShaparakTaxRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IranKishGateWayRequestExceptions_IranKishGateWayRequestId",
                table: "IranKishGateWayRequestExceptions",
                column: "IranKishGateWayRequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SepehrGateWayRequestExceptions_SepehrGateWayReuqestId",
                table: "SepehrGateWayRequestExceptions",
                column: "SepehrGateWayReuqestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SepehrRequestExceptions_SepehrRequestId",
                table: "SepehrRequestExceptions",
                column: "SepehrRequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShaparakRequestExceptions_ShaparakRequestId",
                table: "ShaparakRequestExceptions",
                column: "ShaparakRequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShaparakTaxRequestExceptions_ShaparakTaxRequestId",
                table: "ShaparakTaxRequestExceptions",
                column: "ShaparakTaxRequestId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IranKishGateWayRequestExceptions");

            migrationBuilder.DropTable(
                name: "SepehrGateWayRequestExceptions");

            migrationBuilder.DropTable(
                name: "SepehrRequestExceptions");

            migrationBuilder.DropTable(
                name: "ShaparakRequestExceptions");

            migrationBuilder.DropTable(
                name: "ShaparakTaxRequestExceptions");

            migrationBuilder.DropTable(
                name: "IranKishGateWayRequests");

            migrationBuilder.DropTable(
                name: "SepehrGateWayRequests");

            migrationBuilder.DropTable(
                name: "SepehrRequests");

            migrationBuilder.DropTable(
                name: "ShaparakRequests");

            migrationBuilder.DropTable(
                name: "ShaparakTaxRequests");
        }
    }
}
