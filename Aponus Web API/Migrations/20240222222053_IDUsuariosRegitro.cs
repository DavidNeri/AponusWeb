using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class IDUsuariosRegitro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ID_USUARIO_REGISTRO",
                table: "PROVEEDORES",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_PROVEEDORES_ID_USUARIO_REGISTRO",
                table: "PROVEEDORES",
                column: "ID_USUARIO_REGISTRO");

            migrationBuilder.AddForeignKey(
                name: "FK_PROVEEDORES_Usuarios_ID_USUARIO_REGISTRO",
                table: "PROVEEDORES",
                column: "ID_USUARIO_REGISTRO",
                principalTable: "Usuarios",
                principalColumn: "USUARIO",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PROVEEDORES_Usuarios_ID_USUARIO_REGISTRO",
                table: "PROVEEDORES");

            migrationBuilder.DropIndex(
                name: "IX_PROVEEDORES_ID_USUARIO_REGISTRO",
                table: "PROVEEDORES");

            migrationBuilder.DropColumn(
                name: "ID_USUARIO_REGISTRO",
                table: "PROVEEDORES");
        }
    }
}
