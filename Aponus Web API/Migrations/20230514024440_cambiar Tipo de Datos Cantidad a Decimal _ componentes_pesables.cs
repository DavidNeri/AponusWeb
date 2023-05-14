using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class cambiarTipodeDatosCantidadaDecimalcomponentespesables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "CANTIDAD",
                table: "COMPONENTES_PESABLES",
                type: "decimal(18,2)",
                nullable: true,
                defaultValueSql: "NULL",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValueSql: "NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CANTIDAD",
                table: "COMPONENTES_PESABLES",
                type: "int",
                nullable: true,
                defaultValueSql: "NULL",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true,
                oldDefaultValueSql: "NULL");
        }
    }
}
