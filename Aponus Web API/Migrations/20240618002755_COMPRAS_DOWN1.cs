using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class COMPRASDOWN1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Usuarios_UsuariosUsuario",
                table: "Compras");

            migrationBuilder.DropForeignKey(
                name: "FK_ComprasDetalles_Compras_CompraIdCompra",
                table: "ComprasDetalles");

            migrationBuilder.DropForeignKey(
                name: "FK_PagosCompras_Compras_ComprasIdCompra",
                table: "PagosCompras");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Compras",
                table: "Compras");

            migrationBuilder.DropIndex(
                name: "IX_Compras_UsuariosUsuario",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "UsuariosUsuario",
                table: "Compras");      
            
            migrationBuilder.RenameColumn(
              name: "idUsuario",
              newName: "ID_USUARIO",
              table: "Compras");

            migrationBuilder.RenameTable(
                name: "Compras",
                newName: "COMPRAS");

            migrationBuilder.AddPrimaryKey(
                name: "PK_COMPRAS",
                column: "ID_COMPRA",
                table:"COMPRAS");

            migrationBuilder.AlterColumn<string>(
                name: "ID_USUARIO",
                table: "COMPRAS",
                oldType: "nvarchar(MAX)",
                type: "varchar(50)");

            migrationBuilder.AddForeignKey(
                name: "FK_COMPRAS_USUARIOS_IDUSUARIO",
                principalTable: "USUARIOS",
                principalColumn: "USUARIO",
                table: "COMPRAS",
                column: "ID_USUARIO");

            migrationBuilder.AddForeignKey(
                name: "FK_COMPRAS_CLIENTES_PROVEDORES_ID_PROVEEDOR",
                table: "COMPRAS",
                column: "ID_PROVEEDOR",
                principalTable: "CLIENTES_PROVEEDORES",
                principalColumn: "ID_ENTIDAD");


            migrationBuilder.CreateIndex(
                name: "IX_COMPRAS_ID_USUARIO",
                table: "COMPRAS",
                column: "ID_USUARIO");

            migrationBuilder.CreateIndex(
                name: "IX_COMPRAS_ID_PROVEEDOR",
                table: "COMPRAS",
                column: "ID_PROVEEDOR");

          


          


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
