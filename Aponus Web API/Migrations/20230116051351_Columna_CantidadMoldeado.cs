using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class ColumnaCantidadMoldeado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CANTIDAD_MOLDEADO",
                table: "STOCK_CUANTITATIVOS",
                newName: "CANTIDAD_MOLDEADO");

            migrationBuilder.AlterColumn<int>(
                name: "CantidadMoldeado",
                table: "STOCK_CUANTITATIVOS",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValueSql: "((0))");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CANTIDAD_MOLDEADO",
                table: "STOCK_CUANTITATIVOS",
                newName: "CantidadMoldeado");

            migrationBuilder.AlterColumn<int>(
                name: "CANTIDAD_MOLDEADO",
                table: "STOCK_CUANTITATIVOS",
                type: "int",
                nullable: true,
                defaultValueSql: "((0))",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
