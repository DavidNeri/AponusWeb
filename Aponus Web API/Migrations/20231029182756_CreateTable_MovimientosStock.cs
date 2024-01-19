using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableMovimientosStock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "STOCK_MOVIMIENTOS",
                columns: table => new
                {
                    IdMovimiento= table.Column<int>(name: "ID_MOVIMIENTO").Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdSuministro = table.Column<string>(name:"ID_SUMINISTRO", maxLength:50),
                    CampoStock = table.Column<string>(name:"CAMPO_STOCK", maxLength:50),
                    ValorAnterior = table.Column<decimal>(name:"VALOR_ANTERIOR", type:"decimal(18,2)"),
                    NuevoValor = table.Column<decimal>(name: "NUEVO_VALOR", type: "decimal(18,2)"),
                    IdUsuario= table.Column<string>(name: "ID_USUARIO", maxLength: 50),
                    FechaHora = table.Column<DateTime>(name:"FECHA_HORA")


                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STOCK_MOVIMIENTOS", x => x.IdMovimiento);

                });


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "STOCK_MOVIMIENTOS");
        }
    }
}
