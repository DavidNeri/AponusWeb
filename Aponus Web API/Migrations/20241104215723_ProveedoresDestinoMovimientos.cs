using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aponus_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class ProveedoresDestinoMovimientos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_STOCK_MOVIMIENTOS_ENTIDADES_ID_PROVEEDOR_ORIGEN",
                table: "STOCK_MOVIMIENTOS");

            migrationBuilder.DropColumn(
                name: "ID_PROVEEDOR_ORIGEN",
                table: "STOCK_MOVIMIENTOS");

            migrationBuilder.RenameColumn(
                name: "ID_PROVEEDOR_DESTINO",
                table: "STOCK_MOVIMIENTOS",
                newName: "ID_PROVEEDOR");

            migrationBuilder.CreateIndex(
               name: "IX_STOCK_MOVIMIENTOS_ID_PROVEEDOR",
               table: "STOCK_MOVIMIENTOS",
               column: "ID_PROVEEDOR");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID_PROVEEDOR",
                table: "STOCK_MOVIMIENTOS",
                newName: "ID_PROVEEDOR_DESTINO");

            migrationBuilder.RenameIndex(
                name: "IX_STOCK_MOVIMIENTOS_ID_PROVEEDOR",
                table: "STOCK_MOVIMIENTOS",
                newName: "IX_STOCK_MOVIMIENTOS_ID_PROVEEDOR_DESTINO");

            migrationBuilder.AddColumn<int>(
                name: "ID_PROVEEDOR_ORIGEN",
                table: "STOCK_MOVIMIENTOS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_STOCK_MOVIMIENTOS_ID_PROVEEDOR_ORIGEN",
                table: "STOCK_MOVIMIENTOS",
                column: "ID_PROVEEDOR_ORIGEN");

            migrationBuilder.AddForeignKey(
                name: "FK_STOCK_MOVIMIENTOS_ENTIDADES_ID_PROVEEDOR_ORIGEN",
                table: "STOCK_MOVIMIENTOS",
                column: "ID_PROVEEDOR_ORIGEN",
                principalTable: "ENTIDADES",
                principalColumn: "ID_ENTIDAD",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
