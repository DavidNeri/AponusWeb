using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Inical : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "COMPONENTES_CUANTITATIVOS");

            migrationBuilder.DropTable(
                name: "COMPONENTES_MENSURABLES");

            migrationBuilder.DropTable(
                name: "COMPONENTES_PESABLES");

            migrationBuilder.DropTable(
                name: "PRODUCTOS");

            migrationBuilder.DropTable(
                name: "STOCK_CUANTITATIVOS");

            migrationBuilder.DropTable(
                name: "MENSURABLES_DETALLE");

            migrationBuilder.DropTable(
                name: "STOCK_PESABLES");

            migrationBuilder.DropTable(
                name: "PRODUCTOS_DESCRIPCION");

            migrationBuilder.DropTable(
                name: "PRODUCTOS_TIPOS");

            migrationBuilder.DropTable(
                name: "CUANTITATIVOS_DETALLE");

            migrationBuilder.DropTable(
                name: "STOCK_MENSURABLES");

            migrationBuilder.DropTable(
                name: "PESABLES_DETALLE");

            migrationBuilder.DropTable(
                name: "COMPONENTES_DESCRIPCION");
        }
    }
}
