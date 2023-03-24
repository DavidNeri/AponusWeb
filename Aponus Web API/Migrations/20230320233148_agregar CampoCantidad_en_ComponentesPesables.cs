using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class agregarCampoCantidadenComponentesPesables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CANTIDAD",
                table: "COMPONENTES_PESABLES",
                type: "int",
                nullable: true,
                defaultValueSql:"NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CANTIDAD",
                table: "COMPONENTES_PESABLES");
        }
    }
}
