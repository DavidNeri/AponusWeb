using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ESTADO",
                table: "PROVEEDORES");

            migrationBuilder.AddColumn<byte[]>(
                name: "ID_ESTADO",
                table: "PROVEEDORES",
                type: "varbinary(1)",
                nullable: false,
                defaultValueSql: "(1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ID_ESTADO",
                table: "PROVEEDORES");

            migrationBuilder.AddColumn<byte[]>(
                name: "ESTADO",
                table: "PROVEEDORES",
                type: "varbinary(1)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
