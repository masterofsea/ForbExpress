using Microsoft.EntityFrameworkCore.Migrations;

namespace ForbExpress.Migrations
{
    public partial class ChangedContractAndMailContractEntitiesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_MailContracts_MailId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_MailId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "Hd",
                table: "MailContracts");

            migrationBuilder.DropColumn(
                name: "MailId",
                table: "Contracts");

            migrationBuilder.RenameColumn(
                name: "Proxy",
                table: "MailContracts",
                newName: "HasProxy");

            migrationBuilder.RenameColumn(
                name: "PostalServiceContractNumber",
                table: "MailContracts",
                newName: "MailContractNumber");

            migrationBuilder.RenameColumn(
                name: "LeaseStartDate",
                table: "MailContracts",
                newName: "LeaseBeginDate");

            migrationBuilder.AddColumn<bool>(
                name: "DocumentsStorage",
                table: "Contracts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MailContractId",
                table: "Contracts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_MailContractId",
                table: "Contracts",
                column: "MailContractId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_MailContracts_MailContractId",
                table: "Contracts",
                column: "MailContractId",
                principalTable: "MailContracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_MailContracts_MailContractId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_MailContractId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "DocumentsStorage",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "MailContractId",
                table: "Contracts");

            migrationBuilder.RenameColumn(
                name: "MailContractNumber",
                table: "MailContracts",
                newName: "PostalServiceContractNumber");

            migrationBuilder.RenameColumn(
                name: "LeaseBeginDate",
                table: "MailContracts",
                newName: "LeaseStartDate");

            migrationBuilder.RenameColumn(
                name: "HasProxy",
                table: "MailContracts",
                newName: "Proxy");

            migrationBuilder.AddColumn<bool>(
                name: "Hd",
                table: "MailContracts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MailId",
                table: "Contracts",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_MailId",
                table: "Contracts",
                column: "MailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_MailContracts_MailId",
                table: "Contracts",
                column: "MailId",
                principalTable: "MailContracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
