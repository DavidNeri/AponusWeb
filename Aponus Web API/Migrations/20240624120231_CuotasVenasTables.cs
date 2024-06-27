using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class CuotasVenasTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ESTADOS_CUOTAS_VENTAS",
                columns: table => new
                {
                    IDESTADOCUOTA = table.Column<int>(name: "ID_ESTADO_CUOTA", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRIPCION = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    IDESTADO = table.Column<int>(name: "ID_ESTADO", type: "int", nullable: false, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESTADOS_CUOTAS_VENTAS", x => x.IDESTADOCUOTA);
                });

            migrationBuilder.CreateTable(
                name: "CUOTAS_VENTAS",
                columns: table => new
                {
                    IDCUOTA = table.Column<int>(name: "ID_CUOTA", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDVENTA = table.Column<int>(name: "ID_VENTA", type: "int", nullable: false),
                    NUMEROCUOTA = table.Column<string>(name: "NUMERO_CUOTA", type: "varchar(max)", nullable: false),
                    MONTO = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValueSql: "0.00"),
                    FECHAVENCIMIENTO = table.Column<DateTime>(name: "FECHA_VENCIMIENTO", type: "datetime", nullable: false),
                    IDESTADOCUOTA = table.Column<int>(name: "ID_ESTADO_CUOTA", type: "int", nullable: false, defaultValueSql: "0"),
                    FECHAPAGO = table.Column<DateTime>(name: "FECHA_PAGO", type: "datetime", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUOTAS_VENTAS", x => x.IDCUOTA);
                    table.ForeignKey(
                        name: "FK_CUOTAS_VENTAS_ESTADOS_CUOTAS_VENTAS_ID_ESTADO_CUOTA",
                        column: x => x.IDESTADOCUOTA,
                        principalTable: "ESTADOS_CUOTAS_VENTAS",
                        principalColumn: "ID_ESTADO_CUOTA",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CUOTAS_VENTAS_VENTAS_ID_VENTA",
                        column: x => x.IDVENTA,
                        principalTable: "VENTAS",
                        principalColumn: "ID_VENTA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CUOTAS_VENTAS_ID_ESTADO_CUOTA",
                table: "CUOTAS_VENTAS",
                column: "ID_ESTADO_CUOTA");

            migrationBuilder.CreateIndex(
                name: "IX_CUOTAS_VENTAS_ID_VENTA",
                table: "CUOTAS_VENTAS",
                column: "ID_VENTA");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CUOTAS_VENTAS");

            migrationBuilder.DropTable(
                name: "ESTADOS_CUOTAS_VENTAS");
        }
    }
}
