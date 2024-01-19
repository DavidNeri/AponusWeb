using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class PKSTOCKMOVIMIENTOS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ARCHIVOS_STOCK_STOCK_MOVIMIENTOS_ID_MOVIMIENTO",
                table: "ARCHIVOS_STOCK");

            migrationBuilder.DropPrimaryKey(
                name: "PK_STOCK_MOVIMIENTOS",
                table: "STOCK_MOVIMIENTOS");

            migrationBuilder.AlterColumn<string>(
                name: "HASH_ARCHIVO",
                table: "ARCHIVOS_STOCK",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(MAX)");

            migrationBuilder.AddUniqueConstraint(
                name: "PK_STOCK_MOVIMINETOS_ID_MOVIMIENTO",
                table: "STOCK_MOVIMIENTOS",
                column: "ID_MOVIMIENTO");

            migrationBuilder.AddPrimaryKey(
                name: "PK_STOCK_MOVIMIENTOS",
                table: "STOCK_MOVIMIENTOS",
                columns: new[] { "ID_MOVIMIENTO", "CAMPO_STOCK" });

            migrationBuilder.AddForeignKey(
                name: "FK_ARCHIVOS_STOCK_STOCK_MOVIMIENTOS_ID_MOVIMIENTO",
                table: "ARCHIVOS_STOCK",
                column: "ID_MOVIMIENTO",
                principalTable: "STOCK_MOVIMIENTOS",
                principalColumn: "ID_MOVIMIENTO"
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "PK_STOCK_MOVIMINETOS_ID_MOVIMIENTO",
                table: "STOCK_MOVIMIENTOS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_STOCK_MOVIMIENTOS",
                table: "STOCK_MOVIMIENTOS");

            migrationBuilder.AlterColumn<string>(
                name: "HASH_ARCHIVO",
                table: "ARCHIVOS_STOCK",
                type: "varchar(MAX)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_STOCK_MOVIMIENTOS",
                table: "STOCK_MOVIMIENTOS",
                column: "ID_MOVIMIENTO");
        }
    }
}
