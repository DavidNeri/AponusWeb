using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class removePK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                table: "STOCK_MOVIMIENTOS",
                name: "FK_STOCK_MOVIMIENTOS_ESTADOS_MOVIMIENTOS_STOCK_ID_ESTADO");

            migrationBuilder.DropPrimaryKey(
                table: "ESTADOS_MOVIMIENTOS_STOCK",
                name: "PK_ESTADOS_MOVIMIENTOS_STOCK");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
