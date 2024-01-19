using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class FKARCIVOSSTOCKSTOCKMOVIMIENTOSIDMOVIMIETO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(name: "CAMPO_STOCK",
                table: "ARCHIVOS_STOCK",
                oldType: "varchar(50)",
                type: "nvarchar(50)",
                maxLength: 50
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
