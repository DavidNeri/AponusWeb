using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class CLIENTESTOCLIENTESPROVEEDORES : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CLIENTES_CLIENTES_CATEGORIAS_ID_CATEGORIA",
                table: "CLIENTES");

            migrationBuilder.DropForeignKey(
                name: "FK_CLIENTES_CLIENTES_TIPOS_ID_TIPO",
                table: "CLIENTES");

            migrationBuilder.DropForeignKey(
                name: "FK_CLIENTES_Usuarios_ID_USUARIO_REGISTRO",
                table: "CLIENTES");

            migrationBuilder.DropForeignKey(
                name: "FK_STOCK_MOVIMIENTOS_CLIENTES_ID_PROVEEDOR_DESTINO",
                table: "STOCK_MOVIMIENTOS");

            migrationBuilder.DropForeignKey(
                name: "FK_STOCK_MOVIMIENTOS_CLIENTES_ID_PROVEEDOR_ORIGEN",
                table: "Stock_Movimientos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CLIENTES",
                table: "CLIENTES");

            migrationBuilder.RenameTable(
                name: "CLIENTES",
                newName: "CLIENTES_PROVEEDORES");

            migrationBuilder.RenameIndex(
                name: "IX_CLIENTES_ID_USUARIO_REGISTRO",
                table: "CLIENTES_PROVEEDORES",
                newName: "IX_CLIENTES_PROVEEDORES_ID_USUARIO_REGISTRO");

            migrationBuilder.RenameIndex(
                name: "IX_CLIENTES_ID_TIPO",
                table: "CLIENTES_PROVEEDORES",
                newName: "IX_CLIENTES_PROVEEDORES_ID_TIPO");

            migrationBuilder.RenameIndex(
                name: "IX_CLIENTES_ID_CATEGORIA",
                table: "CLIENTES_PROVEEDORES",
                newName: "IX_CLIENTES_PROVEEDORES_ID_CATEGORIA");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CLIENTES_PROVEEDORES",
                table: "CLIENTES_PROVEEDORES",
                column: "ID_PROVEEDOR");

            migrationBuilder.AddForeignKey(
                name: "FK_CLIENTES_PROVEEDORES_CLIENTES_CATEGORIAS_ID_CATEGORIA",
                table: "CLIENTES_PROVEEDORES",
                column: "ID_CATEGORIA",
                principalTable: "CLIENTES_CATEGORIAS",
                principalColumn: "ID_CATEGORIA",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CLIENTES_PROVEEDORES_CLIENTES_TIPOS_ID_TIPO",
                table: "CLIENTES_PROVEEDORES",
                column: "ID_TIPO",
                principalTable: "CLIENTES_TIPOS",
                principalColumn: "ID_TIPO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CLIENTES_PROVEEDORES_Usuarios_ID_USUARIO_REGISTRO",
                table: "CLIENTES_PROVEEDORES",
                column: "ID_USUARIO_REGISTRO",
                principalTable: "USUARIOS",
                principalColumn: "USUARIO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_STOCK_MOVIMIENTOS_CLIENTES_PROVEEDORES_ID_PROVEEDOR_DESTINO",
                table: "STOCK_MOVIMIENTOS",
                column: "ID_PROVEEDOR_DESTINO",
                principalTable: "CLIENTES_PROVEEDORES",
                principalColumn: "ID_PROVEEDOR",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_STOCK_MOVIMIENTOS_CLIENTES_PROVEEDORES_ID_PROVEEDOR_ORIGEN",
                table: "STOCK_MOVIMIENTOS",
                column: "ID_PROVEEDOR_ORIGEN",
                principalTable: "CLIENTES_PROVEEDORES",
                principalColumn: "ID_PROVEEDOR",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CLIENTES_PROVEEDORES_CLIENTES_CATEGORIAS_ID_CATEGORIA",
                table: "CLIENTES_PROVEEDORES");

            migrationBuilder.DropForeignKey(
                name: "FK_CLIENTES_PROVEEDORES_CLIENTES_TIPOS_ID_TIPO",
                table: "CLIENTES_PROVEEDORES");

            migrationBuilder.DropForeignKey(
                name: "FK_CLIENTES_PROVEEDORES_Usuarios_ID_USUARIO_REGISTRO",
                table: "CLIENTES_PROVEEDORES");

            migrationBuilder.DropForeignKey(
                name: "FK_STOCK_MOVIMIENTOS_CLIENTES_PROVEEDORES_ID_PROVEEDOR_DESTINO",
                table: "STOCK_MOVIMIENTOS");

            migrationBuilder.DropForeignKey(
                name: "FK_STOCK_MOVIMIENTOS_CLIENTES_PROVEEDORES_ID_PROVEEDOR_ORIGEN",
                table: "STOCK_MOVIMIENTOS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CLIENTES_PROVEEDORES",
                table: "CLIENTES_PROVEEDORES");

            migrationBuilder.RenameTable(
                name: "CLIENTES_PROVEEDORES",
                newName: "CLIENTES");

            migrationBuilder.RenameIndex(
                name: "IX_CLIENTES_PROVEEDORES_ID_USUARIO_REGISTRO",
                table: "CLIENTES",
                newName: "IX_CLIENTES_ID_USUARIO_REGISTRO");

            migrationBuilder.RenameIndex(
                name: "IX_CLIENTES_PROVEEDORES_ID_TIPO",
                table: "CLIENTES",
                newName: "IX_CLIENTES_ID_TIPO");

            migrationBuilder.RenameIndex(
                name: "IX_CLIENTES_PROVEEDORES_ID_CATEGORIA",
                table: "CLIENTES",
                newName: "IX_CLIENTES_ID_CATEGORIA");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CLIENTES",
                table: "CLIENTES",
                column: "ID_PROVEEDOR");

            migrationBuilder.AddForeignKey(
                name: "FK_CLIENTES_CLIENTES_CATEGORIAS_ID_CATEGORIA",
                table: "CLIENTES",
                column: "ID_CATEGORIA",
                principalTable: "CLIENTES_CATEGORIAS",
                principalColumn: "ID_CATEGORIA",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CLIENTES_CLIENTES_TIPOS_ID_TIPO",
                table: "CLIENTES",
                column: "ID_TIPO",
                principalTable: "CLIENTES_TIPOS",
                principalColumn: "ID_TIPO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CLIENTES_Usuarios_ID_USUARIO_REGISTRO",
                table: "CLIENTES",
                column: "ID_USUARIO_REGISTRO",
                principalTable: "USUARIOS",
                principalColumn: "USUARIO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_STOCK_MOVIMIENTOS_CLIENTES_ID_PROVEEDOR_DESTINO",
                table: "STOCK_MOVIMIENTOS",
                column: "ID_PROVEEDOR_DESTINO",
                principalTable: "CLIENTES",
                principalColumn: "ID_PROVEEDOR",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_STOCK_MOVIMIENTOS_CLIENTES_ID_PROVEEDOR_ORIGEN",
                table: "STOCK_MOVIMIENTOS",
                column: "ID_PROVEEDOR_ORIGEN",
                principalTable: "CLIENTES",
                principalColumn: "ID_PROVEEDOR",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
