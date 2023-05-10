using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class CREARTABLASTOCKINSUMOS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "STOCK_INSUMOS",
                columns: table => new
                {
                    IDINSUMO = table.Column<string>(name: "ID_INSUMO", type: "varchar(50)", nullable: false),
                    CANTIDADRECIBIDO = table.Column<int>(name: "CANTIDAD_RECIBIDO", type: "int", nullable: true),
                    CANTIDADGRANALLADO = table.Column<int>(name: "CANTIDAD_GRANALLADO", type: "int", nullable: true),
                    CANTIDADPINTURA = table.Column<int>(name: "CANTIDAD_PINTURA", type: "int", nullable: true),
                    CANTIDADPROCESO = table.Column<int>(name: "CANTIDAD_PROCESO", type: "int", nullable: true),
                    CANTIDADMOLDEADO = table.Column<int>(name: "CANTIDAD_MOLDEADO", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STOCK_INSUMOS", x => x.IDINSUMO);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "STOCK_INSUMOS");
        }
    }
}
