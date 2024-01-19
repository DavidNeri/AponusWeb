using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class EliminarColumnasenStockMovimientos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CAMPO_STOCK_DESTINO",
                table: "Stock_Movimientos");

            migrationBuilder.DropColumn(
                name: "CAMPO_STOCK_ORIGEN",
                table: "Stock_Movimientos");

            migrationBuilder.DropColumn(
                name: "ID_SUMINISTRO",
                table: "Stock_Movimientos");

            migrationBuilder.DropColumn(
                name: "VALOR",
                table: "Stock_Movimientos");

            migrationBuilder.DropColumn(
                name: "VALOR_ANTERIOR_DESTINO",
                table: "Stock_Movimientos");

            migrationBuilder.DropColumn(
                name: "VALOR_ANTERIOR_ORIGEN",
                table: "Stock_Movimientos");

            migrationBuilder.DropColumn(
                name: "VALOR_NUEVO_DESTINO",
                table: "Stock_Movimientos");

            migrationBuilder.DropColumn(
                name: "VALOR_NUEVO_ORIGEN",
                table: "Stock_Movimientos");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddColumn<string>(
                name: "CAMPO_STOCK_DESTINO",
                table: "Stock_Movimientos",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CAMPO_STOCK_ORIGEN",
                table: "Stock_Movimientos",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ID_SUMINISTRO",
                table: "Stock_Movimientos",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "VALOR",
                table: "Stock_Movimientos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "VALOR_ANTERIOR_DESTINO",
                table: "Stock_Movimientos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "VALOR_ANTERIOR_ORIGEN",
                table: "Stock_Movimientos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "VALOR_NUEVO_DESTINO",
                table: "Stock_Movimientos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "VALOR_NUEVO_ORIGEN",
                table: "Stock_Movimientos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
