using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aponus_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class CorreccionesenPagosCompras2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TOTAL",
                table: "VENTAS",
                newName: "MONTO_TOTAL");

            migrationBuilder.RenameColumn(
                name: "SALDO_TOTAL",
                table: "COMPRAS",
                newName: "MONTO_TOTAL");

            migrationBuilder.RenameColumn(
                name: "SALDO_CANCELADO",
                table: "COMPRAS",
                newName: "SALDO_PENDIENTE");

            migrationBuilder.AlterColumn<decimal>(
                name: "SALDO_PENDIENTE",
                table: "VENTAS",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MONTO_TOTAL",
                table: "VENTAS",
                newName: "TOTAL");

            migrationBuilder.RenameColumn(
                name: "SALDO_PENDIENTE",
                table: "COMPRAS",
                newName: "SALDO_CANCELADO");

            migrationBuilder.RenameColumn(
                name: "MONTO_TOTAL",
                table: "COMPRAS",
                newName: "SALDO_TOTAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "SALDO_PENDIENTE",
                table: "VENTAS",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);
        }
    }
}
