using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Compras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    IDCOMPRA = table.Column<int>(name: "ID_COMPRA", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDPROVEEDOR = table.Column<int>(name: "ID_PROVEEDOR", type: "int", nullable: false),
                    FECHAHORA = table.Column<DateTime>(name: "FECHA_HORA", type: "datetime2", nullable: false),
                    IdUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDESTADOCOMPRA = table.Column<int>(name: "ID_ESTADO_COMPRA", type: "int", nullable: false),
                    SALDOTOTAL = table.Column<decimal>(name: "SALDO_TOTAL", type: "decimal(18,2)", nullable: false),
                    SALDOCANCELADO = table.Column<decimal>(name: "SALDO_CANCELADO", type: "decimal(18,2)", nullable: true),
                    UsuariosUsuario = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.IDCOMPRA);
                    table.ForeignKey(
                        name: "FK_Compras_Usuarios_UsuariosUsuario",
                        column: x => x.UsuariosUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "USUARIO");
                });

            migrationBuilder.CreateTable(
                name: "ComprasDetalles",
                columns: table => new
                {
                    IdCompra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdInsumo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CANTIDAD = table.Column<int>(type: "int", nullable: false),
                    DetallesInsumoIdInsumo = table.Column<string>(type: "varchar(50)", nullable: false),
                    CompraIdCompra = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComprasDetalles", x => x.IdCompra);
                    table.ForeignKey(
                        name: "FK_ComprasDetalles_COMPONENTES_DETALLE_DetallesInsumoIdInsumo",
                        column: x => x.DetallesInsumoIdInsumo,
                        principalTable: "COMPONENTES_DETALLE",
                        principalColumn: "ID_INSUMO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComprasDetalles_Compras_CompraIdCompra",
                        column: x => x.CompraIdCompra,
                        principalTable: "Compras",
                        principalColumn: "ID_COMPRA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PagosCompras",
                columns: table => new
                {
                    IDPAGO = table.Column<int>(name: "ID_PAGO", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCompra = table.Column<int>(type: "int", nullable: false),
                    IdMedioPago = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CANTIDADCUOTAS = table.Column<int>(name: "CANTIDAD_CUOTAS", type: "int", nullable: true),
                    CANTIDADCUOTASCANCELADAS = table.Column<int>(name: "CANTIDAD_CUOTAS_CANCELADAS", type: "int", nullable: true),
                    SUBTOTAL = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TOTAL = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SUBTOTALCANCELADO = table.Column<decimal>(name: "SUBTOTAL_CANCELADO", type: "decimal(18,2)", nullable: true),
                    ComprasIdCompra = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagosCompras", x => x.IDPAGO);
                    table.ForeignKey(
                        name: "FK_PagosCompras_Compras_ComprasIdCompra",
                        column: x => x.ComprasIdCompra,
                        principalTable: "Compras",
                        principalColumn: "ID_COMPRA");
                });

            migrationBuilder.CreateTable(
                name: "MediosPago",
                columns: table => new
                {
                    IDMEDIOPAGO = table.Column<string>(name: "ID_MEDIO_PAGO", type: "nvarchar(450)", nullable: false),
                    DESCRIPCION = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDESTADO = table.Column<int>(name: "ID_ESTADO", type: "int", nullable: false),
                    PagosComprasIdPago = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediosPago", x => x.IDMEDIOPAGO);
                    table.ForeignKey(
                        name: "FK_MediosPago_PagosCompras_PagosComprasIdPago",
                        column: x => x.PagosComprasIdPago,
                        principalTable: "PagosCompras",
                        principalColumn: "ID_PAGO");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compras_UsuariosUsuario",
                table: "Compras",
                column: "UsuariosUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_ComprasDetalles_CompraIdCompra",
                table: "ComprasDetalles",
                column: "CompraIdCompra");

            migrationBuilder.CreateIndex(
                name: "IX_ComprasDetalles_DetallesInsumoIdInsumo",
                table: "ComprasDetalles",
                column: "DetallesInsumoIdInsumo");

            migrationBuilder.CreateIndex(
                name: "IX_MediosPago_PagosComprasIdPago",
                table: "MediosPago",
                column: "PagosComprasIdPago");

            migrationBuilder.CreateIndex(
                name: "IX_PagosCompras_ComprasIdCompra",
                table: "PagosCompras",
                column: "ComprasIdCompra");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComprasDetalles");

            migrationBuilder.DropTable(
                name: "MediosPago");

            migrationBuilder.DropTable(
                name: "PagosCompras");

            migrationBuilder.DropTable(
                name: "Compras");
        }
    }
}
