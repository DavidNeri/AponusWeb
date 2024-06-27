using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class COMPRASdetallealterfkix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
               name: "COMPRAS_DETALLE_COMPRAS_ID_COMPRA",
               table: "COMPRAS_DETALLE");


            migrationBuilder.AddForeignKey(
                name: "FK_COMPRAS_DETALLE_COMPRAS_ID_COMPRA",
                table: "COMPRAS_DETALLE",
                column: "ID_COMPRA",
                principalTable: "COMPRAS",
                principalColumn: "ID_COMPRA");


            migrationBuilder.DropForeignKey(
              name: "COMPRAS_DETALLE_COMPONENTES_DETALLE_ID_INSUMO",
              table: "COMPRAS_DETALLE");

            migrationBuilder.AddForeignKey(
                name: "FK_COMPRAS_DETALLE_COMPONENTES_DETALLE_ID_INSUMO",
                table: "COMPRAS_DETALLE",
                column: "ID_INSUMO",
                principalTable: "COMPONENTES_DETALLE",
                principalColumn: "ID_INSUMO");       

            migrationBuilder.RenameIndex(
                name: "COMPRAS_DETALLE_ID_INSUMO",
                table: "COMPRAS_DETALLE",
                newName: "IX_COMPRAS_DETALLE_ID_INSUMO");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
