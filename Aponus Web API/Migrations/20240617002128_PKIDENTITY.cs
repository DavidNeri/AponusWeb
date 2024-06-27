using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class PKIDENTITY : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MEDIOS_PAGO",
                table: "MEDIOS_PAGO");

            ///quitar columna ID_MEDIO_PAGO y crear nuevamente 
            ///
            migrationBuilder.DropColumn(
                name: "ID_MEDIO_PAGO",
                table: "MEDIOS_PAGO");

            migrationBuilder.AddColumn<int>(
                name: "ID_MEDIO_PAGO",
                table: "MEDIOS_PAGO",
                nullable: false)
                .Annotation("SqlServeridentity", "1,1");


            migrationBuilder.AddPrimaryKey(
               name: "PK_MEDIOS_PAGO",
               table: "MEDIOS_PAGO",
               column: "ID_MEDIO_PAGO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
