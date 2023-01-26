using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class fkCCPROD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(table:"COMPONENTES_PESABLES",
                name: "FK_COMPONENTES_CUANTITATIVOS_PRODUCTOS_IDPRODUCTO",
                column:"ID_PRODUCTO",
                principalTable:"PRODUCTOS",
                principalColumn:"ID_PRODUCTO",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
