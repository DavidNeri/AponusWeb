using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AlterColumnIdMovimientoTableStockMovimientos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


           
            migrationBuilder.DropForeignKey(
           name: "FK_ARCHIVOS_STOCK_STOCK_MOVIMIENTOS_ID_MOVIMIENTO",
           table: "ARCHIVOS_STOCK");

            migrationBuilder.DropUniqueConstraint(
               name: "PK_STOCK_MOVIMINETOS_ID_MOVIMIENTO",
               table: "STOCK_MOVIMIENTOS");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
           name: "ID_MOVIMIENTO",
           table: "STOCK_MOVIMIENTOS")
           .Annotation("SqlServer:Identity", true);
        }
    }
}
