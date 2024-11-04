using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aponus_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class ComponentesDescripcion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ID_ALMACENAMIENTO",
                table: "COMPONENTES_DESCRIPCION",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ID_FRACCIONAMIENTO",
                table: "COMPONENTES_DESCRIPCION",
                type: "varchar(50)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ID_ALMACENAMIENTO",
                table: "COMPONENTES_DESCRIPCION");

            migrationBuilder.DropColumn(
                name: "ID_FRACCIONAMIENTO",
                table: "COMPONENTES_DESCRIPCION");
        }
    }
}
