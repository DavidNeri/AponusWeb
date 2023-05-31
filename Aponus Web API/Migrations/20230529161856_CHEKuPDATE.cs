using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class CHEKuPDATE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PRECIO_FINAL",
                table: "PRODUCTOS",
                newName: "PRECIO_FINAL");

            migrationBuilder.RenameColumn(
                name: "PORCENTAJE_GANANCIA",
                table: "PRODUCTOS",
                newName: "PORCENTAJE_GANANCIA");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PRECIO_FINAL",
                table: "PRODUCTOS",
                newName: "PrecioFinal");

            migrationBuilder.RenameColumn(
                name: "PORCENTAJE_GANANCIA",
                table: "PRODUCTOS",
                newName: "PorcentajeGanancia");
        }
    }
}
