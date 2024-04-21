using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Roolback : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
            name: "PK_STOCK_MOVIMIENTOS",
            table: "STOCK_MOVIMIENTOS",
            column: "ID_MOVIMIENTO");

            migrationBuilder.AddForeignKey(
                name: "FK_STOCK_MOVIMIENTOS_ESTADOS_MOVIMIENTOS_STOCK_ID_ESTADO",
                table: "STOCK_MOVIMIENTOS",
                column: "ID_ESTADO",
                principalTable: "ESTADOS_MOVIMIENTOS_STOCK",
                principalColumn: "ID_ESTADO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SUMINISTROS_MOVIMIENTOS_STOCK_STOCK_MOVIMIENTOS_ID_MOVIMIENTO",
                table: "SUMINISTROS_MOVIMIENTOS_STOCK",
                column: "ID_MOVIMIENTO",
                principalTable: "STOCK_MOVIMIENTOS",
                principalColumn: "ID_MOVIMIENTO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ARCHIVOS_STOCK_STOCK_MOVIMIENTOS_ID_MOVIMIENTO",
                table: "ARCHIVOS_STOCK",
                column: "ID_MOVIMIENTO",
                principalTable: "STOCK_MOVIMIENTOS",
                principalColumn: "ID_MOVIMIENTO",
                onDelete: ReferentialAction.Cascade);



        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
