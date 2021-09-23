using Microsoft.EntityFrameworkCore.Migrations;

namespace ForbExpress.Migrations
{
    public partial class AddedPaymentFormForContractMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentForm",
                table: "Contracts",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentForm",
                table: "Contracts");
        }
    }
}
