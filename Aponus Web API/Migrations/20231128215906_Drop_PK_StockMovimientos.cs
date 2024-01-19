using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class DropPKStockMovimientos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
               name: "PK_STOCK_MOVIMIENTOS",
               table: "STOCK_MOVIMIENTOS");

            //Eliminar columna  
            migrationBuilder.DropColumn(
                name: "ID_MOVIMIENTO",
                table: "STOCK_MOVIMIENTOS"
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
