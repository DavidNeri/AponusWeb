using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class CantidadMoldeadoStockCuantitativosAgregar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CANTIDAD_MOLDEADO",
                table: "STOCK_CUANTITATIVOS",
                type: "int",
                nullable: true,
                defaultValue:"0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CANTIDAD_MOLDEADO",
                table: "STOCK_CUANTITATIVOS");
        }
    }
}
