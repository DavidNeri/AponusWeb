using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class ADDFKTABLEPRODUCTOSTABLASCOMPONENTES : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_COMPONENTES_CUANTITATIVOS_PRODUCTOS_ID_PRODUCTO",
                table: "COMPONENTES_CUANTITATIVOS",
                column: "ID_PRODUCTO",
                principalTable: "PRODUCTOS",
                principalColumn: "ID_PRODUCTO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_COMPONENTES_MENSURABLES_PRODUCTOS_ID_PRODUCTO",
                table: "COMPONENTES_MENSURABLES",
                column: "ID_PRODUCTO",
                principalTable: "PRODUCTOS",
                principalColumn: "ID_PRODUCTO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_COMPONENTES_PESABLES_PRODUCTOS_ID_PRODUCTO",
                table: "COMPONENTES_PESABLES",
                column: "ID_PRODUCTO",
                principalTable: "PRODUCTOS",
                principalColumn: "ID_PRODUCTO",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
