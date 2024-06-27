using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class PAGOSCOMPRAS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PagosCompras",
                table: "PagosCompras");

            migrationBuilder.DropIndex(
                name: "IX_PagosCompras_ComprasIdCompra",
                table: "PagosCompras");

            migrationBuilder.DropColumn(
                name: "ComprasIdCompra",
                table: "PagosCompras");

            migrationBuilder.RenameColumn(
                name: "IdCompra",
                table: "pagosCompras",
                newName: "ID_COMPRA");

            migrationBuilder.AlterColumn<int>(
                table:"PagosCompras",
                name: "IdMedioPago",
                oldType: "nvarchar(MAX)",
                type: "int");

            migrationBuilder.RenameColumn(
                name: "IdMedioPago",
                table: "PagosCompras",
                newName: "ID_MEDIO_PAGO");

            migrationBuilder.RenameTable(
                name: "pagosCompras",
                newName: "PAGOS_COMPRAS");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PAGOS_COMPRAS_ID_PAGO",
                table: "PAGOS_COMPRAS",
                column: "ID_PAGO");

            migrationBuilder.AddForeignKey(
                name: "FK_PAGOS_COMPRAS_COMPRAS_ID_COMPRA",
                table: "PAGOS_COMPRAS",
                column: "ID_COMPRA",
                principalTable: "COMPRAS",
                principalColumn: "ID_COMPRA");

            migrationBuilder.AddForeignKey(
                name: "FK_PAGOS_COMPRAS_MEDIOS_PAGO_ID_MEDIO_PAGO",
                table: "PAGOS_COMPRAS",
                column: "ID_MEDIO_PAGO",
                principalTable: "MEDIOS_PAGO",
                principalColumn: "ID_MEDIO_PAGO");

            migrationBuilder.CreateIndex(
                name: "IX_PAGOS_COMPRAS_ID_PAGO",
                table: "PAGOS_COMPRAS",
                column: "ID_PAGO");

            migrationBuilder.CreateIndex(
                name: "IX_PAGOS_COMPRAS_ID_COMPRA",
                table: "PAGOS_COMPRAS",
                column: "ID_COMPRA");

            migrationBuilder.CreateIndex(
                name: "IX_PAGOS_COMPRAS_ID_MEDIO_PAGO",
                table: "PAGOS_COMPRAS",
                column: "ID_MEDIO_PAGO");

            migrationBuilder.CreateIndex(
                name: "IX_PAGOS_COMPRAS_SUBOTAL_CANCELADO",
                table: "PAGOS_COMPRAS",
                column: "SUBTOTAL_CANCELADO");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
