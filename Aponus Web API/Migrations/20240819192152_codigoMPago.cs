using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class codigoMPago : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CODIGO_MPAGO",
                table: "MEDIOS_PAGO",
                type:"nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
