using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class FKULTIMACAMPOSTOCK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.AddForeignKey(
             name: "FK_ARCHIVOS_STOCK_STOCK_MOVIMIENTOS_ID_MOVIMIENTO_CAMPO_STOCK",
             table: "ARCHIVOS_STOCK",
             columns: new[] { "ID_MOVIMIENTO", "CAMPO_STOCK" },
             principalColumns: new[] { "ID_MOVIMIENTO", "CAMPO_STOCK" },
             principalTable: "STOCK_MOVIMIENTOS",
             onDelete: ReferentialAction.Cascade
             );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
