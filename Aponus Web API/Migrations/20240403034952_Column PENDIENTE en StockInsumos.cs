using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class ColumnPENDIENTEenStockInsumos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CANTIDAD_RECIBIDO",
                table: "STOCK_INSUMOS",
                newName: "RECIBIDO");

            migrationBuilder.RenameColumn(
                name: "CANTIDAD_PROCESO",
                table: "STOCK_INSUMOS",
                newName: "PROCESO");

            migrationBuilder.RenameColumn(
                name: "CANTIDAD_PINTURA",
                table: "STOCK_INSUMOS",
                newName: "PINTURA");

            migrationBuilder.RenameColumn(
                name: "CANTIDAD_MOLDEADO",
                table: "STOCK_INSUMOS",
                newName: "MOLDEADO");

            migrationBuilder.RenameColumn(
                name: "CANTIDAD_GRANALLADO",
                table: "STOCK_INSUMOS",
                newName: "GRANALLADO");

            migrationBuilder.AddColumn<decimal>(
                name: "PENDIENTE",
                table: "STOCK_INSUMOS",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PENDIENTE",
                table: "STOCK_INSUMOS");

            migrationBuilder.RenameColumn(
                name: "RECIBIDO",
                table: "STOCK_INSUMOS",
                newName: "CANTIDAD_RECIBIDO");

            migrationBuilder.RenameColumn(
                name: "PROCESO",
                table: "STOCK_INSUMOS",
                newName: "CANTIDAD_PROCESO");

            migrationBuilder.RenameColumn(
                name: "PINTURA",
                table: "STOCK_INSUMOS",
                newName: "CANTIDAD_PINTURA");

            migrationBuilder.RenameColumn(
                name: "MOLDEADO",
                table: "STOCK_INSUMOS",
                newName: "CANTIDAD_MOLDEADO");

            migrationBuilder.RenameColumn(
                name: "GRANALLADO",
                table: "STOCK_INSUMOS",
                newName: "CANTIDAD_GRANALLADO");
        }
    }
}
