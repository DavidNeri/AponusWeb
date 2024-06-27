using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class CLIENTESPROVEDOORESIDENTIDAD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID_PROVEEDOR",
                table: "CLIENTES_PROVEEDORES",
                newName: "ID_ENTIDAD");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID_ENTIDAD",
                table: "CLIENTES_PROVEEDORES",
                newName: "ID_PROVEEDOR");
        }
    }
}
