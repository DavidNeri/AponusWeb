using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class PuntodeControl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CUANTITATIVOS_DETALLE_COMPONENTES_DESCRIPCION_IdDescripcionNavigationIdDescripcion",
                table: "CUANTITATIVOS_DETALLE");

            migrationBuilder.DropForeignKey(
                name: "FK_MENSURABLES_DETALLE_COMPONENTES_DESCRIPCION_IdDescripcionNavigationIdDescripcion",
                table: "MENSURABLES_DETALLE");

            migrationBuilder.DropForeignKey(
                name: "FK_PESABLES_DETALLE_COMPONENTES_DESCRIPCION_IdDescripcionNavigationIdDescripcion",
                table: "PESABLES_DETALLE");

            migrationBuilder.DropIndex(
                name: "IX_PESABLES_DETALLE_IdDescripcionNavigationIdDescripcion",
                table: "PESABLES_DETALLE");

            migrationBuilder.DropIndex(
                name: "IX_MENSURABLES_DETALLE_IdDescripcionNavigationIdDescripcion",
                table: "MENSURABLES_DETALLE");

            migrationBuilder.DropIndex(
                name: "IX_CUANTITATIVOS_DETALLE_IdDescripcionNavigationIdDescripcion",
                table: "CUANTITATIVOS_DETALLE");

            migrationBuilder.DropColumn(
                name: "IdDescripcionNavigationIdDescripcion",
                table: "PESABLES_DETALLE");

            migrationBuilder.DropColumn(
                name: "IdDescripcionNavigationIdDescripcion",
                table: "MENSURABLES_DETALLE");

            migrationBuilder.DropColumn(
                name: "IdDescripcionNavigationIdDescripcion",
                table: "CUANTITATIVOS_DETALLE");

            migrationBuilder.AlterColumn<int>(
                name: "ID_DESCRIPCION",
                table: "COMPONENTES_DESCRIPCION",
                type: "int",
                nullable: false,
                defaultValueSql: "((-1))",
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ComponentesDescripcionIdDescripcion",
                table: "COMPONENTES_DESCRIPCION",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PESABLES_DETALLE_ID_DESCRIPCION",
                table: "PESABLES_DETALLE",
                column: "ID_DESCRIPCION");

            migrationBuilder.CreateIndex(
                name: "IX_MENSURABLES_DETALLE_ID_DESCRIPCION",
                table: "MENSURABLES_DETALLE",
                column: "ID_DESCRIPCION");

            migrationBuilder.CreateIndex(
                name: "IX_CUANTITATIVOS_DETALLE_ID_DESCRIPCION",
                table: "CUANTITATIVOS_DETALLE",
                column: "ID_DESCRIPCION");

            migrationBuilder.CreateIndex(
                name: "IX_COMPONENTES_DESCRIPCION_ComponentesDescripcionIdDescripcion",
                table: "COMPONENTES_DESCRIPCION",
                column: "ComponentesDescripcionIdDescripcion");

            migrationBuilder.AddForeignKey(
                name: "FK_COMPONENTES_DESCRIPCION_COMPONENTES_DESCRIPCION_ComponentesDescripcionIdDescripcion",
                table: "COMPONENTES_DESCRIPCION",
                column: "ComponentesDescripcionIdDescripcion",
                principalTable: "COMPONENTES_DESCRIPCION",
                principalColumn: "ID_DESCRIPCION");

            migrationBuilder.AddForeignKey(
                name: "FK_CUANTITATIVOS_DETALLE_COMPONENTES_DESCRIPCION",
                table: "CUANTITATIVOS_DETALLE",
                column: "ID_DESCRIPCION",
                principalTable: "COMPONENTES_DESCRIPCION",
                principalColumn: "ID_DESCRIPCION");

            migrationBuilder.AddForeignKey(
                name: "FK_MENSURABLES_DETALLE_COMPONENTES_DESCRIPCION",
                table: "MENSURABLES_DETALLE",
                column: "ID_DESCRIPCION",
                principalTable: "COMPONENTES_DESCRIPCION",
                principalColumn: "ID_DESCRIPCION");

            migrationBuilder.AddForeignKey(
                name: "FK_PESABLES_DETALLE_COMPONENTES_DESCRIPCION",
                table: "PESABLES_DETALLE",
                column: "ID_DESCRIPCION",
                principalTable: "COMPONENTES_DESCRIPCION",
                principalColumn: "ID_DESCRIPCION");
        }
    }
}
