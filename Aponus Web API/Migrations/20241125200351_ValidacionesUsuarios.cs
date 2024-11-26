using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aponus_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class ValidacionesUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(table: "USUARIOS",
                name: "SAL",
                type: "text",
                nullable: true);

            migrationBuilder.RenameColumn(name: "CONTRASEÑA",
                newName: "HASH_CONTRASEÑA",
                table: "USUARIOS");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
