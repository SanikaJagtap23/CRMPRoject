using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class ChangeMistake : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoiceTermsAndConditionTbl_SalesInvoiceTermsAndConditionTbl_SalesInvoiceTermsAndConditionID1",
                table: "SalesInvoiceTermsAndConditionTbl");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoiceTermsAndConditionTbl_SalesInvoiceTermsAndConditionID1",
                table: "SalesInvoiceTermsAndConditionTbl");

            migrationBuilder.DropColumn(
                name: "SalesInvoiceTermsAndConditionID1",
                table: "SalesInvoiceTermsAndConditionTbl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SalesInvoiceTermsAndConditionID1",
                table: "SalesInvoiceTermsAndConditionTbl",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceTermsAndConditionTbl_SalesInvoiceTermsAndConditionID1",
                table: "SalesInvoiceTermsAndConditionTbl",
                column: "SalesInvoiceTermsAndConditionID1");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoiceTermsAndConditionTbl_SalesInvoiceTermsAndConditionTbl_SalesInvoiceTermsAndConditionID1",
                table: "SalesInvoiceTermsAndConditionTbl",
                column: "SalesInvoiceTermsAndConditionID1",
                principalTable: "SalesInvoiceTermsAndConditionTbl",
                principalColumn: "SalesInvoiceTermsAndConditionID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
