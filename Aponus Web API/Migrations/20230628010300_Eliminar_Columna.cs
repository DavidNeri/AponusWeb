using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class EliminarColumna : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                table: "COMPONENTES_DETALLE",
                name: "TIPO_ALMACENAMIENTO");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
               name: "TIPO_ALMACENAMIENTO",
               table: "COMPONENTES_DETALLE",
               type: "decimal(18,2)",
               nullable: true

               );
        }
    }
}
