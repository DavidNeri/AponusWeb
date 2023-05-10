using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class CREARTABLADETALLECOMPONENTES : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "COMPONENTES_DETALLE",
                columns: table => new
                {
                    IDINSUMO = table.Column<string>(name: "ID_INSUMO", type: "varchar(50)", nullable: false),
                    IDDESCRIPCION = table.Column<int>(name: "ID_DESCRIPCION", type: "int", nullable: false),
                    DIAMETRO = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    ESPESOR = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    LONGITUD = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    ALTURA = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    PERFIL = table.Column<int>(type: "int", nullable: true),
                    TOLERANCIA = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ID_INSUMO", x => x.IDINSUMO);
                });

          
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.DropTable(
                name: "COMPONENTES_DETALLE");

           
        }
    }
}
