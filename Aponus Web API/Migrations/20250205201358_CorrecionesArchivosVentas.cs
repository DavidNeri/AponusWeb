using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aponus_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class CorrecionesArchivosVentas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CUOTAS_VENTAS_VENTAS_ID_VENTA",
                table: "CUOTAS_VENTAS");

            migrationBuilder.DropForeignKey(
                name: "FK_PAGOS_VENTAS_VENTAS_ID_VENTA",
                table: "PAGOS_VENTAS");

            migrationBuilder.DropForeignKey(
                name: "FK_VENTAS_DETALLES_VENTAS_ID_VENTA",
                table: "VENTAS_DETALLES");

            migrationBuilder.DropColumn(
                name: "ID_VENTA",
                table: "ARCHIVOS_VENTAS");

            migrationBuilder.AddColumn<int>(
                name: "IdVenta",
                table: "VENTAS_DETALLES",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdVenta",
                table: "PAGOS_VENTAS",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdVenta",
                table: "CUOTAS_VENTAS",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "VALORES_PREVIOS",
                table: "AUDITORIAS",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "VALORES_NUEVOS",
                table: "AUDITORIAS",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CUOTAS_VENTAS_VENTAS_IdVenta",
                table: "CUOTAS_VENTAS",
                column: "IdVenta",
                principalTable: "VENTAS",
                principalColumn: "ID_VENTA",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PAGOS_VENTAS_VENTAS_IdVenta",
                table: "PAGOS_VENTAS",
                column: "IdVenta",
                principalTable: "VENTAS",
                principalColumn: "ID_VENTA",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VENTAS_DETALLES_VENTAS_IdVenta",
                table: "VENTAS_DETALLES",
                column: "IdVenta",
                principalTable: "VENTAS",
                principalColumn: "ID_VENTA",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
