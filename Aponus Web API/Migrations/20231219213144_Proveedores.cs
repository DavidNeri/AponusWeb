using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Proveedores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ID_PROVEEDOR_ORIGEN",
                table: "STOCK_MOVIMIENTOS",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ID_PROVEEDOR_DESTINO",
                table: "STOCK_MOVIMIENTOS",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PROVEEDORES",
                columns: table => new
                {
                    IDPROVEEDOR = table.Column<int>(name: "ID_PROVEEDOR", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMBREPROVEEDOR = table.Column<string>(name: "NOMBRE_PROVEEDOR", type: "nvarchar(max)", nullable: false),
                    PAIS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LOCALIDAD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CALLE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ALTURA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CODIGOPOSTAL = table.Column<string>(name: "CODIGO_POSTAL", type: "nvarchar(max)", nullable: true),
                    TELEFONO1 = table.Column<string>(name: "TELEFONO_1", type: "nvarchar(max)", nullable: true),
                    TELEFONO2 = table.Column<string>(name: "TELEFONO_2", type: "nvarchar(max)", nullable: true),
                    TELEFONO3 = table.Column<string>(name: "TELEFONO_3", type: "nvarchar(max)", nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDFISCAL = table.Column<string>(name: "ID_FISCAL", type: "nvarchar(max)", nullable: false),
                    FECHAREGISTRO = table.Column<DateTime>(name: "FECHA_REGISTRO", type: "datetime2", nullable: false),
                    ESTADO = table.Column<bool>(type: "bit", nullable: false,defaultValueSql:"1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROVEEDORES", x => x.IDPROVEEDOR);
                });

            migrationBuilder.CreateIndex(
                name: "IX_STOCK_MOVIMIENTOS_ID_PROVEEDOR_ORIGEN",
                table: "STOCK_MOVIMIENTOS",
                column: "ID_PROVEEDOR_ORIGEN");

            migrationBuilder.CreateIndex(
                name: "IX_STOCK_MOVIMIENTOS_ID_PROVEEDOR_DESTINO",
                table: "STOCK_MOVIMIENTOS",
                column: "ID_PROVEEDOR_DESTINO");

            migrationBuilder.AddForeignKey(
                name: "FK_STOCK_MOVIMIENTOS_PROVEEDORES_ID_PROVEEDOR_ORIGEN",
                table: "STOCK_MOVIMIENTOS",
                column: "ID_PROVEEDOR_ORIGEN",
                principalTable: "PROVEEDORES",
                principalColumn: "ID_PROVEEDOR");

            migrationBuilder.AddForeignKey(
                name: "FK_STOCK_MOVIMIENTOS_PROVEEDORES_ID_PROVEEDOR_DESTINO",
                table: "STOCK_MOVIMIENTOS",
                column: "ID_PROVEEDOR_DESTINO",
                principalTable: "PROVEEDORES",
                principalColumn: "ID_PROVEEDOR");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_STOCK_MOVIMIENTOS_PROVEEDORES_ID_PROVEEDOR_ORIGEN",
                table: "STOCK_MOVIMIENTOS");

            migrationBuilder.DropForeignKey(
                name: "FK_STOCK_MOVIMIENTOS_PROVEEDORES_ID_PROVEEDOR_DESTINO",
                table: "STOCK_MOVIMIENTOS");

            migrationBuilder.DropTable(
                name: "PROVEEDORES");

            migrationBuilder.DropIndex(
                name: "IX_STOCK_MOVIMIENTOS_ID_PROVEEDOR_ORIGEN",
                table: "STOCK_MOVIMIENTOS");

            migrationBuilder.DropIndex(
                name: "IX_STOCK_MOVIMIENTOS_ID_PROVEEDOR_DESTINO",
                table: "STOCK_MOVIMIENTOS");

            migrationBuilder.DropColumn(
                name: "ID_PROVEEDOR_ORIGEN",
                table: "STOCK_MOVIMIENTOS");

            migrationBuilder.DropColumn(
                name: "ID_PROVEEDOR_DESTINO",
                table: "STOCK_MOVIMIENTOS");
        }
    }
}
