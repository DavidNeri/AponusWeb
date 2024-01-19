using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class RMPKStockMovimientos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                table: "ARCHIVOS_STOCK",
                name:"FK_ARCHIVOS_STOCK_STOCK_MOVIMIENTOS_ID_MOVIMIENTO_CAMPO_STOCK",
                schema:"dbo");
            

            migrationBuilder.DropPrimaryKey(
                table: "STOCK_MOVIMIENTOS",
                name: "PK_STOCK_MOVIMIENTOS");

            migrationBuilder.AddPrimaryKey(
                table: "STOCK_MOVIMIENTOS",
                name: "PK_STOCK_MOVIMIENTOS",
                column: "ID_MOVIMIENTO");

            migrationBuilder.DropColumn(
                name: "CAMPO_STOCK",
                table: "STOCK_MOVIMIENTOS");

            migrationBuilder.DropColumn(
            name: "DIFERENCIA",
            table: "STOCK_MOVIMIENTOS");

            migrationBuilder.RenameColumn(
                name: "VALOR_MOVIMIENTO",
                table: "STOCK_MOVIMIENTOS",                
                newName: "VALOR");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
