using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class FKPRODUCTOSTIPOSDESCRIPCION : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "PK_PRODUCTOS_TIPOS_DESCRIPCION",
                table: "PRODUCTOS_TIPOS_DESCRIPCION",
                columns: new[] { "ID_TIPO", "ID_DESCRIPCION" }
                );

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
