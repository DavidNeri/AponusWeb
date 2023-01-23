using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class ModificacionCampoPERFILTablaCuantitativosDetalle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.AlterColumn<int>(
                name: "PERFIL",
                table: "CUANTITATIVOS_DETALLE",
                type: "int",
                nullable: true,
                defaultValueSql: "null",
                oldClrType: typeof(int),
                oldType: "int");
            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.AlterColumn<int>(
                name: "PERFIL",
                table: "CUANTITATIVOS_DETALLE",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValueSql: "null");

            
        }
    }
}
