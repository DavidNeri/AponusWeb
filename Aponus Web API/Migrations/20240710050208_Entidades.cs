using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Entidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            //Clientes_Proveedores
            migrationBuilder.DropForeignKey(
               name: "FK_STOCK_MOVIMIENTOS_CLIENTES_PROVEEDORES_ID_PROVEEDOR_DESTINO",
               table: "STOCK_MOVIMIENTOS");

            migrationBuilder.DropForeignKey(
               name: "FK_STOCK_MOVIMIENTOS_CLIENTES_PROVEEDORES_ID_PROVEEDOR_ORIGEN",
               table: "STOCK_MOVIMIENTOS");

            migrationBuilder.DropForeignKey(
              name: "FK_VENTAS_CLIENTES_PROVEEDORES_ID_PROVEEDOR",
              table: "VENTAS");           

            migrationBuilder.DropIndex(
                name: "IX_CLIENTES_PROVEEDORES_ID_CATEGORIA",
                table: "CLIENTES_PROVEEDORES");

            migrationBuilder.DropIndex(
                name: "IX_CLIENTES_PROVEEDORES_ID_TIPO",
                table: "CLIENTES_PROVEEDORES");

            migrationBuilder.DropIndex(
                name: "IX_CLIENTES_PROVEEDORES_ID_USUARIO_REGISTRO",
                table: "CLIENTES_PROVEEDORES");


            migrationBuilder.DropForeignKey(
                name: "FK_CLIENTES_PROVEEDORES_CLIENTES_CATEGORIAS_ID_CATEGORIA",
                table: "CLIENTES_PROVEEDORES");


            migrationBuilder.DropForeignKey(
               name: "FK_CLIENTES_PROVEEDORES_CLIENTES_TIPOS_ID_TIPO",
               table: "CLIENTES_PROVEEDORES");

            migrationBuilder.DropForeignKey(
               name: "FK_CLIENTES_PROVEEDORES_USUARIOS_ID_USUARIO_REGISTRO",
               table: "CLIENTES_PROVEEDORES");

            migrationBuilder.DropForeignKey(
               name: "FK_COMPRAS_CLIENTES_PROVEDORES_ID_PROVEEDOR",
               table: "COMPRAS");

            migrationBuilder.DropPrimaryKey(
            name: "PK_CLIENTES_PROVEEDORES",
            table: "CLIENTES_PROVEEDORES");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CLIENTES_CATEGORIAS",
                table: "CLIENTES_CATEGORIAS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CLIENTES_TIPOS",
                table: "CLIENTES_TIPOS");


            migrationBuilder.RenameTable(
               name: "CLIENTES_PROVEEDORES",
               newName: "ENTIDADES");

            migrationBuilder.RenameTable(
              name: "CLIENTES_CATEGORIAS",
              newName: "ENTIDADES_CATEGORIAS");

            migrationBuilder.RenameTable(
              name: "CLIENTES_TIPOS",
              newName: "ENTIDADES_TIPOS");

            migrationBuilder.AddPrimaryKey(
               name: "PK_ENTIDADES_CATEGORIAS",
               table: "ENTIDADES_CATEGORIAS",
               column: "ID_CATEGORIA");

            migrationBuilder.AddPrimaryKey(
             name: "PK_ENTIDADES",
             table: "ENTIDADES",
             column: "ID_ENTIDAD");

            migrationBuilder.AddPrimaryKey(
             name: "PK_ENTIDADES_TIPOS",
             table: "ENTIDADES_TIPOS",
             column: "ID_TIPO");

            migrationBuilder.CreateTable(
                name: "ENTIDADES_TIPOS_CATEGORIAS",
                columns: table => new
                {
                    IDTIPO = table.Column<int>(name: "ID_TIPO", type: "int", nullable: false),
                    IDCATEGORIA = table.Column<int>(name: "ID_CATEGORIA", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENTIDADES_TIPOS_CATEGORIAS", x => new { x.IDTIPO, x.IDCATEGORIA });
                    table.ForeignKey(
                        name: "FK_ENTIDADES_TIPOS_CATEGORIAS_ENTIDADES_CATEGORIAS_ID_CATEGORIA",
                        column: x => x.IDCATEGORIA,
                        principalTable: "ENTIDADES_CATEGORIAS",
                        principalColumn: "ID_CATEGORIA",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ENTIDADES_TIPOS_CATEGORIAS_ENTIDADES_TIPOS_ID_TIPO",
                        column: x => x.IDTIPO,
                        principalTable: "ENTIDADES_TIPOS",
                        principalColumn: "ID_TIPO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ENTIDADES_TIPOS_CATEGORIAS_ID_CATEGORIA",
                table: "ENTIDADES_TIPOS_CATEGORIAS",
                column: "ID_CATEGORIA");

            //Agregar nuevamente

            migrationBuilder.CreateIndex(
                name: "IX_ENTIDADES_ID_CATEGORIA",
                table: "ENTIDADES",
                column:"ID_CATEGORIA");

            migrationBuilder.CreateIndex(
                name: "IX_ENTIDADES_ID_TIPO",
                table: "ENTIDADES",
                column:"ID_TIPO");

            migrationBuilder.CreateIndex(
                name: "IX_ENTIDADES_ID_USUARIO_REGISTRO",
                table: "ENTIDADES",
                column: "ID_USUARIO_REGISTRO");


            migrationBuilder.AddForeignKey(
                name: "FK_ENTIDADES_ENTIDADES_CATEGORIAS_ID_CATEGORIA",
                table: "ENTIDADES",
                column: "ID_CATEGORIA",
                principalColumn: "ID_CATEGORIA",
                principalTable: "ENTIDADES_CATEGORIAS",
                onDelete: ReferentialAction.Cascade);


            migrationBuilder.AddForeignKey(
               name: "FK_ENTIDADES_ENTIDADES_TIPOS_ID_TIPO",
               table: "ENTIDADES",
               column: "ID_TIPO",
               principalTable: "ENTIDADES_TIPOS",
               principalColumn: "ID_TIPO",
               onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
               name: "FK_ENTIDADES_USUARIOS_ID_USUARIO_REGISTRO",
               table: "ENTIDADES",
               principalTable:"USUARIOS",
               principalColumn:"USUARIO",
               column:"ID_USUARIO_REGISTRO", onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
               name: "FK_COMPRAS_ENTIDADES_ID_PROVEEDOR",
               table: "COMPRAS",
               column:"ID_PROVEEDOR",
               principalTable:"ENTIDADES",
               principalColumn:"ID_ENTIDAD",
               onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
               name: "FK_STOCK_MOVIMIENTOS_ENTIDADES_ID_PROVEEDOR_DESTINO",
               table: "STOCK_MOVIMIENTOS",
               column: "ID_PROVEEDOR_DESTINO",
               principalColumn:"ID_ENTIDAD",
               principalTable:"ENTIDADES",
               onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
               name: "FK_STOCK_MOVIMIENTOS_ENTIDADES_ID_PROVEEDOR_ORIGEN",
               table: "STOCK_MOVIMIENTOS",
               column: "ID_PROVEEDOR_ORIGEN",
               principalColumn: "ID_ENTIDAD",
               principalTable: "ENTIDADES",
               onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
               name: "FK_VENTAS_ENTIDADES_ID_PROVEEDOR",
               table: "VENTAS",
               column:"ID_PROVEEDOR",
               principalTable:"ENTIDADES",
               principalColumn:"ID_ENTIDAD",
               onDelete: ReferentialAction.NoAction);      
            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
