using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class FK2PRODUCTOSTIPOSDESCRIPCION : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                   name: "FK_PRODUCTOSTIPOSDESCRIPCION_PRODUCTOSTIPOS_IDTIPO",
                   table: "PRODUCTOS_TIPOS_DESCRIPCION",
                   principalTable: "PRODUCTOS_TIPOS",
                   principalColumn: "ID_TIPO",
                   column: "ID_TIPO",
                   onUpdate: ReferentialAction.Cascade,
                   onDelete: ReferentialAction.Restrict
                    );


            migrationBuilder.AddForeignKey(
              name: "FK_PRODUCTOSTIPOSDESCRIPCION_PRODUCTOSDESCRIPCION_IDDESCRIPCION",
              table: "PRODUCTOS_TIPOS_DESCRIPCION",
              principalTable: "PRODUCTOS_DESCRIPCION",
              principalColumn: "ID_DESCRIPCION",
              column: "ID_DESCRIPCION",
              onUpdate: ReferentialAction.Cascade,
              onDelete: ReferentialAction.Restrict
               );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
