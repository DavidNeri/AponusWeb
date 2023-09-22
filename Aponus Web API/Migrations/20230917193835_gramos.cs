using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class gramos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID_FRACCIONAMIENTO",
                table: "COMPONENTES_DETALLE",
                newName: "ID_FRACCIONAMIENTO");

            migrationBuilder.RenameColumn(
                name: "ID_ALMACENAMIENTO",
                table: "COMPONENTES_DETALLE",
                newName: "ID_ALMACENAMIENTO");

            migrationBuilder.AlterColumn<decimal>(
                name: "PESO",
                table: "COMPONENTES_DETALLE",
                type: "decimal(18,3)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ID_ALMACENAMIENTO",
                table: "COMPONENTES_DETALLE",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID_FRACCIONAMIENTO",
                table: "COMPONENTES_DETALLE",
                newName: "IdFraccionamiento");

            migrationBuilder.RenameColumn(
                name: "ID_ALMACENAMIENTO",
                table: "COMPONENTES_DETALLE",
                newName: "IdAlmacenamiento");

            migrationBuilder.AlterColumn<decimal>(
                name: "PESO",
                table: "COMPONENTES_DETALLE",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,3)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdAlmacenamiento",
                table: "COMPONENTES_DETALLE",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);
        }
    }
}
