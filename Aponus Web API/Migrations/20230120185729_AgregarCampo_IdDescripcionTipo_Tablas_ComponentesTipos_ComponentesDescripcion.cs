using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCampoIdDescripcionTipoTablasComponentesTiposComponentesDescripcion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID_TIPO",
                table: "COMPONENTES_TIPOS",
                newName: "ID_DESCRIPCION_TIPO");

            migrationBuilder.AddColumn<int>(
                name: "ID_DESCRIPCION_TIPO",
                table: "COMPONENTES_DESCRIPCION",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ID_DESCRIPCION_TIPO",
                table: "COMPONENTES_DESCRIPCION");

            migrationBuilder.RenameColumn(
                name: "ID_DESCRIPCION_TIPO",
                table: "COMPONENTES_TIPOS",
                newName: "ID_TIPO");
        }
    }
}
