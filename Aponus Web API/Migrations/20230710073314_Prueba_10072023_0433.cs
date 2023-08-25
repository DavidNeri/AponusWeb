using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Prueba100720230433 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ID_TIPO",
                table: "PRODUCTOS_TIPOS_DESCRIPCION",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "ProductosDescripcionIdDescripcion",
                table: "PRODUCTOS_TIPOS_DESCRIPCION",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductosTipoIdTipo",
                table: "PRODUCTOS_TIPOS_DESCRIPCION",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTOS_TIPOS_DESCRIPCION_ID_DESCRIPCION",
                table: "PRODUCTOS_TIPOS_DESCRIPCION",
                column: "ID_DESCRIPCION");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTOS_TIPOS_DESCRIPCION_ProductosDescripcionIdDescripcion",
                table: "PRODUCTOS_TIPOS_DESCRIPCION",
                column: "ProductosDescripcionIdDescripcion");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTOS_TIPOS_DESCRIPCION_ProductosTipoIdTipo",
                table: "PRODUCTOS_TIPOS_DESCRIPCION",
                column: "ProductosTipoIdTipo");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCTOS_TIPOS_DESCRIPCION_ID_DESCRIPCION",
                table: "PRODUCTOS_TIPOS_DESCRIPCION",
                column: "ID_DESCRIPCION",
                principalTable: "PRODUCTOS_DESCRIPCION",
                principalColumn: "ID_DESCRIPCION");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCTOS_TIPOS_DESCRIPCION_ID_TIPO",
                table: "PRODUCTOS_TIPOS_DESCRIPCION",
                column: "ID_TIPO",
                principalTable: "PRODUCTOS_TIPOS",
                principalColumn: "ID_TIPO");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCTOS_TIPOS_DESCRIPCION_PRODUCTOS_DESCRIPCION_ProductosDescripcionIdDescripcion",
                table: "PRODUCTOS_TIPOS_DESCRIPCION",
                column: "ProductosDescripcionIdDescripcion",
                principalTable: "PRODUCTOS_DESCRIPCION",
                principalColumn: "ID_DESCRIPCION");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCTOS_TIPOS_DESCRIPCION_PRODUCTOS_TIPOS_ProductosTipoIdTipo",
                table: "PRODUCTOS_TIPOS_DESCRIPCION",
                column: "ProductosTipoIdTipo",
                principalTable: "PRODUCTOS_TIPOS",
                principalColumn: "ID_TIPO");
        }
    }
}
