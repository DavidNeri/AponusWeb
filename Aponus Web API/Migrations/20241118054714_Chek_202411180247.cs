using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aponus_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class Chek_202411180247 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUCTOS_COMPONENTES_ESTADOS_PRODUCTOS_COMPONENTES_ID_ESTAD",
                table: "PRODUCTOS_COMPONENTES");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCTOS_COMPONENTES_ESTADOS_PRODUCTOS_COMPONENTES_ID_ESTAD",
                table: "PRODUCTOS_COMPONENTES",
                column: "ID_ESTADO",
                principalTable: "ESTADOS_PRODUCTOS_COMPONENTES",
                principalColumn: "ID_ESTADO",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUCTOS_COMPONENTES_ESTADOS_PRODUCTOS_COMPONENTES_ID_ESTAD",
                table: "PRODUCTOS_COMPONENTES");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCTOS_COMPONENTES_ESTADOS_PRODUCTOS_COMPONENTES_ID_ESTAD",
                table: "PRODUCTOS_COMPONENTES",
                column: "ID_ESTADO",
                principalTable: "ESTADOS_PRODUCTOS_COMPONENTES",
                principalColumn: "ID_ESTADO",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
