using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class COMPRASdetalle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ComprasDetalles",
                table: "ComprasDetalles");

            migrationBuilder.DropForeignKey(
                name: "FK_ComprasDetalles_COMPONENTES_DETALLE_DetallesInsumoIdInsumo",
                table: "ComprasDetalles");

            migrationBuilder.DropIndex(
                name: "IX_ComprasDetalles_CompraIdCompra",
                table: "ComprasDetalles");

            migrationBuilder.DropIndex(
                name: "IX_ComprasDetalles_DetallesInsumoIdInsumo",
                table: "ComprasDetalles");

            migrationBuilder.DropColumn(
                name: "DetallesInsumoIdInsumo",
                table: "ComprasDetalles");

            migrationBuilder.DropColumn(
                name: "CompraIdCompra",
                table: "ComprasDetalles");

            migrationBuilder.RenameTable(
                name: "ComprasDetalles",
                newName: "COMPRAS_DETALLE");

            migrationBuilder.RenameColumn(
                name: "IdCompra",
                newName: "ID_COMPRA",
                table: "COMPRAS_DETALLE");

            migrationBuilder.RenameColumn(
                name: "IdInsumo",
                newName: "ID_INSUMO",
                table: "COMPRAS_DETALLE");

            migrationBuilder.AlterColumn<string>(
                name: "ID_INSUMO",
                table: "COMPRAS_DETALLE",
                oldType: "nvarchar(MAX)",
                type: "varchar(50)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_COMPRAS_DETALLE_ID_COMPRA_ID_INSUMO",
                table: "COMPRAS_DETALLE",
                columns: new[] { "ID_COMPRA", "ID_INSUMO" });

            migrationBuilder.AddForeignKey(
                name: "COMPRAS_DETALLE_COMPRAS_ID_COMPRA",
                table: "COMPRAS_DETALLE",
                column: "ID_COMPRA",
                principalTable: "COMPRAS",
                principalColumn: "ID_COMPRA");

            migrationBuilder.AddForeignKey(
                name: "COMPRAS_DETALLE_COMPONENTES_DETALLE_ID_INSUMO",
                table: "COMPRAS_DETALLE",
                column: "ID_INSUMO",
                principalTable: "COMPONENTES_DETALLE",
                principalColumn: "ID_INSUMO");

            migrationBuilder.CreateIndex(
                name: "IX_COMPRAS_DETALLE_ID_COMPRA",
                table:"COMPRAS_DETALLE",
                column:"ID_COMPRA");

            migrationBuilder.CreateIndex(
                name: "COMPRAS_DETALLE_ID_INSUMO",
                table: "COMPRAS_DETALLE",
                column: "ID_INSUMO");

            

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
