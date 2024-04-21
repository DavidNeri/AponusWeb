using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class CREATEPK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
               table: "ESTADOS_MOVIMIENTOS_STOCK",
               name: "PK_ESTADOS_MOVIMIENTOS_STOCK",
               column: "ID_ESTADO")
                .Annotation("SqlServer:Identity", "1, 1");
               

            migrationBuilder.AddForeignKey(
                table: "STOCK_MOVIMIENTOS",
                name: "FK_STOCK_MOVIMIENTOS_ESTADOS_MOVIMIENTOS_STOCK_ID_ESTADO",
                principalTable: "ESTADOS_MOVIMIENTOS_STOCK",
                principalColumn:"ID_ESTADO",
                column:"ID_ESTADO");

           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
