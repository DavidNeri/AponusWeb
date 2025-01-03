﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aponus_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class PERFILESUSUARIOS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_ID_PERFIL",
                table: "USUARIOS",
                column: "ID_PERFIL");


            migrationBuilder.AddForeignKey(
                name: "FK_USUARIOS_PERFILES_USUARIOS_ID_PERFIL",
                table: "USUARIOS",
                column: "ID_PERFIL",
                principalTable: "USUARIOS_PERFILES",
                principalColumn: "ID_PERFIL",
                onDelete: ReferentialAction.Cascade);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
