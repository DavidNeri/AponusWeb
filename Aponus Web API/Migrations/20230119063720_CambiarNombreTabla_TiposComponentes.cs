using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class CambiarNombreTablaTiposComponentes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           // migrationBuilder.RenameTable("ComponentesTipos", "COMPONENTES_TIPOS");
            migrationBuilder.RenameColumn("IdTipo", "ComponentesTipos", "ID_TIPO");
            migrationBuilder.RenameColumn("DescripcionTipo", "ComponentesTipos", "DESCRIPCION_TIPO");




        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
