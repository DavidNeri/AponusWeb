using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Aponus_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class CorrecionesenMovimientos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_COMPRAS_ESTADOS_COMPRAS_ID_ESTADO_COMPRA",
            //    table: "COMPRAS");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_STOCK_MOVIMIENTOS_ESTADOS_MOVIMIENTOS_STOCK_ID_ESTADO",
            //    table: "STOCK_MOVIMIENTOS");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_SUMINISTROS_MOVIMIENTOS_STOCK_ESTADOS_SUMINISTROS_MOVIMIENT~",
            //    table: "SUMINISTROS_MOVIMIENTOS_STOCK");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_ESTADOS_MOVIMIENTOS_STOCK",
            //    table: "ESTADOS_MOVIMIENTOS_STOCK");

            //migrationBuilder.DropIndex(
            //    name: "IX_COMPRAS_ID_ESTADO_COMPRA",
            //    table: "COMPRAS");

            migrationBuilder.DropColumn(
                name: "VALOR_ANTERIOR_DESTINO",
                table: "SUMINISTROS_MOVIMIENTOS_STOCK");

            migrationBuilder.DropColumn(
                name: "VALOR_ANTERIOR_ORIGEN",
                table: "SUMINISTROS_MOVIMIENTOS_STOCK");

            migrationBuilder.DropColumn(
                name: "VALOR_NUEVO_DESTINO",
                table: "SUMINISTROS_MOVIMIENTOS_STOCK");

            migrationBuilder.DropColumn(
                name: "VALOR_NUEVO_ORIGEN",
                table: "SUMINISTROS_MOVIMIENTOS_STOCK");

            //migrationBuilder.RenameColumn(
            //    name: "ID_ESTADO",
            //    table: "STOCK_MOVIMIENTOS",
            //    newName: "ID_ESTADO_MOVIMIENTO");

            migrationBuilder.CreateIndex(
               table: "STOCK_MOVIMIENTOS",
               name: "IX_STOCK_MOVIMIENTOS_ID_ESTADO_MOVIMIENTO",
               column: "ID_ESTADO_MOVIMIENTO");

            //migrationBuilder.AlterColumn<string>(
            //    name: "ID_SUMINISTRO",
            //    table: "SUMINISTROS_MOVIMIENTOS_STOCK",
            //    type: "varchar(50)",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(50)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "USUARIO_MODIFICA",
            //    table: "STOCK_MOVIMIENTOS",
            //    type: "varchar(50)",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(50)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "USUARIO_CREADO",
            //    table: "STOCK_MOVIMIENTOS",
            //    type: "varchar(50)",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(50)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "ID_TIPO",
            //    table: "PRODUCTOS_TIPOS_DESCRIPCION",
            //    type: "varchar(50)",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "character varying(50)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "DESCRIPCION",
            //    table: "MEDIOS_PAGO",
            //    type: "text",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "CODIGO_MPAGO",
            //    table: "MEDIOS_PAGO",
            //    type: "text",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "DESCRIPCION",
            //    table: "ESTADOS_VENTAS",
            //    type: "text",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "DESCRIPCION",
            //    table: "ESTADOS_SUMINISTROS_MOVIMIENTOS_STOCK",
            //    type: "text",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "DESCRIPCION",
            //    table: "ESTADOS_PRODUCTOS_TIPOS",
            //    type: "text",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "DESCRIPCION",
            //    table: "ESTADOS_PRODUCTOS_DESCRIPCIONES",
            //    type: "text",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "DESCRIPCION",
            //    table: "ESTADOS_PRODUCTOS_COMPONENTES",
            //    type: "text",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "DESCRIPCION",
            //    table: "ESTADOS_PRODUCTOS",
            //    type: "text",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "DESCRIPCION",
            //    table: "ESTADOS_MOVIMIENTOS_STOCK",
            //    type: "text",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.AlterColumn<int>(
            //    name: "ID_ESTADO",
            //    table: "ESTADOS_MOVIMIENTOS_STOCK",
            //    type: "integer",
            //    nullable: false,
            //    defaultValueSql: "1",
            //    oldClrType: typeof(int),
            //    oldType: "integer",
            //    oldDefaultValueSql: "1")
            //    .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            //migrationBuilder.AddColumn<int>(
            //    name: "ID_ESTADO_MOVIMIENTO",
            //    table: "ESTADOS_MOVIMIENTOS_STOCK",
            //    type: "int",
            //    nullable: false)
            //    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            //migrationBuilder.AlterColumn<string>(
            //    name: "DESCRIPCION",
            //    table: "ESTADOS_CUOTAS_VENTAS",
            //    type: "text",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "varchar(MAX)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "DESCRIPCION",
            //    table: "ESTADOS_COMPRAS",
            //    type: "text",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "DESCRIPCION",
            //    table: "ESTADOS_COMPONENTES_DETALLES",
            //    type: "text",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "DESCRIPCION",
            //    table: "ESTADOS_ARCHIVOS_MOVIMIENTOS_STOCK",
            //    type: "text",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "NOMBRE",
            //    table: "ENTIDADES_TIPOS",
            //    type: "text",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "NOMBRE_CATEGORIA",
            //    table: "ENTIDADES_CATEGORIAS",
            //    type: "text",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "NOMBRE_CLAVE",
            //    table: "ENTIDADES",
            //    type: "text",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "text");

            //migrationBuilder.AlterColumn<string>(
            //    name: "NOMBRE",
            //    table: "ENTIDADES",
            //    type: "text",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "varchar(max)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "LOCALIDAD",
            //    table: "ENTIDADES",
            //    type: "text",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "varchar(MAX)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "BARRIO",
            //    table: "ENTIDADES",
            //    type: "text",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "varchar(max)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "APELLIDO",
            //    table: "ENTIDADES",
            //    type: "text",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "varchar(max)",
            //    oldNullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "EstadoIdEstadoCompra",
            //    table: "COMPRAS",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.AlterColumn<string>(
            //    name: "ID_FRACCIONAMIENTO",
            //    table: "COMPONENTES_DETALLE",
            //    type: "varchar(50)",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(50)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "ID_ALMACENAMIENTO",
            //    table: "COMPONENTES_DETALLE",
            //    type: "varchar(50)",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(50)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "PATH",
            //    table: "ARCHIVOS_STOCK",
            //    type: "text",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "varchar(MAX)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "MIME_TYPE",
            //    table: "ARCHIVOS_STOCK",
            //    type: "text",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "varchar(MAX)",
            //    oldNullable: true);

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_ESTADOS_MOVIMIENTOS_STOCK",
            //    table: "ESTADOS_MOVIMIENTOS_STOCK",
            //    column: "ID_ESTADO_MOVIMIENTO");

            migrationBuilder.CreateIndex(
                name: "IX_COMPRAS_ID_ESTADO_COMPRA",
                table: "COMPRAS",
                column: "ID_ESTADO_COMPRA");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_STOCK_MOVIMIENTOS_ESTADOS_MOVIMIENTOS_STOCK_ID_ESTADO_MOVIM~",
            //    table: "STOCK_MOVIMIENTOS",
            //    column: "ID_ESTADO_MOVIMIENTO",
            //    principalTable: "ESTADOS_MOVIMIENTOS_STOCK",
            //    principalColumn: "ID_ESTADO_MOVIMIENTO",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_SUMINISTROS_MOVIMIENTOS_STOCK_ESTADOS_SUMINISTROS_MOVIMIENTO",
            //    table: "SUMINISTROS_MOVIMIENTOS_STOCK",
            //    column: "ID_ESTADO",
            //    principalTable: "ESTADOS_SUMINISTROS_MOVIMIENTOS_STOCK",
            //    principalColumn: "ID_ESTADO",
            //    onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COMPRAS_ESTADOS_COMPRAS_EstadoIdEstadoCompra",
                table: "COMPRAS");

            migrationBuilder.DropForeignKey(
                name: "FK_STOCK_MOVIMIENTOS_ESTADOS_MOVIMIENTOS_STOCK_ID_ESTADO_MOVIM~",
                table: "STOCK_MOVIMIENTOS");

            migrationBuilder.DropForeignKey(
                name: "FK_SUMINISTROS_MOVIMIENTOS_STOCK_ESTADOS_SUMINISTROS_MOVIMIENTO",
                table: "SUMINISTROS_MOVIMIENTOS_STOCK");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ESTADOS_MOVIMIENTOS_STOCK",
                table: "ESTADOS_MOVIMIENTOS_STOCK");

            migrationBuilder.DropIndex(
                name: "IX_COMPRAS_EstadoIdEstadoCompra",
                table: "COMPRAS");

            migrationBuilder.DropColumn(
                name: "ID_ESTADO_MOVIMIENTO",
                table: "ESTADOS_MOVIMIENTOS_STOCK");

            migrationBuilder.DropColumn(
                name: "EstadoIdEstadoCompra",
                table: "COMPRAS");

            migrationBuilder.RenameColumn(
                name: "ID_ESTADO_MOVIMIENTO",
                table: "STOCK_MOVIMIENTOS",
                newName: "ID_ESTADO");

            migrationBuilder.RenameIndex(
                name: "IX_STOCK_MOVIMIENTOS_ID_ESTADO_MOVIMIENTO",
                table: "STOCK_MOVIMIENTOS",
                newName: "IX_STOCK_MOVIMIENTOS_ID_ESTADO");

            migrationBuilder.AlterColumn<string>(
                name: "ID_SUMINISTRO",
                table: "SUMINISTROS_MOVIMIENTOS_STOCK",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AddColumn<decimal>(
                name: "VALOR_ANTERIOR_DESTINO",
                table: "SUMINISTROS_MOVIMIENTOS_STOCK",
                type: "numeric(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "VALOR_ANTERIOR_ORIGEN",
                table: "SUMINISTROS_MOVIMIENTOS_STOCK",
                type: "numeric(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "VALOR_NUEVO_DESTINO",
                table: "SUMINISTROS_MOVIMIENTOS_STOCK",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "VALOR_NUEVO_ORIGEN",
                table: "SUMINISTROS_MOVIMIENTOS_STOCK",
                type: "numeric(18,2)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "USUARIO_MODIFICA",
                table: "STOCK_MOVIMIENTOS",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "USUARIO_CREADO",
                table: "STOCK_MOVIMIENTOS",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "ID_TIPO",
                table: "PRODUCTOS_TIPOS_DESCRIPCION",
                type: "character varying(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "DESCRIPCION",
                table: "MEDIOS_PAGO",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "CODIGO_MPAGO",
                table: "MEDIOS_PAGO",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DESCRIPCION",
                table: "ESTADOS_VENTAS",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "DESCRIPCION",
                table: "ESTADOS_SUMINISTROS_MOVIMIENTOS_STOCK",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "DESCRIPCION",
                table: "ESTADOS_PRODUCTOS_TIPOS",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "DESCRIPCION",
                table: "ESTADOS_PRODUCTOS_DESCRIPCIONES",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "DESCRIPCION",
                table: "ESTADOS_PRODUCTOS_COMPONENTES",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "DESCRIPCION",
                table: "ESTADOS_PRODUCTOS",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "ID_ESTADO",
                table: "ESTADOS_MOVIMIENTOS_STOCK",
                type: "integer",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValueSql: "1")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "DESCRIPCION",
                table: "ESTADOS_MOVIMIENTOS_STOCK",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "DESCRIPCION",
                table: "ESTADOS_CUOTAS_VENTAS",
                type: "varchar(MAX)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "DESCRIPCION",
                table: "ESTADOS_COMPRAS",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "DESCRIPCION",
                table: "ESTADOS_COMPONENTES_DETALLES",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "DESCRIPCION",
                table: "ESTADOS_ARCHIVOS_MOVIMIENTOS_STOCK",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "NOMBRE",
                table: "ENTIDADES_TIPOS",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "NOMBRE_CATEGORIA",
                table: "ENTIDADES_CATEGORIAS",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "NOMBRE_CLAVE",
                table: "ENTIDADES",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NOMBRE",
                table: "ENTIDADES",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LOCALIDAD",
                table: "ENTIDADES",
                type: "varchar(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BARRIO",
                table: "ENTIDADES",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "APELLIDO",
                table: "ENTIDADES",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ID_FRACCIONAMIENTO",
                table: "COMPONENTES_DETALLE",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ID_ALMACENAMIENTO",
                table: "COMPONENTES_DETALLE",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PATH",
                table: "ARCHIVOS_STOCK",
                type: "varchar(MAX)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "MIME_TYPE",
                table: "ARCHIVOS_STOCK",
                type: "varchar(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ESTADOS_MOVIMIENTOS_STOCK",
                table: "ESTADOS_MOVIMIENTOS_STOCK",
                column: "ID_ESTADO");

            migrationBuilder.CreateIndex(
                name: "IX_COMPRAS_ID_ESTADO_COMPRA",
                table: "COMPRAS",
                column: "ID_ESTADO_COMPRA");

            migrationBuilder.AddForeignKey(
                name: "FK_COMPRAS_ESTADOS_COMPRAS_ID_ESTADO_COMPRA",
                table: "COMPRAS",
                column: "ID_ESTADO_COMPRA",
                principalTable: "ESTADOS_COMPRAS",
                principalColumn: "ID_ESTADO_COMPRA",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_STOCK_MOVIMIENTOS_ESTADOS_MOVIMIENTOS_STOCK_ID_ESTADO",
                table: "STOCK_MOVIMIENTOS",
                column: "ID_ESTADO",
                principalTable: "ESTADOS_MOVIMIENTOS_STOCK",
                principalColumn: "ID_ESTADO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SUMINISTROS_MOVIMIENTOS_STOCK_ESTADOS_SUMINISTROS_MOVIMIENT~",
                table: "SUMINISTROS_MOVIMIENTOS_STOCK",
                column: "ID_ESTADO",
                principalTable: "ESTADOS_SUMINISTROS_MOVIMIENTOS_STOCK",
                principalColumn: "ID_ESTADO",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
