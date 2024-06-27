using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class TablasVentas1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ESTADOS_VENTAS",
                columns: table => new
                {
                    IDESTADOVENTA = table.Column<int>(name: "ID_ESTADO_VENTA", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRIPCION = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDESTADO = table.Column<int>(name: "ID_ESTADO", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESTADOS_VENTAS", x => x.IDESTADOVENTA);
                });

            migrationBuilder.CreateTable(
                name: "VENTAS",
                columns: table => new
                {
                    IDVENTA = table.Column<int>(name: "ID_VENTA", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDPROVEEDOR = table.Column<int>(name: "ID_PROVEEDOR", type: "int", nullable: false),
                    FECHAHORA = table.Column<DateTime>(name: "FECHA_HORA", type: "datetime", nullable: false),
                    IDUSUARIO = table.Column<string>(name: "ID_USUARIO", type: "varchar(50)", nullable: false),
                    IDESTADOVENTA = table.Column<int>(name: "ID_ESTADO_VENTA", type: "int", nullable: false),
                    SALDOTOTAL = table.Column<decimal>(name: "SALDO_TOTAL", type: "decimal(18,2)", nullable: false),
                    SALDOCANCELADO = table.Column<decimal>(name: "SALDO_CANCELADO", type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VENTAS", x => x.IDVENTA);
                    table.ForeignKey(
                        name: "FK_VENTAS_CLIENTES_PROVEEDORES_ID_PROVEEDOR",
                        column: x => x.IDPROVEEDOR,
                        principalTable: "CLIENTES_PROVEEDORES",
                        principalColumn: "ID_ENTIDAD");
                    table.ForeignKey(
                        name: "FK_VENTAS_ESTADOS_VENTAS_ID_ESTADO_VENTA",
                        column: x => x.IDESTADOVENTA,
                        principalTable: "ESTADOS_VENTAS",
                        principalColumn: "ID_ESTADO_VENTA",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VENTAS_USUARIOS_ID_USUARIO",
                        column: x => x.IDUSUARIO,
                        principalTable: "USUARIOS",
                        principalColumn: "USUARIO");
                });

            migrationBuilder.CreateTable(
                name: "PAGOS_VENTAS",
                columns: table => new
                {
                    IDPAGO = table.Column<int>(name: "ID_PAGO", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDVENTA = table.Column<int>(name: "ID_VENTA", type: "int", nullable: false),
                    IDMEDIOPAGO = table.Column<int>(name: "ID_MEDIO_PAGO", type: "int", nullable: false),
                    CANTIDADCUOTAS = table.Column<int>(name: "CANTIDAD_CUOTAS", type: "int", nullable: true),
                    CANTIDADCUOTASCANCELADAS = table.Column<int>(name: "CANTIDAD_CUOTAS_CANCELADAS", type: "int", nullable: true),
                    SUBTOTAL = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TOTAL = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SUBTOTALCANCELADO = table.Column<decimal>(name: "SUBTOTAL_CANCELADO", type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAGOS_VENTAS", x => x.IDPAGO);
                    table.ForeignKey(
                        name: "FK_PAGOS_VENTAS_MEDIOS_PAGO_ID_MEDIO_PAGO",
                        column: x => x.IDMEDIOPAGO,
                        principalTable: "MEDIOS_PAGO",
                        principalColumn: "ID_MEDIO_PAGO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PAGOS_VENTAS_VENTAS_ID_VENTA",
                        column: x => x.IDVENTA,
                        principalTable: "VENTAS",
                        principalColumn: "ID_VENTA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VENTAS_DETALLES",
                columns: table => new
                {
                    IDVENTA = table.Column<int>(name: "ID_VENTA", type: "int", nullable: false),
                    IDPRODUCTO = table.Column<string>(name: "ID_PRODUCTO", type: "varchar(50)", nullable: false),
                    CANTIDAD = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VENTAS_DETALLES", x => new { x.IDVENTA, x.IDPRODUCTO });
                    table.ForeignKey(
                        name: "FK_VENTAS_DETALLES_PRODUCTOS_ID_PRODUCTO",
                        column: x => x.IDPRODUCTO,
                        principalTable: "PRODUCTOS",
                        principalColumn: "ID_PRODUCTO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VENTAS_DETALLES_VENTAS_ID_VENTA",
                        column: x => x.IDVENTA,
                        principalTable: "VENTAS",
                        principalColumn: "ID_VENTA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PAGOS_VENTAS_ID_MEDIO_PAGO",
                table: "PAGOS_VENTAS",
                column: "ID_MEDIO_PAGO");

            migrationBuilder.CreateIndex(
                name: "IX_PAGOS_VENTAS_ID_VENTA",
                table: "PAGOS_VENTAS",
                column: "ID_VENTA");

            migrationBuilder.CreateIndex(
                name: "IX_VENTAS_ID_ESTADO_VENTA",
                table: "VENTAS",
                column: "ID_ESTADO_VENTA");

            migrationBuilder.CreateIndex(
                name: "IX_VENTAS_ID_PROVEEDOR",
                table: "VENTAS",
                column: "ID_PROVEEDOR");

            migrationBuilder.CreateIndex(
                name: "IX_VENTAS_ID_USUARIO",
                table: "VENTAS",
                column: "ID_USUARIO");

            migrationBuilder.CreateIndex(
                name: "IX_VENTAS_DETALLES_ID_PRODUCTO",
                table: "VENTAS_DETALLES",
                column: "ID_PRODUCTO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PAGOS_VENTAS");

            migrationBuilder.DropTable(
                name: "VENTAS_DETALLES");

            migrationBuilder.DropTable(
                name: "VENTAS");

            migrationBuilder.DropTable(
                name: "ESTADOS_VENTAS");
        }
    }
}
