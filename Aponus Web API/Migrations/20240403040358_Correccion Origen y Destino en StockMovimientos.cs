using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class CorreccionOrigenyDestinoenStockMovimientos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DESTINO",
                table: "Stock_Movimientos",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ORIGEN",
                table: "Stock_Movimientos",
                type: "varchar(50)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DESTINO",
                table: "Stock_Movimientos");

            migrationBuilder.DropColumn(
                name: "ORIGEN",
                table: "Stock_Movimientos");
        }
    }
}
