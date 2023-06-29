using Microsoft.EntityFrameworkCore.Migrations;
using System.Security.Principal;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AgregarColumnaTIPOALMANCENAMIENTOtablaCOMPONENTESDETALLE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TIPO_ALMACENAMIENTO",
                table: "COMPONENTES_DETALLE",
                type: "decimal(18,2)",
                nullable: true

                );

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
               name: "TIPO_ALMACENAMIENTO",
               table: "COMPONENTES_DETALLE"
                );
        }
    }
}
