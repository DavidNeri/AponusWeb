using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableArchivosMovimientosStock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ARCHIVOS_STOCK",
                columns: table => new
                {
                    IDMOVIMIENTO = table.Column<int>(name: "ID_MOVIMIENTO", type: "int", nullable: false),
                    HASHARCHIVO = table.Column<string>(name: "HASH_ARCHIVO", type: "varchar(255)", nullable: false),
                    PATH = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ARCHIVOS_STOCK", x => new { x.IDMOVIMIENTO, x.HASHARCHIVO });
                    table.ForeignKey(
                        name: "FK_ARCHIVOS_STOCK_STOCK_MOVIMIENTOS_ID_MOVIMIENTO",
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
                name: "ARCHIVOS_STOCK");
        }
    }
}
