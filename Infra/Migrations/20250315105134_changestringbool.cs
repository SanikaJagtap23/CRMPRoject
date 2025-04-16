using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class changestringbool : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TermAndCondition",
                table: "PurchaseInvoiceTermsTbl");

            migrationBuilder.AlterColumn<bool>(
                name: "ActiveFlag",
                table: "SalesInvoiceTermsAndConditionTbl",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SalesInvoiceTermsAndConditionID1",
                table: "SalesInvoiceTermsAndConditionTbl",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SalesInvoiceTermsAndConditionID",
                table: "PurchaseInvoiceTermsTbl",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoiceTermsAndConditionTbl_SalesInvoiceTermsAndConditionID1",
                table: "SalesInvoiceTermsAndConditionTbl",
                column: "SalesInvoiceTermsAndConditionID1");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceTermsTbl_SalesInvoiceTermsAndConditionID",
                table: "PurchaseInvoiceTermsTbl",
                column: "SalesInvoiceTermsAndConditionID");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoiceTermsTbl_SalesInvoiceTermsAndConditionTbl_SalesInvoiceTermsAndConditionID",
                table: "PurchaseInvoiceTermsTbl",
                column: "SalesInvoiceTermsAndConditionID",
                principalTable: "SalesInvoiceTermsAndConditionTbl",
                principalColumn: "SalesInvoiceTermsAndConditionID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoiceTermsAndConditionTbl_SalesInvoiceTermsAndConditionTbl_SalesInvoiceTermsAndConditionID1",
                table: "SalesInvoiceTermsAndConditionTbl",
                column: "SalesInvoiceTermsAndConditionID1",
                principalTable: "SalesInvoiceTermsAndConditionTbl",
                principalColumn: "SalesInvoiceTermsAndConditionID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoiceTermsTbl_SalesInvoiceTermsAndConditionTbl_SalesInvoiceTermsAndConditionID",
                table: "PurchaseInvoiceTermsTbl");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoiceTermsAndConditionTbl_SalesInvoiceTermsAndConditionTbl_SalesInvoiceTermsAndConditionID1",
                table: "SalesInvoiceTermsAndConditionTbl");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoiceTermsAndConditionTbl_SalesInvoiceTermsAndConditionID1",
                table: "SalesInvoiceTermsAndConditionTbl");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseInvoiceTermsTbl_SalesInvoiceTermsAndConditionID",
                table: "PurchaseInvoiceTermsTbl");

            migrationBuilder.DropColumn(
                name: "SalesInvoiceTermsAndConditionID1",
                table: "SalesInvoiceTermsAndConditionTbl");

            migrationBuilder.DropColumn(
                name: "SalesInvoiceTermsAndConditionID",
                table: "PurchaseInvoiceTermsTbl");

            migrationBuilder.AlterColumn<string>(
                name: "ActiveFlag",
                table: "SalesInvoiceTermsAndConditionTbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "TermAndCondition",
                table: "PurchaseInvoiceTermsTbl",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
