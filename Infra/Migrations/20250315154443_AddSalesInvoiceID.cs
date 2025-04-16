using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddSalesInvoiceID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalesVoiceID",
                table: "SalesInvoicePaymentTbl");

            migrationBuilder.AlterColumn<long>(
                name: "SalesInvoiceID",
                table: "SalesInvoicePaymentTbl",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "SalesInvoiceID",
                table: "SalesInvoicePaymentTbl",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "SalesVoiceID",
                table: "SalesInvoicePaymentTbl",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
