using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class TiposCLientesFk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
              name: "IX_PROVEEDORES_ID_TIPO",
              table: "PROVEEDORES",
              column: "ID_TIPO");


            migrationBuilder.AddForeignKey(
                name: "FK_PROVEEDORES_CLIENTES_TIPOS_ID_TIPO",
                table: "PROVEEDORES",
                column: "ID_TIPO",
                principalTable: "CLIENTES_TIPOS",
                principalColumn: "ID_TIPO",
                onDelete: ReferentialAction.Cascade,
                onUpdate: ReferentialAction.Cascade);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PROVEEDORES_CLIENTES_TIPOS_IdTipo",
                table: "PROVEEDORES");


            migrationBuilder.DropIndex(
                name: "IX_PROVEEDORES_IdTipo",
                table: "PROVEEDORES");
        }
    }
}
