using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class estadosMovimientosStockaddColumnidestadopropio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ID_ESTADO_PROPIO",
                table: "ESTADOS_MOVIMIENTOS_STOCK",
                type: "varbinary(1)",
                nullable: false,
                defaultValueSql: "1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ID_ESTADO_PROPIO",
                table: "ESTADOS_MOVIMIENTOS_STOCK");
        }
    }
}
