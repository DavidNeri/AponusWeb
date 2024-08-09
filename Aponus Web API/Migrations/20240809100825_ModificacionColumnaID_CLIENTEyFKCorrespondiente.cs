using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class ModificacionColumnaIDCLIENTEyFKCorrespondiente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
            name: "FK_VENTAS_ENTIDADES_ID_PROVEEDOR",
            table: "VENTAS");

            migrationBuilder.RenameColumn(
                name: "ID_PROVEEDOR",
                table: "VENTAS",
                newName: "ID_CLIENTE");

            migrationBuilder.RenameIndex(
                name: "IX_VENTAS_ID_PROVEEDOR",
                table: "VENTAS",
                newName: "IX_VENTAS_ID_CLIENTE");
                
            migrationBuilder.AddForeignKey(
                name: "FK_VENTAS_ENTIDADES_ID_CLIENTE",
                table: "VENTAS",
                column: "ID_CLIENTE",
                principalTable: "ENTIDADES",
                principalColumn: "ID_ENTIDAD");




        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
