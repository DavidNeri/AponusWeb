using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class columnaTIPO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TIPO",
                table: "STOCK_MOVIMIENTOS",
                type: "varchar(15)",
                nullable: true);

            migrationBuilder.Sql("UPDATE STOCK_MOVIMIENTOS SET TIPO='INTERNO'");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TIPO",
                table: "STOCK_MOVIMIENTOS");
        }
    }
}
