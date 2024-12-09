using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aponus_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class CreacionCampoIdEntidadPagoTablaPagosCompras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PAGOS_VENTAS_ENTIDADES_PAGO_ID_ENTIDAD_PAGO",
                table: "PAGOS_VENTAS");

            migrationBuilder.DropForeignKey(
                name: "FK_PAGOS_CUOTAS_COMPRAS_CUOTAS_COMPRAS_ID_CUOTA",
                table: "PAGOS_CUOTAS_COMPRAS");

            migrationBuilder.DropForeignKey(
                name: "FK_PAGOS_CUOTAS_COMPRAS_PAGOS_COMPRAS_ID_PAGO",
                table: "PAGOS_CUOTAS_COMPRAS");

            migrationBuilder.DropForeignKey(
                name: "FK_PAGOS_CUOTAS_VENTAS_CUOTAS_VENTAS_ID_CUOTA",
                table: "PAGOS_CUOTAS_VENTAS");


            migrationBuilder.DropForeignKey(
                name: "FK_PAGOS_CUOTAS_VENTAS_PAGOS_VENTAS_ID_PAGO",
                table: "PAGOS_CUOTAS_VENTAS");
        

            migrationBuilder.DropPrimaryKey(
                name: "PK_PAGOS_CUOTAS_VENTAS",
                table: "PAGOS_CUOTAS_VENTAS");

            migrationBuilder.DropIndex(
                name: "IX_PAGOS_CUOTAS_VENTAS_ID_CUOTA",
                table: "PAGOS_CUOTAS_VENTAS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PAGOS_CUOTAS_COMPRAS",
                table: "PAGOS_CUOTAS_COMPRAS");

            migrationBuilder.DropIndex(
                name: "IX_PAGOS_CUOTAS_COMPRAS_IdCuota",
                table: "PAGOS_CUOTAS_COMPRAS"); 


            migrationBuilder.RenameColumn(
                name: "IdCuota",
                table: "PAGOS_CUOTAS_VENTAS",
                newName: "ID_PAGO");

            migrationBuilder.RenameColumn(
               name: "IdCuota",
               table: "PAGOS_CUOTAS_COMPRAS",
               newName: "ID_PAGO");

       

            migrationBuilder.AddPrimaryKey(
                name: "PK_PAGOS_CUOTAS_VENTAS",
                table: "PAGOS_CUOTAS_VENTAS",
                columns: new[] { "ID_PAGO", "ID_CUOTA" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PAGOS_CUOTAS_COMPRAS",
                table: "PAGOS_CUOTAS_COMPRAS",
                columns: new[] { "ID_PAGO", "ID_CUOTA" });

            migrationBuilder.CreateIndex(
                name: "IX_PAGOS_VENTAS_ID_ENTIDAD_PAGO",
                table: "PAGOS_VENTAS",
                column: "ID_ENTIDAD_PAGO");

            migrationBuilder.CreateIndex(
                name: "IX_PAGOS_COMPRAS_ID_ENTIDAD_PAGO",
                table: "PAGOS_COMPRAS",
                column: "ID_ENTIDAD_PAGO");

            migrationBuilder.CreateIndex(
                name: "IX_PAGOS_CUOTAS_VENTAS_ID_CUOTA",
                table: "PAGOS_CUOTAS_VENTAS",
                column: "ID_CUOTA");

            migrationBuilder.CreateIndex(
                name: "IX_PAGOS_CUOTAS_COMPRAS_ID_CUOTA",
                table: "PAGOS_CUOTAS_COMPRAS",
                column: "ID_CUOTA");

            ////////////

            migrationBuilder.AddForeignKey(
                name: "FK_PAGOS_COMPRAS_ENTIDADES_PAGO_ID_ENTIDAD_PAGO",
                table: "PAGOS_COMPRAS",
                column: "ID_ENTIDAD_PAGO",
                principalTable: "ENTIDADES_PAGO",
                principalColumn: "ID_ENTIDAD",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PAGOS_CUOTAS_COMPRAS_CUOTAS_COMPRAS_ID_CUOTA",
                table: "PAGOS_CUOTAS_COMPRAS",
                column: "ID_CUOTA",
                principalTable: "CUOTAS_COMPRAS",
                principalColumn: "ID_CUOTA",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PAGOS_CUOTAS_COMPRAS_PAGOS_COMPRAS_ID_PAGO",
                table: "PAGOS_CUOTAS_COMPRAS",
                column: "ID_PAGO",
                principalTable: "PAGOS_COMPRAS",
                principalColumn: "ID_PAGO",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PAGOS_CUOTAS_VENTAS_CUOTAS_VENTAS_ID_CUOTA",
                table: "PAGOS_CUOTAS_VENTAS",
                column: "ID_CUOTA",
                principalTable: "CUOTAS_VENTAS",
                principalColumn: "ID_CUOTA",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PAGOS_CUOTAS_VENTAS_PAGOS_VENTAS_ID_PAGO",
                table: "PAGOS_CUOTAS_VENTAS",
                column: "ID_PAGO",
                principalTable: "PAGOS_VENTAS",
                principalColumn: "ID_PAGO",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PAGOS_VENTAS_ENTIDADES_PAGO_ID_ENTIDAD_PAGO",
                table: "PAGOS_VENTAS",
                column: "ID_ENTIDAD_PAGO",
                principalTable: "ENTIDADES_PAGO",
                principalColumn: "ID_ENTIDAD",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PAGOS_COMPRAS_ENTIDADES_PAGO_ID_ENTIDAD_PAGO",
                table: "PAGOS_COMPRAS");

            migrationBuilder.DropForeignKey(
                name: "FK_PAGOS_CUOTAS_COMPRAS_CUOTAS_COMPRAS_ID_CUOTA",
                table: "PAGOS_CUOTAS_COMPRAS");

            migrationBuilder.DropForeignKey(
                name: "FK_PAGOS_CUOTAS_COMPRAS_PAGOS_COMPRAS_ID_PAGO",
                table: "PAGOS_CUOTAS_COMPRAS");

            migrationBuilder.DropForeignKey(
                name: "FK_PAGOS_CUOTAS_VENTAS_CUOTAS_VENTAS_ID_CUOTA",
                table: "PAGOS_CUOTAS_VENTAS");

            migrationBuilder.DropForeignKey(
                name: "FK_PAGOS_CUOTAS_VENTAS_PAGOS_VENTAS_ID_PAGO",
                table: "PAGOS_CUOTAS_VENTAS");

            migrationBuilder.DropForeignKey(
                name: "FK_PAGOS_VENTAS_ENTIDADES_PAGO_ID_ENTIDAD_PAGO",
                table: "PAGOS_VENTAS");

            migrationBuilder.DropIndex(
                name: "IX_PAGOS_VENTAS_ID_ENTIDAD_PAGO",
                table: "PAGOS_VENTAS");

            migrationBuilder.DropIndex(
                name: "IX_PAGOS_COMPRAS_ID_ENTIDAD_PAGO",
                table: "PAGOS_COMPRAS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PAGOS_CUOTAS_VENTAS",
                table: "PAGOS_CUOTAS_VENTAS");

            migrationBuilder.DropIndex(
                name: "IX_PAGOS_CUOTAS_VENTAS_ID_CUOTA",
                table: "PAGOS_CUOTAS_VENTAS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PAGOS_CUOTAS_COMPRAS",
                table: "PAGOS_CUOTAS_COMPRAS");

            migrationBuilder.DropIndex(
                name: "IX_PAGOS_CUOTAS_COMPRAS_ID_CUOTA",
                table: "PAGOS_CUOTAS_COMPRAS");

            migrationBuilder.DropColumn(
                name: "ID_ENTIDAD_PAGO",
                table: "PAGOS_VENTAS");

            migrationBuilder.DropColumn(
                name: "ID_ENTIDAD_PAGO",
                table: "PAGOS_COMPRAS");

            migrationBuilder.DropColumn(
                name: "ID_PAGO",
                table: "PAGOS_CUOTAS_COMPRAS");

            migrationBuilder.RenameTable(
                name: "PAGOS_CUOTAS_VENTAS",
                newName: "pagosCuotasVentas");

            migrationBuilder.RenameTable(
                name: "PAGOS_CUOTAS_COMPRAS",
                newName: "pagosCuotasCompras");

            migrationBuilder.RenameColumn(
                name: "ID_PAGO",
                table: "pagosCuotasVentas",
                newName: "IdCuota");

            migrationBuilder.AddColumn<int>(
                name: "IdEntidadaPago",
                table: "PAGOS_VENTAS",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ID_CUOTA",
                table: "pagosCuotasCompras",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "IdCuota",
                table: "pagosCuotasCompras",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_pagosCuotasVentas",
                table: "pagosCuotasVentas",
                columns: new[] { "ID_CUOTA", "IdCuota" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_pagosCuotasCompras",
                table: "pagosCuotasCompras",
                columns: new[] { "ID_CUOTA", "IdCuota" });

            migrationBuilder.CreateIndex(
                name: "IX_PAGOS_VENTAS_IdEntidadaPago",
                table: "PAGOS_VENTAS",
                column: "IdEntidadaPago");

            migrationBuilder.CreateIndex(
                name: "IX_pagosCuotasVentas_IdCuota",
                table: "pagosCuotasVentas",
                column: "IdCuota");

            migrationBuilder.CreateIndex(
                name: "IX_pagosCuotasCompras_IdCuota",
                table: "pagosCuotasCompras",
                column: "IdCuota");

            migrationBuilder.AddForeignKey(
                name: "FK_PAGOS_VENTAS_ENTIDADES_PAGO_ID_ENTIDAD_PAGO",
                table: "PAGOS_VENTAS",
                column: "IdEntidadaPago",
                principalTable: "ENTIDADES_PAGO",
                principalColumn: "ID_ENTIDAD",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PAGOS_CUOTAS_COMPRAS_CUOTAS_COMPRAS_ID_CUOTA",
                table: "pagosCuotasCompras",
                column: "IdCuota",
                principalTable: "CUOTAS_COMPRAS",
                principalColumn: "ID_CUOTA",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PAGOS_CUOTAS_COMPRAS_PAGOS_COMPRAS_ID_PAGO",
                table: "pagosCuotasCompras",
                column: "ID_CUOTA",
                principalTable: "PAGOS_COMPRAS",
                principalColumn: "ID_PAGO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PAGOS_CUOTAS_VENTAS_CUOTAS_VENTAS_ID_CUOTA",
                table: "pagosCuotasVentas",
                column: "IdCuota",
                principalTable: "CUOTAS_VENTAS",
                principalColumn: "ID_CUOTA",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PAGOS_CUOTAS_VENTAS_PAGOS_VENTAS_ID_PAGO",
                table: "pagosCuotasVentas",
                column: "ID_CUOTA",
                principalTable: "PAGOS_VENTAS",
                principalColumn: "ID_PAGO",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
