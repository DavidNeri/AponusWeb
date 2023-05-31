using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Cambiarnombrecolumna : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DIAMETRO_NOMINAL",
                table: "COMPONENTES_DETALLE",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int?",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DIAMETRO_NOMINAL",
                table: "COMPONENTES_DETALLE",
                type: "int?",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
