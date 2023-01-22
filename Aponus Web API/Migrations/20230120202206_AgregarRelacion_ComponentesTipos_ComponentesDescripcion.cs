using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AgregarRelacionComponentesTiposComponentesDescripcion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           /* migrationBuilder.AddColumn<int>(
                name: "ComponentesDescripcionIdDescripcion",
                table: "COMPONENTES_DESCRIPCION",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComponentesTiposIdDescripcionTipo",
                table: "COMPONENTES_DESCRIPCION",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_COMPONENTES_DESCRIPCION_ComponentesDescripcionIdDescripcion",
                table: "COMPONENTES_DESCRIPCION",
                column: "ComponentesDescripcionIdDescripcion");

            migrationBuilder.CreateIndex(
                name: "IX_COMPONENTES_DESCRIPCION_ComponentesTiposIdDescripcionTipo",
                table: "COMPONENTES_DESCRIPCION",
                column: "ComponentesTiposIdDescripcionTipo");*/

            migrationBuilder.AddForeignKey(
                name: "FK_COMPONENTES_DESCRIPCION_COMPONENTES_DESCRIPCION_ComponentesDescripcionIdDescripcion",
                table: "COMPONENTES_DESCRIPCION",
                column: "ID_DESCRIPCION_TIPO",
                principalTable: "COMPONENTES_TIPOS",
                principalColumn: "ID_DESCRIPCION_TIPO");

           /* migrationBuilder.AddForeignKey(
                name: "FK_COMPONENTES_DESCRIPCION_ComponentesTipos_ComponentesTiposIdDescripcionTipo",
                table: "COMPONENTES_DESCRIPCION",
                column: "ComponentesTiposIdDescripcionTipo",
                principalTable: "ComponentesTipos",
                principalColumn: "IdDescripcionTipo");*/
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COMPONENTES_DESCRIPCION_COMPONENTES_DESCRIPCION_ComponentesDescripcionIdDescripcion",
                table: "COMPONENTES_DESCRIPCION");

            migrationBuilder.DropForeignKey(
                name: "FK_COMPONENTES_DESCRIPCION_ComponentesTipos_ComponentesTiposIdDescripcionTipo",
                table: "COMPONENTES_DESCRIPCION");

            migrationBuilder.DropIndex(
                name: "IX_COMPONENTES_DESCRIPCION_ComponentesDescripcionIdDescripcion",
                table: "COMPONENTES_DESCRIPCION");

            migrationBuilder.DropIndex(
                name: "IX_COMPONENTES_DESCRIPCION_ComponentesTiposIdDescripcionTipo",
                table: "COMPONENTES_DESCRIPCION");

            migrationBuilder.DropColumn(
                name: "ComponentesDescripcionIdDescripcion",
                table: "COMPONENTES_DESCRIPCION");

            migrationBuilder.DropColumn(
                name: "ComponentesTiposIdDescripcionTipo",
                table: "COMPONENTES_DESCRIPCION");
        }
    }
}
