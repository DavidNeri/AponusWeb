using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class CambioTipoValorCantidadTablaComponentesCuantitativos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CANTIDAD",
                table: "COMPONENTES_CUANTITATIVOS",
                type: "int",
                nullable: false,
                defaultValueSql: "((0))",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "CANTIDAD",
                table: "COMPONENTES_CUANTITATIVOS",
                type: "decimal(18,1)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "((0))");
        }
    }
}
