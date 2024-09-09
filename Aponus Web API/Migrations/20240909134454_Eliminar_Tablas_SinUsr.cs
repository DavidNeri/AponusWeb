using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class EliminarTablasSinUsr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "COMPONENTES_CUANTITATIVOS");

            migrationBuilder.DropTable(
                name: "COMPONENTES_MENSURABLES");

            migrationBuilder.DropTable(
                name: "COMPONENTES_PESABLES");

            migrationBuilder.DropTable(
                name: "STOCK_CUANTITATIVOS");

            migrationBuilder.DropTable(
                name: "MENSURABLES_DETALLE");

            migrationBuilder.DropTable(
                name: "STOCK_PESABLES");

            migrationBuilder.DropTable(
                name: "CUANTITATIVOS_DETALLE");

            migrationBuilder.DropTable(
                name: "STOCK_MENSURABLES");

            migrationBuilder.DropTable(
                name: "PESABLES_DETALLE");

            migrationBuilder.AlterColumn<int>(
                name: "ENTREGADOS",
                table: "VENTAS_DETALLES",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ENTREGADOS",
                table: "VENTAS_DETALLES",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "CUANTITATIVOS_DETALLE",
                columns: table => new
                {
                    IDCOMPONENTE = table.Column<string>(name: "ID_COMPONENTE", type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IdDescripcionNavigationIdDescripcion = table.Column<int>(type: "int", nullable: true),
                    ALTURA = table.Column<decimal>(type: "decimal(18,2)", nullable: true, defaultValueSql: "((0))"),
                    DIAMETRO = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    ESPESOR = table.Column<decimal>(type: "decimal(18,2)", nullable: true, defaultValueSql: "((0))"),
                    IDDESCRIPCION = table.Column<int>(name: "ID_DESCRIPCION", type: "int", nullable: true),
                    PERFIL = table.Column<int>(type: "int", nullable: true, defaultValueSql: "null"),
                    TOLERANCIA = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUANTITATIVOS_DETALLE", x => x.IDCOMPONENTE);
                    table.ForeignKey(
                        name: "FK_CUANTITATIVOS_DETALLE_COMPONENTES_DESCRIPCION_IdDescripcionNavigationIdDescripcion",
                        column: x => x.IdDescripcionNavigationIdDescripcion,
                        principalTable: "COMPONENTES_DESCRIPCION",
                        principalColumn: "ID_DESCRIPCION");
                });

            migrationBuilder.CreateTable(
                name: "PESABLES_DETALLE",
                columns: table => new
                {
                    IDCOMPONENTE = table.Column<string>(name: "ID_COMPONENTE", type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IdDescripcionNavigationIdDescripcion = table.Column<int>(type: "int", nullable: true),
                    ALTURA = table.Column<decimal>(type: "decimal(18,2)", nullable: true, defaultValueSql: "((0))"),
                    DIAMETRO = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    IDDESCRIPCION = table.Column<int>(name: "ID_DESCRIPCION", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PESABLES_DETALLE", x => x.IDCOMPONENTE);
                    table.ForeignKey(
                        name: "FK_PESABLES_DETALLE_COMPONENTES_DESCRIPCION_IdDescripcionNavigationIdDescripcion",
                        column: x => x.IdDescripcionNavigationIdDescripcion,
                        principalTable: "COMPONENTES_DESCRIPCION",
                        principalColumn: "ID_DESCRIPCION");
                });

            migrationBuilder.CreateTable(
                name: "STOCK_MENSURABLES",
                columns: table => new
                {
                    IDCOMPONENTE = table.Column<string>(name: "ID_COMPONENTE", type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CANTIDADPROCESO = table.Column<int>(name: "CANTIDAD_PROCESO", type: "int", nullable: true, defaultValueSql: "((0))"),
                    CANTIDADRECIBIDO = table.Column<int>(name: "CANTIDAD_RECIBIDO", type: "int", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STOCK_MENSURABLES", x => x.IDCOMPONENTE);
                });

            migrationBuilder.CreateTable(
                name: "STOCK_CUANTITATIVOS",
                columns: table => new
                {
                    IDCOMPONENTE = table.Column<string>(name: "ID_COMPONENTE", type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CANTIDADGRANALLADO = table.Column<int>(name: "CANTIDAD_GRANALLADO", type: "int", nullable: true, defaultValueSql: "((0))"),
                    CANTIDADMOLDEADO = table.Column<int>(name: "CANTIDAD_MOLDEADO", type: "int", nullable: true, defaultValueSql: "((0))"),
                    CANTIDADPINTURA = table.Column<int>(name: "CANTIDAD_PINTURA", type: "int", nullable: true, defaultValueSql: "((0))"),
                    CANTIDADPROCESO = table.Column<int>(name: "CANTIDAD_PROCESO", type: "int", nullable: true, defaultValueSql: "((0))"),
                    CANTIDADRECIBIDO = table.Column<int>(name: "CANTIDAD_RECIBIDO", type: "int", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STOCK_CUANTITATIVOS", x => x.IDCOMPONENTE);
                    table.ForeignKey(
                        name: "FK_STOCK_CUANTITATIVOS_CUANTITATIVOS_DETALLE",
                        column: x => x.IDCOMPONENTE,
                        principalTable: "CUANTITATIVOS_DETALLE",
                        principalColumn: "ID_COMPONENTE");
                });

            migrationBuilder.CreateTable(
                name: "STOCK_PESABLES",
                columns: table => new
                {
                    IDCOMPONENTE = table.Column<string>(name: "ID_COMPONENTE", type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CANTIDADPINTURA = table.Column<decimal>(name: "CANTIDAD_PINTURA", type: "decimal(18,2)", nullable: true, defaultValueSql: "((0))"),
                    CANTIDADPROCESO = table.Column<decimal>(name: "CANTIDAD_PROCESO", type: "decimal(18,2)", nullable: true, defaultValueSql: "((0))"),
                    CANTIDADRECIBIDO = table.Column<decimal>(name: "CANTIDAD_RECIBIDO", type: "decimal(18,2)", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STOCK_PESABLES", x => x.IDCOMPONENTE);
                    table.ForeignKey(
                        name: "FK_STOCK_PESABLES_PESABLES_DETALLE",
                        column: x => x.IDCOMPONENTE,
                        principalTable: "PESABLES_DETALLE",
                        principalColumn: "ID_COMPONENTE");
                });

            migrationBuilder.CreateTable(
                name: "MENSURABLES_DETALLE",
                columns: table => new
                {
                    IDCOMPONENTE = table.Column<string>(name: "ID_COMPONENTE", type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IdDescripcionNavigationIdDescripcion = table.Column<int>(type: "int", nullable: true),
                    ALTURA = table.Column<decimal>(type: "decimal(18,2)", nullable: true, defaultValueSql: "((0))"),
                    ANCHO = table.Column<decimal>(type: "decimal(18,2)", nullable: true, defaultValueSql: "((0))"),
                    ESPESOR = table.Column<decimal>(type: "decimal(18,2)", nullable: true, defaultValueSql: "((0))"),
                    IDDESCRIPCION = table.Column<int>(name: "ID_DESCRIPCION", type: "int", nullable: true),
                    LARGO = table.Column<decimal>(type: "decimal(18,2)", nullable: true, defaultValueSql: "((0))"),
                    PERFIL = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MENSURABLES_DETALLE", x => x.IDCOMPONENTE);
                    table.ForeignKey(
                        name: "FK_MENSURABLES_DETALLE_COMPONENTES_DESCRIPCION_IdDescripcionNavigationIdDescripcion",
                        column: x => x.IdDescripcionNavigationIdDescripcion,
                        principalTable: "COMPONENTES_DESCRIPCION",
                        principalColumn: "ID_DESCRIPCION");
                    table.ForeignKey(
                        name: "FK_MENSURABLES_DETALLE_STOCK_MENSURABLES",
                        column: x => x.IDCOMPONENTE,
                        principalTable: "STOCK_MENSURABLES",
                        principalColumn: "ID_COMPONENTE");
                });

            migrationBuilder.CreateTable(
                name: "COMPONENTES_CUANTITATIVOS",
                columns: table => new
                {
                    IDPRODUCTO = table.Column<string>(name: "ID_PRODUCTO", type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IDCOMPONENTE = table.Column<string>(name: "ID_COMPONENTE", type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CANTIDAD = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPONENTES_CUANTITATIVOS", x => new { x.IDPRODUCTO, x.IDCOMPONENTE });
                    table.ForeignKey(
                        name: "FK_COMPONENTES_CUANTITATIVOS_CUANTITATIVOS_DETALLE",
                        column: x => x.IDCOMPONENTE,
                        principalTable: "CUANTITATIVOS_DETALLE",
                        principalColumn: "ID_COMPONENTE");
                    table.ForeignKey(
                        name: "FK_COMPONENTES_CUANTITATIVOS_PRODUCTOS_ID_PRODUCTO",
                        column: x => x.IDPRODUCTO,
                        principalTable: "PRODUCTOS",
                        principalColumn: "ID_PRODUCTO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_COMPONENTES_CUANTITATIVOS_STOCK_CUANTITATIVOS",
                        column: x => x.IDCOMPONENTE,
                        principalTable: "STOCK_CUANTITATIVOS",
                        principalColumn: "ID_COMPONENTE");
                });

            migrationBuilder.CreateTable(
                name: "COMPONENTES_PESABLES",
                columns: table => new
                {
                    IDPRODUCTO = table.Column<string>(name: "ID_PRODUCTO", type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IDCOMPONENTE = table.Column<string>(name: "ID_COMPONENTE", type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CANTIDAD = table.Column<decimal>(type: "decimal(18,2)", nullable: true, defaultValueSql: "NULL"),
                    PESO = table.Column<decimal>(type: "decimal(18,2)", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPONENTES_PESABLES", x => new { x.IDPRODUCTO, x.IDCOMPONENTE });
                    table.ForeignKey(
                        name: "FK_COMPONENTES_PESABLES_PESABLES_DETALLE1",
                        column: x => x.IDCOMPONENTE,
                        principalTable: "PESABLES_DETALLE",
                        principalColumn: "ID_COMPONENTE");
                    table.ForeignKey(
                        name: "FK_COMPONENTES_PESABLES_STOCK_PESABLES",
                        column: x => x.IDCOMPONENTE,
                        principalTable: "STOCK_PESABLES",
                        principalColumn: "ID_COMPONENTE");
                });

            migrationBuilder.CreateTable(
                name: "COMPONENTES_MENSURABLES",
                columns: table => new
                {
                    IDPRODUCTO = table.Column<string>(name: "ID_PRODUCTO", type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IDCOMPONENTE = table.Column<string>(name: "ID_COMPONENTE", type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ALTURA = table.Column<decimal>(type: "decimal(18,2)", nullable: true, defaultValueSql: "((0))"),
                    LARGO = table.Column<decimal>(type: "decimal(18,2)", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPONENTES_MENSURABLES", x => new { x.IDPRODUCTO, x.IDCOMPONENTE });
                    table.ForeignKey(
                        name: "FK_COMPONENTES_MENSURABLES_MENSURABLES_DETALLE",
                        column: x => x.IDCOMPONENTE,
                        principalTable: "MENSURABLES_DETALLE",
                        principalColumn: "ID_COMPONENTE");
                    table.ForeignKey(
                        name: "FK_COMPONENTES_MENSURABLES_STOCK_MENSURABLES",
                        column: x => x.IDCOMPONENTE,
                        principalTable: "STOCK_MENSURABLES",
                        principalColumn: "ID_COMPONENTE");
                });

            migrationBuilder.CreateIndex(
                name: "IX_COMPONENTES_CUANTITATIVOS_ID_COMPONENTE",
                table: "COMPONENTES_CUANTITATIVOS",
                column: "ID_COMPONENTE");

            migrationBuilder.CreateIndex(
                name: "IX_COMPONENTES_MENSURABLES_ID_COMPONENTE",
                table: "COMPONENTES_MENSURABLES",
                column: "ID_COMPONENTE");

            migrationBuilder.CreateIndex(
                name: "IX_COMPONENTES_PESABLES_ID_COMPONENTE",
                table: "COMPONENTES_PESABLES",
                column: "ID_COMPONENTE");

            migrationBuilder.CreateIndex(
                name: "IX_CUANTITATIVOS_DETALLE_IdDescripcionNavigationIdDescripcion",
                table: "CUANTITATIVOS_DETALLE",
                column: "IdDescripcionNavigationIdDescripcion");

            migrationBuilder.CreateIndex(
                name: "IX_MENSURABLES_DETALLE_IdDescripcionNavigationIdDescripcion",
                table: "MENSURABLES_DETALLE",
                column: "IdDescripcionNavigationIdDescripcion");

            migrationBuilder.CreateIndex(
                name: "IX_PESABLES_DETALLE_IdDescripcionNavigationIdDescripcion",
                table: "PESABLES_DETALLE",
                column: "IdDescripcionNavigationIdDescripcion");
        }
    }
}
