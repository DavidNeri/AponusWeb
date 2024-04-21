using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class IdEstadoentablasdemovimimientos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ID_ESTADO",
                table: "SUMINISTROS_MOVIMIENTOS_STOCK",
                type: "Varbinary(1)",
                nullable: false,
                defaultValueSql: "1");

            migrationBuilder.AddColumn<byte[]>(
                name: "ID_ESTADO",
                table: "Stock_Movimientos",
                type: "Varbinary(1)",
                nullable: false,
                defaultValueSql: "1");

            migrationBuilder.AddColumn<byte[]>(
                name: "ID_ESTADO",
                table: "ARCHIVOS_STOCK",
                type: "Varbinary(1)",
                nullable: false,
                defaultValueSql: "1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ID_ESTADO",
                table: "SUMINISTROS_MOVIMIENTOS_STOCK");

            migrationBuilder.DropColumn(
                name: "ID_ESTADO",
                table: "Stock_Movimientos");

            migrationBuilder.DropColumn(
                name: "ID_ESTADO",
                table: "ARCHIVOS_STOCK");
        }
    }
}
