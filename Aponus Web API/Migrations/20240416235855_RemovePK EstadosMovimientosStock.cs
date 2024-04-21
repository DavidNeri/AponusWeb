using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class RemovePKEstadosMovimientosStock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_STOCK_MOVIMIENTOS_ESTADOS_MOVIMIENTOS_STOCK_ID_ESTADO",
                table: "STOCK_MOVIMIENTOS");

            migrationBuilder.DropForeignKey(
                name: "FK_SUMINISTROS_MOVIMIENTOS_STOCK_STOCK_MOVIMIENTOS_ID_MOVIMIENTO",
                table: "SUMINISTROS_MOVIMIENTOS_STOCK");

            migrationBuilder.DropForeignKey(
                name: "FK_ARCHIVOS_STOCK_STOCK_MOVIMIENTOS_ID_MOVIMIENTO",
                table: "ARCHIVOS_STOCK");

            migrationBuilder.DropPrimaryKey(
                table: "STOCK_MOVIMIENTOS",
                name: "PK_STOCK_MOVIMIENTOS");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
