using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class SalesCorreciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SALDO_CANCELADO",
                table: "VENTAS");

            migrationBuilder.DropColumn(
                name: "CANTIDAD_CUOTAS",
                table: "PAGOS_VENTAS");

            migrationBuilder.DropColumn(
                name: "CANTIDAD_CUOTAS_CANCELADAS",
                table: "PAGOS_VENTAS");

            migrationBuilder.DropColumn(
                name: "SUBTOTAL",
                table: "PAGOS_VENTAS");

            migrationBuilder.DropColumn(
                name: "SUBTOTAL_CANCELADO",
                table: "PAGOS_VENTAS");

            migrationBuilder.RenameColumn(
                name: "SALDO_TOTAL",
                table: "VENTAS",
                newName: "TOTAL");

            migrationBuilder.RenameColumn(
                name: "TOTAL",
                table: "PAGOS_VENTAS",
                newName: "MONTO");

            migrationBuilder.AddColumn<decimal>(
                name: "PRECIO",
                table: "VENTAS_DETALLES",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SALDO_PENDIENTE",
                table: "VENTAS",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "FECHA",
                table: "PAGOS_VENTAS",
                type: "datetime",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PRECIO",
                table: "VENTAS_DETALLES");

            migrationBuilder.DropColumn(
                name: "SALDO_PENDIENTE",
                table: "VENTAS");

            migrationBuilder.DropColumn(
                name: "FECHA",
                table: "PAGOS_VENTAS");

            migrationBuilder.RenameColumn(
                name: "TOTAL",
                table: "VENTAS",
                newName: "SALDO_TOTAL");

            migrationBuilder.RenameColumn(
                name: "MONTO",
                table: "PAGOS_VENTAS",
                newName: "TOTAL");

            migrationBuilder.AddColumn<decimal>(
                name: "SALDO_CANCELADO",
                table: "VENTAS",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CANTIDAD_CUOTAS",
                table: "PAGOS_VENTAS",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CANTIDAD_CUOTAS_CANCELADAS",
                table: "PAGOS_VENTAS",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SUBTOTAL",
                table: "PAGOS_VENTAS",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SUBTOTAL_CANCELADO",
                table: "PAGOS_VENTAS",
                type: "decimal(18,2)",
                nullable: true);
        }
    }
}
