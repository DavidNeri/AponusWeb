using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AgrearColumnasTablaProveedores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CIUDAD",
                table: "PROVEEDORES",
                type: "varchar(max)",
                nullable: true
                );

            migrationBuilder.AddColumn<string>(
                name: "PROVINCIA",
                table: "PROVEEDORES",
                type: "varchar(max)",
                nullable: true
                );

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                           name: "CIUDAD",
                           table: "PROVEEDORES"
                           );

            migrationBuilder.DropColumn(
                name: "PROVINCIA",
                table: "PROVEEDORES"
                );
        }
    }
}
