using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "ID_ESTADO",
                table: "Stock_Movimientos",
                type: "Varbinary(1)",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<byte[]>(
                name: "ID_ESTADO_PROPIO",
                table: "ESTADOS_MOVIMIENTOS_STOCK",
                type: "varbinary(1)",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(byte[]),
                oldType: "varbinary(1)",
                oldNullable: true,
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<byte[]>(
                name: "ID_ESTADO",
                table: "ESTADOS_MOVIMIENTOS_STOCK",
                type: "varbinary(1)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
