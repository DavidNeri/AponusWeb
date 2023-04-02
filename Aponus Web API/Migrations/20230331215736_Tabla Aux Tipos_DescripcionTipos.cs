using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class TablaAuxTiposDescripcionTipos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PRODUCTOS_TIPOS_DESCRIPCION",
                columns: table => new
                {
                    IDTIPO = table.Column<string>(name: "ID_TIPO", type: "nvarchar(50)", nullable: false),
                    IDDESCRIPCION = table.Column<int>(name: "ID_DESCRIPCION", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto_Tipo_Descripcion", x => new { x.IDTIPO, x.IDDESCRIPCION });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRODUCTOS_TIPOS_DESCRIPCION");
        }
    }
}
