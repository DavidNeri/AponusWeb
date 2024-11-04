using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Aponus_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class Compras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ESTADOS_COMPRAS",
                columns: table => new
                {
                    IdEstadoCompra = table.Column<int>(name: "ID_ESTADO_COMPRA", nullable: false, type: "int")
                        .Annotation("Npgsql: ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descripcion = table.Column<string>(name: "DESCRIPCION", type: "text", nullable: false),
                    IdEstado = table.Column<int>(name: "ID_ESTADO", type: "integer", nullable: false, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESTADOS_COMPRAS", X => X.IdEstadoCompra);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ESTADOS_COMPRAS_ID_ESTADO_COMPRA",
                table: "ESTADOS_COMPRAS",
                column: "ID_ESTADO_COMPRA");

            migrationBuilder.CreateTable(
                name: "ESTADOS_CUOTAS_COMPRAS",
                columns: table => new
                {
                    IDESTADOCUOTA = table.Column<int>(name: "ID_ESTADO_CUOTA", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DESCRIPCION = table.Column<string>(type: "text", nullable: false),
                    IDESTADO = table.Column<int>(name: "ID_ESTADO", type: "integer", nullable: false, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESTADOS_CUOTAS_COMPRAS", x => x.IDESTADOCUOTA);
                });

            migrationBuilder.CreateTable(
                name: "CUOTAS_COMPRAS",
                columns: table => new
                {
                    IDCUOTA = table.Column<int>(name: "ID_CUOTA", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdCompra = table.Column<int>(name: "ID_COMPRA", type: "int", nullable: false),
                    NUMEROCUOTA = table.Column<int>(name: "NUMERO_CUOTA", type: "integer", nullable: false),
                    MONTO = table.Column<decimal>(name: "MONTO", type: "numeric(18,2)", nullable: false),
                    FECHAVENCIMIENTO = table.Column<DateTime>(name: "FECHA_VENCIMIENTO", type: "timestamp", nullable: false),
                    IdEstadoCuota = table.Column<int>(name: "ID_ESTADO_CUOTA", type: "integer", nullable: false),
                    FECHAPAGO = table.Column<DateTime>(name: "FECHA_PAGO", type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUOTAS_COMPRAS", x => x.IDCUOTA);
                    table.ForeignKey(
                        name: "FK_CUOTAS_COMPRAS_COMPRAS_ID_COMPRA",
                        column: x => x.IdCompra,
                        principalTable: "COMPRAS",
                        principalColumn: "ID_COMPRA",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CUOTAS_COMPRAS_ESTADOS_CUOTAS_COMPRAS_ID_ESTADO_CUOTA",
                        column: x => x.IdEstadoCuota,
                        principalTable: "ESTADOS_CUOTAS_COMPRAS",
                        principalColumn: "ID_ESTADO_CUOTA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CUOTAS_COMPRAS_ID_COMPRA",
                table: "CUOTAS_COMPRAS",
                column: "ID_COMPRA");

            migrationBuilder.CreateIndex(
                name: "IX_CUOTAS_COMPRAS_ID_ESTADO_CUOTA",
                table: "CUOTAS_COMPRAS",
                column: "ID_ESTADO_CUOTA");

            migrationBuilder.AddForeignKey(
                name: "FK_COMPRAS_ESTADOS_COMPRAS_ID_ESTADO_COMPRA",
                table: "COMPRAS",
                column: "ID_ESTADO_COMPRA",
                principalTable: "ESTADOS_COMPRAS",
                principalColumn: "ID_ESTADO_COMPRA",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COMPRAS_ESTADOS_COMPRAS_ID_ESTADO_COMPRA",
                table: "COMPRAS");

            migrationBuilder.DropForeignKey(
                name: "FK_COMPRAS_USUARIOS_USAURIO",
                table: "COMPRAS");

            migrationBuilder.DropTable(
                name: "CUOTAS_COMPRAS");

            migrationBuilder.DropTable(
                name: "ESTADOS_CUOTAS_COMPRAS");

            migrationBuilder.DropIndex(
                name: "IX_COMPRAS_ID_ESTADO_COMPRA",
                table: "COMPRAS");

            migrationBuilder.AlterColumn<string>(
                name: "DESCRIPCION",
                table: "USUARIOS_PERFILES",
                type: "varcahr(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AddColumn<int>(
                name: "EstadoIdEstadoCompra",
                table: "COMPRAS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_COMPRAS_EstadoIdEstadoCompra",
                table: "COMPRAS",
                column: "EstadoIdEstadoCompra");

            migrationBuilder.AddForeignKey(
                name: "FK_COMPRAS_ESTADOS_COMPRAS_EstadoIdEstadoCompra",
                table: "COMPRAS",
                column: "EstadoIdEstadoCompra",
                principalTable: "ESTADOS_COMPRAS",
                principalColumn: "ID_ESTADO_COMPRA",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_COMPRAS_USUARIOS_ID_USUARIO",
                table: "COMPRAS",
                column: "ID_USUARIO",
                principalTable: "USUARIOS",
                principalColumn: "USUARIO");
        }
    }
}
