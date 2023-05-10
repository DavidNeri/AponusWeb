using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class CREARTABLACOMPONENTEporPRODUCTO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PRODUCTOS_COMPONENTES",
                columns: table => new
                {
                    IDPRODUCTO = table.Column<string>(name: "ID_PRODUCTO", type: "varchar(50)", nullable: false),
                    IDCOMPONENTE = table.Column<string>(name: "ID_COMPONENTE", type: "varchar(50)", nullable: false),
                    CANTIDAD = table.Column<int>(type: "int", nullable: true),
                    PESO = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    LONGITUD = table.Column<decimal>(type: "decimal(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTOS_COMPONENTES", x => new { x.IDPRODUCTO, x.IDCOMPONENTE });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRODUCTOS_COMPONENTES");
        }
    }
}
