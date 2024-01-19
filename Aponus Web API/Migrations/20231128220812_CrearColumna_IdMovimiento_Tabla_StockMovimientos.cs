using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class CrearColumnaIdMovimientoTablaStockMovimientos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ID_MOVIMIENTO",
                table: "STOCK_MOVIMIENTOS")
                .Annotation("SqlServerIdentity", false);


            migrationBuilder.AddPrimaryKey(
                name: "PK_STOCK_MOVIMIENTOS",
                columns: new[] { "ID_MOVIMIENTO", "CAMPO_STOCK" },
                table: "STOCK_MOVIMIENTOS");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
