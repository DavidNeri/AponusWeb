using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class CambioTipocolestadotablaProveedores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "ESTADO",
                table: "PROVEEDORES",
                type: "varbinary(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
                migrationBuilder.AlterColumn<bool>(
                name: "ESTADO",
                table: "PROVEEDORES",
                type: "bit",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(1)");
        }
    }
}
