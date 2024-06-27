using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class ADDTABLECLIENTESCATEGORIASADDFKCATEGORIACLIENTETABLECLIENTES : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ID_CATEGORIA",
                table: "PROVEEDORES",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CLIENTES_CATEGORIAS",
                columns: table => new
                {
                    IDCATEGORIA = table.Column<int>(name: "ID_CATEGORIA", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMBRE = table.Column<string>(name:"NOMBRE_CATEGORIA", type: "nvarchar(max)", nullable: false),
                    IDESTADO = table.Column<byte>(name: "ID_ESTADO", type: "varbinary(1)", nullable: false, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTES_CATEGORIAS", x => x.IDCATEGORIA);
                });

           

            migrationBuilder.Sql("INSERT INTO CLIENTES_CATEGORIAS (NOMBRE_CATEGORIA) VALUES('PYMES')");

            migrationBuilder.Sql("UPDATE PROVEEDORES SET ID_CATEGORIA=1");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
         

            migrationBuilder.DropTable(
                name: "CLIENTES_CATEGORIAS");

         

            migrationBuilder.DropColumn(
                name: "IdCategoria",
                table: "PROVEEDORES");
        }
    }
}
