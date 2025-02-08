using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Aponus_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class CreacionTablasPagosCuotasComprasyPagosCuotasVentas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                table: "PAGOS_COMPRAS",
                name: "ID_ENTIDAD_PAGO",
                type: "integer",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                table: "PAGOS_VENTAS",
                name: "ID_ENTIDAD_PAGO",
                type: "integer",
                nullable: false);

            migrationBuilder.CreateTable(
                name: "ENTIDADES_PAGO",
                columns: table => new
                {
                    ID_ENTIDAD = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TIPO = table.Column<string>(type: "text", nullable: true),
                    DESCRIPCION = table.Column<string>(type: "text", nullable: true),
                    EMISOR = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENTIDADES_PAGO", x => x.ID_ENTIDAD);
                });

            migrationBuilder.CreateTable(
                name: "PAGOS_CUOTAS_COMPRAS",
                columns: table => new
                {
                    ID_CUOTA = table.Column<int>(type: "int", nullable: false),
                    IdCuota = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAGOS_CUOTAS_COMPRAS", x => new { x.ID_CUOTA, x.IdCuota });
                    table.ForeignKey(
                        name: "FK_PAGOS_CUOTAS_COMPRAS_CUOTAS_COMPRAS_ID_CUOTA",
                        column: x => x.IdCuota,
                        principalTable: "CUOTAS_COMPRAS",
                        principalColumn: "ID_CUOTA",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PAGOS_CUOTAS_COMPRAS_PAGOS_COMPRAS_ID_PAGO",
                        column: x => x.ID_CUOTA,
                        principalTable: "PAGOS_COMPRAS",
                        principalColumn: "ID_PAGO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PAGOS_CUOTAS_VENTAS",
                columns: table => new
                {
                    ID_CUOTA = table.Column<int>(type: "int", nullable: false),
                    IdCuota = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAGOS_CUOTAS_VENTAS", x => new { x.ID_CUOTA, x.IdCuota });
                    table.ForeignKey(
                        name: "FK_PAGOS_CUOTAS_VENTAS_CUOTAS_VENTAS_ID_CUOTA",
                        column: x => x.IdCuota,
                        principalTable: "CUOTAS_VENTAS",
                        principalColumn: "ID_CUOTA",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PAGOS_CUOTAS_VENTAS_PAGOS_VENTAS_ID_PAGO",
                        column: x => x.ID_CUOTA,
                        principalTable: "PAGOS_VENTAS",
                        principalColumn: "ID_PAGO",
                        onDelete: ReferentialAction.Cascade);
                });



            migrationBuilder.CreateIndex(
                name: "IX_PAGOS_CUOTAS_COMPRAS_IdCuota",
                table: "PAGOS_CUOTAS_COMPRAS",
                column: "ID_CUOTA");

            migrationBuilder.CreateIndex(
                name: "IX_PAGOS_CUOTAS_VENTAS_ID_CUOTA",
                table: "PAGOS_CUOTAS_VENTAS",
                column: "ID_CUOTA");

            migrationBuilder.AddForeignKey(
                name: "FK_PAGOS_VENTAS_ENTIDADES_PAGO_ID_ENTIDAD_PAGO",
                table: "PAGOS_VENTAS",
                column: "ID_ENTIDAD_PAGO",
                principalTable: "ENTIDADES_PAGO",
                principalColumn: "ID_ENTIDAD",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PAGOS_VENTAS_ENTIDADES_PAGO_ID_ENTIDAD_PAGO",
                table: "PAGOS_VENTAS");

            migrationBuilder.DropTable(
                name: "ENTIDADES_PAGO");

            migrationBuilder.DropTable(
                name: "pagosCuotasCompras");

            migrationBuilder.DropTable(
                name: "pagosCuotasVentas");

            migrationBuilder.DropIndex(
                name: "IX_PAGOS_VENTAS_IdEntidadaPago",
                table: "PAGOS_VENTAS");

            migrationBuilder.DropColumn(
                name: "IdEntidadaPago",
                table: "PAGOS_VENTAS");
        }
    }
}
