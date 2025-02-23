using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aponus_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class RestablecerCoontraseña2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RESTABLECIDO",
                table: "USUARIOS");

            migrationBuilder.AddColumn<bool>(
                name: "CBIOCONTRASENA",
                table: "USUARIOS",
                type: "boolean",
                nullable: true,
                defaultValueSql: "true");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CBIOCONTRASENA",
                table: "USUARIOS");

            migrationBuilder.AddColumn<bool>(
                name: "RESTABLECIDO",
                table: "USUARIOS",
                type: "boolean",
                nullable: false,
                defaultValueSql: "true");
        }
    }
}
