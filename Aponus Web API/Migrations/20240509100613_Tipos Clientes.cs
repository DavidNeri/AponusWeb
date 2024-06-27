using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class TiposClientes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "CLIENTES_TIPOS",
                columns: table => new
                {
                    IDTIPO = table.Column<int>(name: "ID_TIPO", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMBRE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDESTADO = table.Column<byte[]>(name: "ID_ESTADO", type: "varbinary(1)", nullable: false, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTES_TIPOS", x => x.IDTIPO);
                });


            migrationBuilder.AddColumn<int>(
                name: "ID_TIPO",
                table: "PROVEEDORES",
                type: "int",
                nullable: false,
                defaultValue: 0);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {           

            migrationBuilder.DropTable(
                name: "CLIENTES_TIPOS");

            migrationBuilder.DropColumn(
                name: "ID_TIPO",
                table: "PROVEEDORES");

        }
    }
}
