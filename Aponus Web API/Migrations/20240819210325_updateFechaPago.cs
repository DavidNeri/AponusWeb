using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class updateFechaPago : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.AlterColumn<int>(
                name: "ID_ESTADO_CUOTA",
                table: "CUOTAS_VENTAS",
                type: "int",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FECHA_PAGO",
                table: "CUOTAS_VENTAS",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CODIGO_MPAGO",
                table: "MEDIOS_PAGO");

            migrationBuilder.AlterColumn<int>(
                name: "ID_ESTADO_CUOTA",
                table: "CUOTAS_VENTAS",
                type: "int",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FECHA_PAGO",
                table: "CUOTAS_VENTAS",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);
        }
    }
}
