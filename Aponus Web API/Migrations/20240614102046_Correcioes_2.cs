using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Correcioes2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropIndex(
                name: "IX_MediosPago_PagosComprasIdPago",
                table: "MediosPago");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MediosPago",
                table: "MediosPago");

            migrationBuilder.DropForeignKey(
               name: "FK_MediosPago_PagosCompras_PagosComprasIdPago",
               table: "MediosPago");

            migrationBuilder.DropColumn(
              name: "PagosComprasIdPago",
              table: "MediosPago");


            migrationBuilder.RenameTable(
                name: "MediosPago",
                newName: "MEDIOS_PAGO");

           ;
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COMPRAS_CLIENTES_PROVEEDORES_ID_PROVEEDOR",
                table: "COMPRAS");

            migrationBuilder.DropForeignKey(
                name: "FK_COMPRAS_ESTADOS_COMPRAS_ID_ESTADO_COMPRA",
                table: "COMPRAS");

            migrationBuilder.DropForeignKey(
                name: "FK_COMPRAS_Usuarios_ID_USUARIO",
                table: "COMPRAS");

            migrationBuilder.DropForeignKey(
                name: "FK_COMPRAS_DETALLES_COMPONENTES_DETALLE_ID_INSUMO",
                table: "COMPRAS_DETALLES");

            migrationBuilder.DropForeignKey(
                name: "FK_COMPRAS_DETALLES_COMPRAS_ID_COMPRA",
                table: "COMPRAS_DETALLES");

            migrationBuilder.DropForeignKey(
                name: "FK_PAGOS_COMPRAS_COMPRAS_ID_COMPRA",
                table: "PAGOS_COMPRAS");

            migrationBuilder.DropForeignKey(
                name: "FK_PAGOS_COMPRAS_MEDIOS_PAGO_ID_MEDIO_PAGO",
                table: "PAGOS_COMPRAS");

            migrationBuilder.DropTable(
                name: "ESTADOS_COMPRAS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_COMPRAS",
                table: "COMPRAS");

            migrationBuilder.DropIndex(
                name: "IX_COMPRAS_ID_ESTADO_COMPRA",
                table: "COMPRAS");

            migrationBuilder.DropIndex(
                name: "IX_COMPRAS_ID_PROVEEDOR",
                table: "COMPRAS");

            migrationBuilder.DropIndex(
                name: "IX_COMPRAS_ID_USUARIO",
                table: "COMPRAS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PAGOS_COMPRAS",
                table: "PAGOS_COMPRAS");

            migrationBuilder.DropIndex(
                name: "IX_PAGOS_COMPRAS_ID_COMPRA",
                table: "PAGOS_COMPRAS");

            migrationBuilder.DropIndex(
                name: "IX_PAGOS_COMPRAS_ID_MEDIO_PAGO",
                table: "PAGOS_COMPRAS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MEDIOS_PAGO",
                table: "MEDIOS_PAGO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_COMPRAS_DETALLES",
                table: "COMPRAS_DETALLES");

            migrationBuilder.DropIndex(
                name: "IX_COMPRAS_DETALLES_ID_INSUMO",
                table: "COMPRAS_DETALLES");

            migrationBuilder.DropColumn(
                name: "CODIGO_MPAGO",
                table: "MEDIOS_PAGO");

            migrationBuilder.RenameTable(
                name: "COMPRAS",
                newName: "Compras");

            migrationBuilder.RenameTable(
                name: "PAGOS_COMPRAS",
                newName: "PagosCompras");

            migrationBuilder.RenameTable(
                name: "MEDIOS_PAGO",
                newName: "MediosPago");

            migrationBuilder.RenameTable(
                name: "COMPRAS_DETALLES",
                newName: "ComprasDetalles");

            migrationBuilder.RenameColumn(
                name: "ID_USUARIO",
                table: "Compras",
                newName: "IdUsuario");

            migrationBuilder.RenameColumn(
                name: "ID_MEDIO_PAGO",
                table: "PagosCompras",
                newName: "IdMedioPago");

            migrationBuilder.RenameColumn(
                name: "ID_COMPRA",
                table: "PagosCompras",
                newName: "IdCompra");

            migrationBuilder.RenameColumn(
                name: "ID_INSUMO",
                table: "ComprasDetalles",
                newName: "IdInsumo");

            migrationBuilder.RenameColumn(
                name: "ID_COMPRA",
                table: "ComprasDetalles",
                newName: "IdCompra");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FECHA_HORA",
                table: "Compras",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "IdUsuario",
                table: "Compras",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AddColumn<string>(
                name: "UsuariosUsuario",
                table: "Compras",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdMedioPago",
                table: "PagosCompras",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ComprasIdCompra",
                table: "PagosCompras",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ID_MEDIO_PAGO",
                table: "MediosPago",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "PagosComprasIdPago",
                table: "MediosPago",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CANTIDAD",
                table: "ComprasDetalles",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "IdInsumo",
                table: "ComprasDetalles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<int>(
                name: "IdCompra",
                table: "ComprasDetalles",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CompraIdCompra",
                table: "ComprasDetalles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DetallesInsumoIdInsumo",
                table: "ComprasDetalles",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Compras",
                table: "Compras",
                column: "ID_COMPRA");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PagosCompras",
                table: "PagosCompras",
                column: "ID_PAGO");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MediosPago",
                table: "MediosPago",
                column: "ID_MEDIO_PAGO");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ComprasDetalles",
                table: "ComprasDetalles",
                column: "IdCompra");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_UsuariosUsuario",
                table: "Compras",
                column: "UsuariosUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_PagosCompras_ComprasIdCompra",
                table: "PagosCompras",
                column: "ComprasIdCompra");

            migrationBuilder.CreateIndex(
                name: "IX_MediosPago_PagosComprasIdPago",
                table: "MediosPago",
                column: "PagosComprasIdPago");

            migrationBuilder.CreateIndex(
                name: "IX_ComprasDetalles_CompraIdCompra",
                table: "ComprasDetalles",
                column: "CompraIdCompra");

            migrationBuilder.CreateIndex(
                name: "IX_ComprasDetalles_DetallesInsumoIdInsumo",
                table: "ComprasDetalles",
                column: "DetallesInsumoIdInsumo");

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Usuarios_UsuariosUsuario",
                table: "Compras",
                column: "UsuariosUsuario",
                principalTable: "Usuarios",
                principalColumn: "USUARIO");

            migrationBuilder.AddForeignKey(
                name: "FK_ComprasDetalles_COMPONENTES_DETALLE_DetallesInsumoIdInsumo",
                table: "ComprasDetalles",
                column: "DetallesInsumoIdInsumo",
                principalTable: "COMPONENTES_DETALLE",
                principalColumn: "ID_INSUMO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComprasDetalles_Compras_CompraIdCompra",
                table: "ComprasDetalles",
                column: "CompraIdCompra",
                principalTable: "Compras",
                principalColumn: "ID_COMPRA",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MediosPago_PagosCompras_PagosComprasIdPago",
                table: "MediosPago",
                column: "PagosComprasIdPago",
                principalTable: "PagosCompras",
                principalColumn: "ID_PAGO");

            migrationBuilder.AddForeignKey(
                name: "FK_PagosCompras_Compras_ComprasIdCompra",
                table: "PagosCompras",
                column: "ComprasIdCompra",
                principalTable: "Compras",
                principalColumn: "ID_COMPRA");
        }
    }
}
