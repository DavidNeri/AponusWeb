using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AgrarColumnaToleranciaenTablasCorrepsondientes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TOLERANCIA",
                table: "PRODUCTOS",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TOLERANCIA",
                table: "CUANTITATIVOS_DETALLE",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TOLERANCIA",
                table: "PRODUCTOS");

            migrationBuilder.DropColumn(
                name: "TOLERANCIA",
                table: "CUANTITATIVOS_DETALLE");
        }
    }
}
