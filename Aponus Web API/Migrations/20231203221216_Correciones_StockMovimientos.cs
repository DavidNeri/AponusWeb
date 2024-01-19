using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class CorrecionesStockMovimientos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VALOR_NUEVO",
                table: "STOCK_MOVIMIENTOS",
                newName: "VALOR_NUEVO_ORIGEN");

            migrationBuilder.RenameColumn(
                name: "VALOR_ANTERIOR",
                table: "STOCK_MOVIMIENTOS",
                newName: "VALOR_NUEVO_DESTINO");

            migrationBuilder.AddColumn<string>(
                name: "CAMPO_STOCK_DESTINO",
                table: "STOCK_MOVIMIENTOS",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CAMPO_STOCK_ORIGEN",
                table: "STOCK_MOVIMIENTOS",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "VALOR_ANTERIOR_DESTINO",
                table: "STOCK_MOVIMIENTOS",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "VALOR_ANTERIOR_ORIGEN",
                table: "STOCK_MOVIMIENTOS",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CampoStockDestino",
                table: "STOCK_MOVIMIENTOS");

            migrationBuilder.DropColumn(
                name: "CampoStockOrigen",
                table: "STOCK_MOVIMIENTOS");

            migrationBuilder.DropColumn(
                name: "ValorAnteriorDestino",
                table: "STOCK_MOVIMIENTOS");

            migrationBuilder.DropColumn(
                name: "ValorAnteriorOrigen",
                table: "STOCK_MOVIMIENTOS");

            migrationBuilder.RenameColumn(
                name: "ValorNuevoOrigen",
                table: "STOCK_MOVIMIENTOS",
                newName: "VALOR_NUEVO");

            migrationBuilder.RenameColumn(
                name: "ValorNuevoDestino",
                table: "STOCK_MOVIMIENTOS",
                newName: "VALOR_ANTERIOR");
        }
    }
}
