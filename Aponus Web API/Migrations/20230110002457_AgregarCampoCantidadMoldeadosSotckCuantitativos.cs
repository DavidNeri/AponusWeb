using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCampoCantidadMoldeadosSotckCuantitativos : Migration
    {
        /// <inheritdoc />
        /// 

        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.RenameColumn(
                name: "CantidadMoldeado",
                table: "STOCK_CUANTITATIVOS",
                newName: "CANTIDAD_MOLDEADO");
            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
               name: "CantidadMoldeado",
               table: "STOCK_CUANTITATIVOS",
               newName: "CANTIDAD_MOLDEADO");
        }
    }
}
