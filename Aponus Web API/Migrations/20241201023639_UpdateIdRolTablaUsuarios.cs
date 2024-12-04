using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aponus_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIdRolTablaUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID_PERFIL",
                table: "USUARIOS",
                newName: "ID_ROL");

            migrationBuilder.RenameIndex(
                name: "IX_USUARIOS_ID_PERFIL",
                table: "USUARIOS",
                newName: "IX_USUARIOS_ID_ROL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID_ROL",
                table: "USUARIOS",
                newName: "ID_PERFIL");

            migrationBuilder.RenameIndex(
                name: "IX_USUARIOS_ID_ROL",
                table: "USUARIOS",
                newName: "IX_USUARIOS_ID_PERFIL");
        }
    }
}
