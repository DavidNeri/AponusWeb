using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class TablaAuxTiposDescripcionTiposNavigations2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateIndex(
                name: "IX_Producto_Tipo_Descripcion_DescripcionIdDescripcion",
                table: "PRODUCTOS_TIPOS_DESCRIPCION",
                column: "ID_DESCRIPCION");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_Tipo_Descripcion_IdTipoNavigationIdTipo",
                table: "PRODUCTOS_TIPOS_DESCRIPCION",
                column: "ID_TIPO");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Tipo_Descripcion_PRODUCTOS_DESCRIPCION_DescripcionIdDescripcion",
                table: "PRODUCTOS_TIPOS_DESCRIPCION",
                column: "ID_DESCRIPCION",
                principalTable: "PRODUCTOS_DESCRIPCION",
                principalColumn: "ID_DESCRIPCION",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Tipo_Descripcion_PRODUCTOS_TIPOS_IdTipoNavigationIdTipo",
                table: "PRODUCTOS_TIPOS_DESCRIPCION",
                column: "ID_TIPO",
                principalTable: "PRODUCTOS_TIPOS",
                principalColumn: "ID_TIPO",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Tipo_Descripcion_PRODUCTOS_DESCRIPCION_DescripcionIdDescripcion",
                table: "PRODUCTOS_TIPOS_DESCRIPCION");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Tipo_Descripcion_PRODUCTOS_TIPOS_IdTipoNavigationIdTipo",
                table: "PRODUCTOS_TIPOS_DESCRIPCION");

            migrationBuilder.DropIndex(
                name: "IX_Producto_Tipo_Descripcion_DescripcionIdDescripcion",
                table: "PRODUCTOS_TIPOS_DESCRIPCION");

            migrationBuilder.DropIndex(
                name: "IX_Producto_Tipo_Descripcion_IdTipoNavigationIdTipo",
                table: "PRODUCTOS_TIPOS_DESCRIPCION");

            migrationBuilder.DropColumn(
                name: "ID_DESCRIPCION",
                table: "PRODUCTOS_TIPOS_DESCRIPCION");

            migrationBuilder.DropColumn(
                name: "ID_TIPO",
                table: "PRODUCTOS_TIPOS_DESCRIPCION");
        }
    }
}
