using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class ADDFKARCHIVOSSTOCKSTOCKMOVIMIENTOSIDMOVIMIENTO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_ARCHIVOS_STOCK_STOCK_MOVIMIENTOS_ID_MOVIMIENTO",
                column: "ID_MOVIMIENTO",
                table: "ARCHIVOS_STOCK",
                principalColumn: "ID_MOVIMIENTO",
                principalTable: "STOCK_MOVIMIENTOS");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
