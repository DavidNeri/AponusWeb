using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class ColumnaCantidadMoldeadoTablaStockCuantitativos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_CUANTITATIVOS_DETALLE_ID_COMPONENTE_PERFIL",
                table: "CUANTITATIVOS_DETALLE");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_CUANTITATIVOS_DETALLE_ID_COMPONENTE_PERFIL",
                table: "CUANTITATIVOS_DETALLE",
                columns: new[] { "ID_COMPONENTE", "PERFIL" });
        }
    }
}
