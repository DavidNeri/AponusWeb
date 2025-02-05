using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aponus_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class FixVentaColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {       

            migrationBuilder.AddColumn<int>(
                name: "ID_VENTA1",
                table: "ARCHIVOS_VENTAS",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ID_VENTA1",
                table: "ARCHIVOS_VENTAS");

            migrationBuilder.AlterColumn<int>(
                name: "ID_VENTA",
                table: "ARCHIVOS_VENTAS",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
