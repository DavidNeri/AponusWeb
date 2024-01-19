using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class CrearTablaSuministrosMovimientosStock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SUMINISTROS_MOVIMIENTOS_STOCK",
                columns: table => new
                {
                    IDMOVIMIENTO = table.Column<int>(name: "ID_MOVIMIENTO", type: "int", nullable: false),
                    IDSUMINISTRO = table.Column<string>(name: "ID_SUMINISTRO", type: "nvarchar(50)", nullable: false),
                    CAMPOSTOCKORIGEN = table.Column<string>(name: "CAMPO_STOCK_ORIGEN", type: "nvarchar(50)", nullable: true),
                    CAMPOSTOCKDESTINO = table.Column<string>(name: "CAMPO_STOCK_DESTINO", type: "nvarchar(50)", nullable: true),
                    VALORANTERIORORIGEN = table.Column<decimal>(name: "VALOR_ANTERIOR_ORIGEN", type: "decimal(18,2)", nullable: true),
                    VALORANTERIORDESTINO = table.Column<decimal>(name: "VALOR_ANTERIOR_DESTINO", type: "decimal(18,2)", nullable: true),
                    VALORNUEVOORIGEN = table.Column<decimal>(name: "VALOR_NUEVO_ORIGEN", type: "decimal(18,2)", nullable: true),
                    VALORNUEVODESTINO = table.Column<decimal>(name: "VALOR_NUEVO_DESTINO", type: "decimal(18,2)", nullable: true),
                    CANTIDAD = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUMINISTROS_MOVIMIENTOS_STOCK", x => new { x.IDMOVIMIENTO, x.IDSUMINISTRO });
                    table.ForeignKey(
                        name: "FK_SUMINISTROS_MOVIMIENTOS_STOCK_STOCK_MOVIMIENTOS_ID_MOVIMIENTO",
                        column: x => x.IDMOVIMIENTO,
                        principalTable: "STOCK_MOVIMIENTOS",
                        principalColumn: "ID_MOVIMIENTO",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SUMINISTROS_MOVIMIENTOS_STOCK");
        }
    }
}
