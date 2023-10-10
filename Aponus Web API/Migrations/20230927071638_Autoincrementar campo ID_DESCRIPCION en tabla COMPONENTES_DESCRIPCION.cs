using Microsoft.EntityFrameworkCore.Migrations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AutoincrementarcampoIDDESCRIPCIONentablaCOMPONENTESDESCRIPCION : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(name: "ID_DESCRIPCION",
                table: "COMPONENTES_DESCRIPCION",
                defaultValue: null,
                defaultValueSql: "((-1))"
                );

           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
