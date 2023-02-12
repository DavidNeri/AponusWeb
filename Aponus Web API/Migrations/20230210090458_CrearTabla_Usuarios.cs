using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class CrearTablaUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "USUARIOS",
                columns: table => new
                {
                    USUARIO = table.Column<string>(type: "varchar(50)", nullable: false),
                    CONTRASEÑA = table.Column<string>(type: "varchar(50)", nullable: false),
                    CORREO = table.Column<string>(type: "varchar(50)", nullable: false),
                    IDPERFIL = table.Column<int>(name: "ID_PERFIL", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.USUARIO);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "USUARIOS");
        }
    }
}
