using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AponusWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PRODUCT_CATEGORIES",
                columns: table => new
                {
                    CATEGORYID = table.Column<string>(name: "CATEGORY_ID", type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, collation: "Modern_Spanish_CI_AI"),
                    CATEGORYDESCRIPTION = table.Column<string>(name: "CATEGORY_DESCRIPTION", type: "varchar(100)", unicode: false, maxLength: 100, nullable: true, collation: "Modern_Spanish_CI_AI")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_1", x => x.CATEGORYID);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTS",
                columns: table => new
                {
                    PRODUCTID = table.Column<string>(name: "PRODUCT_ID", type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, collation: "Modern_Spanish_CI_AI"),
                    CATEGORYID = table.Column<string>(name: "CATEGORY_ID", type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, collation: "Modern_Spanish_CI_AI"),
                    PRODUCTDESCRIPTIONNAME = table.Column<string>(name: "PRODUCT_DESCRIPTION_NAME", type: "varchar(100)", unicode: false, maxLength: 100, nullable: false, collation: "Modern_Spanish_CI_AI"),
                    PRODUCTDESCRIPTIONDN = table.Column<int>(name: "PRODUCT_DESCRIPTION_DN", type: "int", nullable: true),
                    PRODUCTDESCRIPTIONOUTSIDEDIAMETER = table.Column<int>(name: "PRODUCT_DESCRIPTION_OUTSIDE_DIAMETER", type: "int", nullable: true),
                    PRODUCTDESCRIPTIONINSIDEDIAMETER = table.Column<int>(name: "PRODUCT_DESCRIPTION_INSIDE_DIAMETER", type: "int", nullable: true),
                    QUANTITY = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    PRICE = table.Column<decimal>(type: "money", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTS_1", x => x.PRODUCTID);
                    table.ForeignKey(
                        name: "FK_PRODUCTS_PRODUCT_CATEGORIES_CATEGORY_ID",
                        column: x => x.CATEGORYID,
                        principalTable: "PRODUCT_CATEGORIES",
                        principalColumn: "CATEGORY_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_CATEGORY_ID",
                table: "PRODUCTS",
                column: "CATEGORY_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRODUCTS");

            migrationBuilder.DropTable(
                name: "PRODUCT_CATEGORIES");
        }
    }
}
