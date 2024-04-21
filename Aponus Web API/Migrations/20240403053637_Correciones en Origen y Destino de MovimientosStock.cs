using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class CorrecionesenOrigenyDestinodeMovimientosStock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CAMPO_STOCK_DESTINO",
                table: "SUMINISTROS_MOVIMIENTOS_STOCK");

            migrationBuilder.DropColumn(
                name: "CAMPO_STOCK_ORIGEN",
                table: "SUMINISTROS_MOVIMIENTOS_STOCK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CAMPO_STOCK_DESTINO",
                table: "SUMINISTROS_MOVIMIENTOS_STOCK",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CAMPO_STOCK_ORIGEN",
                table: "SUMINISTROS_MOVIMIENTOS_STOCK",
                type: "nvarchar(50)",
                nullable: true);
        }
    }
}
