using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class StockMovimientosValoresMovimiento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NUEVO_VALOR",
                table: "STOCK_MOVIMIENTOS",
                newName: "VALOR_NUEVO");

            migrationBuilder.AddColumn<decimal>(
                name: "VALOR_MOVIMIENTO",
                table: "STOCK_MOVIMIENTOS",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VALOR_MOVIMIENTO",
                table: "STOCK_MOVIMIENTOS");

            migrationBuilder.RenameColumn(
                name: "VALOR_NUEVO",
                table: "STOCK_MOVIMIENTOS",
                newName: "NUEVO_VALOR");
        }
    }

}
