using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aponus_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class IdEstado_CompnentesDescripcion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {          

            migrationBuilder.AddColumn<int>(
                name: "ID_ESTADO",
                table: "COMPONENTES_DESCRIPCION",
                type: "int",
                nullable: false,
                defaultValueSql: "1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ID_ESTADO",
                table: "COMPONENTES_DESCRIPCION");

            migrationBuilder.AddColumn<int>(
                name: "ID_VENTA1",
                table: "ARCHIVOS_VENTAS",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
