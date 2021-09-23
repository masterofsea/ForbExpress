using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ForbExpress.Migrations
{
    public partial class ContractsTableAddedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Partners",
                type: "character varying(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Lessee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    ShortName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Inn = table.Column<string>(type: "text", nullable: false),
                    Bank = table.Column<string>(type: "text", nullable: true),
                    Bic = table.Column<string>(type: "text", nullable: true),
                    Ogrn = table.Column<string>(type: "text", nullable: true),
                    Kpp = table.Column<string>(type: "text", nullable: true),
                    CheckingAccount = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MailContracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ConclusionDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PostalServiceContractNumber = table.Column<string>(type: "text", nullable: true),
                    LeaseStartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LeaseEndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LeaseTerm = table.Column<int>(type: "integer", nullable: false),
                    Proxy = table.Column<bool>(type: "boolean", nullable: false),
                    Price1 = table.Column<decimal>(type: "numeric", nullable: false),
                    Price2 = table.Column<decimal>(type: "numeric", nullable: false),
                    ControlDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Responsible = table.Column<string>(type: "text", nullable: true),
                    Hd = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailContracts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContractState = table.Column<int>(type: "integer", nullable: false),
                    ConclusionDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Ifts = table.Column<int>(type: "integer", nullable: false),
                    ContractNumber = table.Column<string>(type: "text", nullable: true),
                    LeaseStartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LeaseEndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LeaseTerm = table.Column<int>(type: "integer", nullable: false),
                    RegistrationType = table.Column<int>(type: "integer", nullable: false),
                    PartnerId = table.Column<int>(type: "integer", nullable: false),
                    LesseeId = table.Column<int>(type: "integer", nullable: false),
                    Price1 = table.Column<decimal>(type: "numeric", nullable: false),
                    Price2 = table.Column<decimal>(type: "numeric", nullable: false),
                    Paid = table.Column<bool>(type: "boolean", nullable: false),
                    Penalty = table.Column<decimal>(type: "numeric", nullable: false),
                    IsReturnableCopy = table.Column<bool>(type: "boolean", nullable: false),
                    MonthlyActs = table.Column<bool>(type: "boolean", nullable: false),
                    MailId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_Lessee_LesseeId",
                        column: x => x.LesseeId,
                        principalTable: "Lessee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_MailContracts_MailId",
                        column: x => x.MailId,
                        principalTable: "MailContracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contracts_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_LesseeId",
                table: "Contracts",
                column: "LesseeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_MailId",
                table: "Contracts",
                column: "MailId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_PartnerId",
                table: "Contracts",
                column: "PartnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "Lessee");

            migrationBuilder.DropTable(
                name: "MailContracts");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Partners",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(64)",
                oldMaxLength: 64);
        }
    }
}
