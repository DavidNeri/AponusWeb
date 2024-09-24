using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class CorrecionesenDescripcionProductoyEntidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {          

    
            migrationBuilder.AlterColumn<string>(
                table: "ENTIDADES",
                name: "NOMBRE_CLAVE",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: false                
                );

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
