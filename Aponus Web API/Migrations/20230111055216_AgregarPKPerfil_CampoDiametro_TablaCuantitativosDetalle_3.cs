using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AgregarPKPerfilCampoDiametroTablaCuantitativosDetalle3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_CUANTITATIVOS_DETALLE_ID_COMPONENTE_PERFIL",
                table: "CUANTITATIVOS_DETALLE",
                columns: new[] { "ID_COMPONENTE", "PERFIL" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_CUANTITATIVOS_DETALLE_ID_COMPONENTE_PERFIL",
                table: "CUANTITATIVOS_DETALLE");
        }
    }
}
