using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Aponus_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class Auditorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AUDITORIAS",
                columns: table => new
                {
                    IdAuditoria = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TABLA = table.Column<string>(type: "text", nullable: false),
                    ID_REGISTRO = table.Column<string>(type: "text", nullable: false),
                    ACCION = table.Column<string>(type: "text", nullable: false),
                    USUARIO = table.Column<string>(type: "text", nullable: true),
                    FECHA = table.Column<DateTime>(type: "timestamp", nullable: false),
                    VALORES_PREVIOS = table.Column<string>(type: "text", nullable: true),
                    VALORES_NUEVOS = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUDITORIAS", x => x.IdAuditoria);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AUDITORIAS");
        }
    }
}
