using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class EliminacionColumnasToleranciaMinimaToleranciaMaxima : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TOLERANCIA_MAXIMA",
                table: "PRODUCTOS");

            migrationBuilder.DropColumn(
                name: "TOLERANCIA_MINIMA",
                table: "PRODUCTOS");

            migrationBuilder.DropColumn(
                name: "TOLERANCIA_MAXIMA",
                table: "CUANTITATIVOS_DETALLE");

            migrationBuilder.DropColumn(
                name: "TOLERANCIA_MINIMA",
                table: "CUANTITATIVOS_DETALLE");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TOLERANCIA_MAXIMA",
                table: "PRODUCTOS",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TOLERANCIA_MINIMA",
                table: "PRODUCTOS",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TOLERANCIA_MAXIMA",
                table: "CUANTITATIVOS_DETALLE",
                type: "int",
                nullable: true,
                defaultValueSql: "((0))");

            migrationBuilder.AddColumn<int>(
                name: "TOLERANCIA_MINIMA",
                table: "CUANTITATIVOS_DETALLE",
                type: "int",
                nullable: true,
                defaultValueSql: "((0))");
        }
    }
}
