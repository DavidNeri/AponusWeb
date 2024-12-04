using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aponus_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class CreacionTablasRolesUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_USUARIOS_PERFILES_USUARIOS_ID_PERFIL",
                table: "USUARIOS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_USUARIOS_PERFILES",
                table: "USUARIOS_PERFILES");

            migrationBuilder.DropColumn(
                name: "ID_ESTADO",
                table: "USUARIOS_PERFILES");

            migrationBuilder.RenameTable(
                name: "USUARIOS_PERFILES",
                newName: "USUARIOS_ROLES");

            migrationBuilder.RenameColumn(
                name: "ID_PERFIL",
                table: "USUARIOS_ROLES",
                newName: "ID_ROL");

            migrationBuilder.AlterColumn<string>(
                name: "SAL",
                table: "USUARIOS",
                oldNullable: true,
                nullable : false);

            migrationBuilder.AddColumn<string>(
                name: "NOMBRE_ROL",
                table: "USUARIOS_ROLES",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_USUARIOS_ROLES",
                table: "USUARIOS_ROLES",
                column: "ID_ROL");

            migrationBuilder.AddForeignKey(
                name: "FK_USUARIOS_ROLES_USUARIOS_ID_ROL",
                table: "USUARIOS",
                column: "ID_PERFIL",
                principalTable: "USUARIOS_ROLES",
                principalColumn: "ID_ROL",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_USUARIOS_ROLES_USUARIOS_ID_ROL",
                table: "USUARIOS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_USUARIOS_ROLES",
                table: "USUARIOS_ROLES");

            migrationBuilder.DropColumn(
                name: "SAL",
                table: "USUARIOS");

            migrationBuilder.DropColumn(
                name: "NOMBRE_ROL",
                table: "USUARIOS_ROLES");

            migrationBuilder.RenameTable(
                name: "USUARIOS_ROLES",
                newName: "USUARIOS_PERFILES");

            migrationBuilder.RenameColumn(
                name: "HASH_CONTRASEÑA",
                table: "USUARIOS",
                newName: "CONTRASEÑA");

            migrationBuilder.RenameColumn(
                name: "ID_ROL",
                table: "USUARIOS_PERFILES",
                newName: "ID_PERFIL");

            migrationBuilder.AddColumn<int>(
                name: "ID_ESTADO",
                table: "USUARIOS_PERFILES",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_USUARIOS_PERFILES",
                table: "USUARIOS_PERFILES",
                column: "ID_PERFIL");

            migrationBuilder.AddForeignKey(
                name: "FK_USUARIOS_PERFILES_USUARIOS_ID_PERFIL",
                table: "USUARIOS",
                column: "ID_PERFIL",
                principalTable: "USUARIOS_PERFILES",
                principalColumn: "ID_PERFIL",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
