using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class agregarCampoCantidadenComponentesPesablesCONTEXT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cantidad",
                table: "COMPONENTES_PESABLES",
                newName: "CANTIDAD");

            migrationBuilder.AlterColumn<int>(
                name: "CANTIDAD",
                table: "COMPONENTES_PESABLES",
                type: "int",
                nullable: true,
                defaultValueSql: "NULL",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CANTIDAD",
                table: "COMPONENTES_PESABLES",
                newName: "Cantidad");

            migrationBuilder.AlterColumn<int>(
                name: "Cantidad",
                table: "COMPONENTES_PESABLES",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValueSql: "NULL");
        }
    }
}
