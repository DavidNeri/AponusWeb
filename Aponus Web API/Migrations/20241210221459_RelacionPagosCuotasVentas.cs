using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aponus_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class RelacionPagosCuotasVentas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ID_CUOTA",
                table: "PAGOS_VENTAS",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PAGOS_VENTAS_ID_CUOTA",
                table: "PAGOS_VENTAS",
                column: "ID_CUOTA");

            migrationBuilder.AddForeignKey(
                name: "FK_PAGOS_VENTAS_CUOTAS_VENTAS_ID_CUOTA",
                table: "PAGOS_VENTAS",
                column: "ID_CUOTA",
                principalTable: "CUOTAS_VENTAS",
                principalColumn: "ID_CUOTA");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PAGOS_VENTAS_CUOTAS_VENTAS_ID_CUOTA",
                table: "PAGOS_VENTAS");

            migrationBuilder.DropIndex(
                name: "IX_PAGOS_VENTAS_ID_CUOTA",
                table: "PAGOS_VENTAS");

            migrationBuilder.DropColumn(
                name: "ID_CUOTA",
                table: "PAGOS_VENTAS");
        }
    }
}
