using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aponus_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class CorreccionesenPagosCompras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CANTIDAD_CUOTAS",
                table: "PAGOS_COMPRAS");

            migrationBuilder.DropColumn(
                name: "CANTIDAD_CUOTAS_CANCELADAS",
                table: "PAGOS_COMPRAS");

            migrationBuilder.DropColumn(
                name: "SUBTOTAL_CANCELADO",
                table: "PAGOS_COMPRAS");

            migrationBuilder.DropColumn(
                name: "TOTAL",
                table: "PAGOS_COMPRAS");

            migrationBuilder.AddColumn<DateTime>(
                name: "FECHA",
                table: "PAGOS_COMPRAS",
                type: "timestamp",
                nullable: true);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COMPRAS_USUARIOS_IDUSUARIO",
                table: "COMPRAS");

            migrationBuilder.DropColumn(
                name: "FECHA",
                table: "PAGOS_COMPRAS");

            migrationBuilder.RenameColumn(
                name: "ID_COMPRA",
                table: "CUOTAS_COMPRAS",
                newName: "IdCompra");

            migrationBuilder.RenameIndex(
                name: "IX_CUOTAS_COMPRAS_ID_COMPRA",
                table: "CUOTAS_COMPRAS",
                newName: "IX_CUOTAS_COMPRAS_IdCompra");

            migrationBuilder.AddColumn<int>(
                name: "CANTIDAD_CUOTAS",
                table: "PAGOS_COMPRAS",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CANTIDAD_CUOTAS_CANCELADAS",
                table: "PAGOS_COMPRAS",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SUBTOTAL_CANCELADO",
                table: "PAGOS_COMPRAS",
                type: "numeric(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TOTAL",
                table: "PAGOS_COMPRAS",
                type: "numeric(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_COMPRAS_USUARIOS_USAURIO",
                table: "COMPRAS",
                column: "ID_USUARIO",
                principalTable: "USUARIOS",
                principalColumn: "USUARIO");
        }
    }
}
