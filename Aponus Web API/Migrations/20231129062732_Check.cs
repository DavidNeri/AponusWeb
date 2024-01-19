using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Check : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.AddColumn<decimal>(
                name: "Diferencia",
                table: "Stock_Movimientos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);*/
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           /* migrationBuilder.DropColumn(
                name: "Diferencia",
                table: "Stock_Movimientos");*/
        }
    }
}
