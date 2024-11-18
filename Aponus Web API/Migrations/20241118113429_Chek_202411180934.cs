using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aponus_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class Chek_202411180934 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ID_ESTADO",
                table: "ENTIDADES",
                type: "integer",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValueSql: "(1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ID_ESTADO",
                table: "ENTIDADES",
                type: "integer",
                nullable: false,
                defaultValueSql: "(1)",
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValueSql: "1");
        }
    }
}
