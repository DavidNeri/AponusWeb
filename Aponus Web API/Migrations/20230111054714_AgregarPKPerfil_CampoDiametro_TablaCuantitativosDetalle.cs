using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AgregarPKPerfilCampoDiametroTablaCuantitativosDetalle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Perfil",
                table: "CUANTITATIVOS_DETALLE",
                newName: "PERFIL");

            migrationBuilder.RenameColumn(
                name: "Espesor",
                table: "CUANTITATIVOS_DETALLE",
                newName: "ESPESOR");

            migrationBuilder.AlterColumn<int>(
                name: "PERFIL",
                table: "CUANTITATIVOS_DETALLE",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ESPESOR",
                table: "CUANTITATIVOS_DETALLE",
                type: "decimal(18,2)",
                nullable: true,
                defaultValueSql: "((0))",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PERFIL",
                table: "CUANTITATIVOS_DETALLE",
                newName: "Perfil");

            migrationBuilder.RenameColumn(
                name: "ESPESOR",
                table: "CUANTITATIVOS_DETALLE",
                newName: "Espesor");

            migrationBuilder.AlterColumn<int>(
                name: "Perfil",
                table: "CUANTITATIVOS_DETALLE",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Espesor",
                table: "CUANTITATIVOS_DETALLE",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true,
                oldDefaultValueSql: "((0))");
        }
    }
}
