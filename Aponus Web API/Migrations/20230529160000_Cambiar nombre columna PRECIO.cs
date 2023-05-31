using Microsoft.EntityFrameworkCore.Migrations;
using System.Data.SqlTypes;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class CambiarnombrecolumnaPRECIO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PRECIO",
                table: "PRODUCTOS",
                newName: "PRECIO_LISTA"

                );          


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PRECIO_LISTA",
                table: "PRODUCTOS",
                newName: "PRECIO"

                );

        }
    }
}
