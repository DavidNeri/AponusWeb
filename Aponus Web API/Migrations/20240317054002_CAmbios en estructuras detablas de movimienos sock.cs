using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class CAmbiosenestructurasdetablasdemovimienossock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ESTADOS_ARCHIVOS_MOVIMIENTOS_STOCK",
                columns: table => new
                {
                    IDESTADO = table.Column<byte[]>(name: "ID_ESTADO", type: "varbinary(1)", nullable: false),
                    DESCRIPCION = table.Column<string>(name:"DESCRIPCION",type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESTADOS_ARCHIVOS_MOVIMIENTOS_STOCK", x => x.IDESTADO);
                });

            migrationBuilder.Sql("INSERT INTO ESTADOS_ARCHIVOS_MOVIMIENTOS_STOCK (ID_ESTADO,DESCRIPCION) values " +
            "(0, 'ELIMINADO')," +
            "(1, 'ACTIVO')");

            migrationBuilder.CreateTable(
                name: "ESTADOS_MOVIMIENTOS_STOCK",
                columns: table => new
                {
                    IDESTADO = table.Column<byte[]>(name: "ID_ESTADO", type: "varbinary(1)", nullable: false),
                    DESCRIPCION = table.Column<string>(name:"DESCRIPCION",type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESTADOS_MOVIMIENTOS_STOCK", x => x.IDESTADO);
                });

            migrationBuilder.Sql("INSERT INTO ESTADOS_MOVIMIENTOS_STOCK (ID_ESTADO,DESCRIPCION) values " +
            "(0, 'ELIMINADO')," +
            "(1, 'CREADO')," +
            "(2, 'EN PROCESO')," +
            "(3, 'FINALIZADO')");

            migrationBuilder.CreateTable(
                name: "ESTADOS_SUMINISTROS_MOVIMIENTOS_STOCK",
                columns: table => new
                {
                    IDESTADO = table.Column<byte[]>(name: "ID_ESTADO", type: "varbinary(1)", nullable: false),
                    DESCRIPCION = table.Column<string>(name: "DESCRIPCION", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESTADOS_SUMINISTROS_MOVIMIENTOS_STOCK", x => x.IDESTADO);
                });

            migrationBuilder.Sql("INSERT INTO ESTADOS_SUMINISTROS_MOVIMIENTOS_STOCK (ID_ESTADO,DESCRIPCION) values " +
           "(0, 'ELIMINADO')," +
           "(1, 'ACTIVO')");

            migrationBuilder.CreateIndex(
                name: "IX_SUMINISTROS_MOVIMIENTOS_STOCK_ID_ESTADO",
                table: "SUMINISTROS_MOVIMIENTOS_STOCK",
                column: "ID_ESTADO");

            migrationBuilder.CreateIndex(
                name: "IX_STOCK_MOVIMIENTOS_ID_ESTADO",
                table: "STOCK_MOVIMIENTOS",
                column: "ID_ESTADO");

            migrationBuilder.CreateIndex(
                name: "IX_ARCHIVOS_STOCK_ID_ESTADO",
                table: "ARCHIVOS_STOCK",
                column: "ID_ESTADO");

            migrationBuilder.AddForeignKey(
                name: "FK_ARCHIVOS_STOCK_ESTADOS_ARCHIVOS_MOVIMIENTOS_STOCK_ID_ESTADO",
                table: "ARCHIVOS_STOCK",
                column: "ID_ESTADO",
                principalTable: "ESTADOS_ARCHIVOS_MOVIMIENTOS_STOCK",
                principalColumn: "ID_ESTADO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_STOCK_MOVIMIENTOS_ESTADOS_MOVIMIENTOS_STOCK_ID_ESTADO",
                table: "STOCK_MOVIMIENTOS",
                column: "ID_ESTADO",
                principalTable: "ESTADOS_MOVIMIENTOS_STOCK",
                principalColumn: "ID_ESTADO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SUMINISTROS_MOVIMIENTOS_STOCK_ESTADOS_SUMINISTROS_MOVIMIENTOS_STOCK_ID_ESTADO",
                table: "SUMINISTROS_MOVIMIENTOS_STOCK",
                column: "ID_ESTADO",
                principalTable: "ESTADOS_SUMINISTROS_MOVIMIENTOS_STOCK",
                principalColumn: "ID_ESTADO",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ARCHIVOS_STOCK_ESTADOS_ARCHIVOS_MOVIMIENTOS_STOCK_ID_ESTADO",
                table: "ARCHIVOS_STOCK");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Movimientos_ESTADOS_MOVIMIENTOS_STOCK_ID_ESTADO",
                table: "Stock_Movimientos");

            migrationBuilder.DropForeignKey(
                name: "FK_SUMINISTROS_MOVIMIENTOS_STOCK_ESTADOS_SUMINISTROS_MOVIMIENTOS_STOCK_ID_ESTADO",
                table: "SUMINISTROS_MOVIMIENTOS_STOCK");

            migrationBuilder.DropTable(
                name: "ESTADOS_ARCHIVOS_MOVIMIENTOS_STOCK");

            migrationBuilder.DropTable(
                name: "ESTADOS_MOVIMIENTOS_STOCK");

            migrationBuilder.DropTable(
                name: "ESTADOS_SUMINISTROS_MOVIMIENTOS_STOCK");

            migrationBuilder.DropIndex(
                name: "IX_SUMINISTROS_MOVIMIENTOS_STOCK_ID_ESTADO",
                table: "SUMINISTROS_MOVIMIENTOS_STOCK");

            migrationBuilder.DropIndex(
                name: "IX_Stock_Movimientos_ID_ESTADO",
                table: "Stock_Movimientos");

            migrationBuilder.DropIndex(
                name: "IX_ARCHIVOS_STOCK_ID_ESTADO",
                table: "ARCHIVOS_STOCK");
        }
    }
}
