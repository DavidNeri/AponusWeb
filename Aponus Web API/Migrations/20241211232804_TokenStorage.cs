﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aponus_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class TokenStorage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COMPRAS_USUARIOS_IDUSUARIO",
                table: "COMPRAS");

            migrationBuilder.AddForeignKey(
                name: "FK_COMPRAS_USUARIOS_IDUSUARIO",
                table: "COMPRAS",
                column: "ID_USUARIO",
                principalTable: "USUARIOS",
                principalColumn: "USUARIO",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COMPRAS_USUARIOS_IDUSUARIO",
                table: "COMPRAS");

            migrationBuilder.AddForeignKey(
                name: "FK_COMPRAS_USUARIOS_IDUSUARIO",
                table: "COMPRAS",
                column: "ID_USUARIO",
                principalTable: "USUARIOS",
                principalColumn: "USUARIO");
        }
    }
}
