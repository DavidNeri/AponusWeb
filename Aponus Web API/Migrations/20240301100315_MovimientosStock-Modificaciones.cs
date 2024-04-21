using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class MovimientosStockModificaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID_USUARIO",
                table: "STOCK_MOVIMIENTOS",
                newName: "USUARIO_CREADO");

            migrationBuilder.RenameColumn(
                name: "FECHA_HORA",
                table: "STOCK_MOVIMIENTOS",
                newName: "FECHA_HORA_CREADO");
           

            migrationBuilder.AddColumn<DateTime>(
                name: "FECHA_HORA_ULTIMA_MODIFICACION",
                table: "STOCK_MOVIMIENTOS",
                type: "datetime2(7)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "USUARIO_MODIFICA",
                table: "STOCK_MOVIMIENTOS",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FECHA_HORA_ULTIMA_MODIFICACION",
                table: "STOCK_MOVIMIENTOS");

            migrationBuilder.DropColumn(
                name: "USUARIO_MODIFICA",
                table: "STOCK_MOVIMIENTOS");

            migrationBuilder.RenameColumn(
                name: "USUARIO_CREADO",
                table: "STOCK_MOVIMIENTOS",
                newName: "ID_USUARIO");

            migrationBuilder.RenameColumn(
                name: "FECHA_HORA_CREADO",
                table: "STOCK_MOVIMIENTOS",
                newName: "FECHA_HORA");
         
        }
    }
}
