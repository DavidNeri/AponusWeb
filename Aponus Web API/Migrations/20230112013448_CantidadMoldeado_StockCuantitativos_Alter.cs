using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class CantidadMoldeadoStockCuantitativosAlter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(name: "CANTIDAD_MOLDEADO",
                table: "STOCK_CUANTITATIVOS",
                defaultValueSql: "((0))",
                defaultValue:"((0))",
                nullable:true
                );
            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
