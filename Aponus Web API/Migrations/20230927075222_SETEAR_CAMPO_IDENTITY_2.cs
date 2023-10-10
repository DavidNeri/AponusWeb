using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class SETEARCAMPOIDENTITY2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DropColumn(
                name: "IdDescripcionTipo",
                table: "COMPONENTES_DESCRIPCION");*/
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ID_DESCRIPCION_TIPO",
                table: "COMPONENTES_DESCRIPCION",
                type: "int",
                nullable: true);
        }
    }
}
