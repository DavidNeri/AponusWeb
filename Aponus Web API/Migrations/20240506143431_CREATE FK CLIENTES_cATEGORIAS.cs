using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class CREATEFKCLIENTEScATEGORIAS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PROVEEDORES_ID_CATEGORIA",
                table: "PROVEEDORES",
                column: "ID_CATEGORIA");

            migrationBuilder.AddForeignKey(
                name: "FK_PROVEEDORES_CLIENTES_CATEGORIAS_ID_CATEGORIA",
                table: "PROVEEDORES",
                column: "ID_CATEGORIA",
                principalTable: "CLIENTES_CATEGORIAS",
                principalColumn: "ID_CATEGORIA",
                onDelete: ReferentialAction.Cascade);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
               name: "FK_PROVEEDORES_CLIENTES_CATEGORIAS_IdCategoria",
               table: "PROVEEDORES");

            migrationBuilder.DropIndex(
                name: "IX_PROVEEDORES_IdCategoria",
                table: "PROVEEDORES");
        }
    }
}
