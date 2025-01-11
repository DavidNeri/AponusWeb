using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Aponus_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class ArchivosVentas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ARCHIVOS_VENTAS",
                columns: table => new
                {
                    ID_ARCHIVO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ID_VENTA = table.Column<int>(type: "int", nullable: false),
                    HASH_ARCHIVO = table.Column<string>(type: "text", nullable: false),
                    PATH_ARCHIVO = table.Column<string>(type: "text", nullable: false),
                    MIME_TYPE = table.Column<string>(type: "text", nullable: true),
                    ID_ESTADO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ARCHIVOS_VENTAS_ID_ARCHIVO", x => x.ID_ARCHIVO);
                    table.ForeignKey(
                        name: "FK_ARCHIVOS_VENTAS_VENTAS_ID_VENTA",
                        column: x => x.ID_VENTA,
                        principalTable: "VENTAS",
                        principalColumn: "ID_VENTA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ARCHIVOS_VENTAS_ID_ARCHIVO",
                table: "ARCHIVOS_VENTAS",
                column: "ID_ARCHIVO");

            migrationBuilder.CreateIndex(
                name: "IX_ARCHIVOS_VENTAS_ID_VENTA",
                table: "ARCHIVOS_VENTAS",
                column: "ID_VENTA");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ARCHIVOS_VENTAS");
        }
    }
} 
