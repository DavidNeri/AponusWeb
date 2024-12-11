using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aponus_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class RelacionPagosCupotasCompras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PAGOS_CUOTAS_COMPRAS");

            migrationBuilder.DropTable(
                name: "PAGOS_CUOTAS_VENTAS");

            migrationBuilder.AddColumn<int>(
                name: "ID_CUOTA",
                table: "PAGOS_COMPRAS",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PAGOS_COMPRAS_ID_CUOTA",
                table: "PAGOS_COMPRAS",
                column: "ID_CUOTA");

            migrationBuilder.AddForeignKey(
                name: "FK_PAGOS_COMPRAS_CUOTAS_COMPRAS_ID_CUOTA",
                table: "PAGOS_COMPRAS",
                column: "ID_CUOTA",
                principalTable: "CUOTAS_COMPRAS",
                principalColumn: "ID_CUOTA");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PAGOS_COMPRAS_CUOTAS_COMPRAS_ID_CUOTA",
                table: "PAGOS_COMPRAS");

            migrationBuilder.DropIndex(
                name: "IX_PAGOS_COMPRAS_ID_CUOTA",
                table: "PAGOS_COMPRAS");

            migrationBuilder.DropColumn(
                name: "ID_CUOTA",
                table: "PAGOS_COMPRAS");

            migrationBuilder.CreateTable(
                name: "PAGOS_CUOTAS_COMPRAS",
                columns: table => new
                {
                    ID_PAGO = table.Column<int>(type: "int", nullable: false),
                    ID_CUOTA = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAGOS_CUOTAS_COMPRAS", x => new { x.ID_PAGO, x.ID_CUOTA });
                    table.ForeignKey(
                        name: "FK_PAGOS_CUOTAS_COMPRAS_CUOTAS_COMPRAS_ID_CUOTA",
                        column: x => x.ID_CUOTA,
                        principalTable: "CUOTAS_COMPRAS",
                        principalColumn: "ID_CUOTA",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PAGOS_CUOTAS_COMPRAS_PAGOS_COMPRAS_ID_PAGO",
                        column: x => x.ID_PAGO,
                        principalTable: "PAGOS_COMPRAS",
                        principalColumn: "ID_PAGO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PAGOS_CUOTAS_VENTAS",
                columns: table => new
                {
                    ID_PAGO = table.Column<int>(type: "int", nullable: false),
                    ID_CUOTA = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAGOS_CUOTAS_VENTAS", x => new { x.ID_PAGO, x.ID_CUOTA });
                    table.ForeignKey(
                        name: "FK_PAGOS_CUOTAS_VENTAS_CUOTAS_VENTAS_ID_CUOTA",
                        column: x => x.ID_CUOTA,
                        principalTable: "CUOTAS_VENTAS",
                        principalColumn: "ID_CUOTA",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PAGOS_CUOTAS_VENTAS_PAGOS_VENTAS_ID_PAGO",
                        column: x => x.ID_PAGO,
                        principalTable: "PAGOS_VENTAS",
                        principalColumn: "ID_PAGO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PAGOS_CUOTAS_COMPRAS_ID_CUOTA",
                table: "PAGOS_CUOTAS_COMPRAS",
                column: "ID_CUOTA");

            migrationBuilder.CreateIndex(
                name: "IX_PAGOS_CUOTAS_VENTAS_ID_CUOTA",
                table: "PAGOS_CUOTAS_VENTAS",
                column: "ID_CUOTA");
        }
    }
}
