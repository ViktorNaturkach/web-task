using Microsoft.EntityFrameworkCore.Migrations;

namespace WebTask.EFData.Migrations
{
    public partial class ManyToManyTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productTypes_products_ProductId",
                table: "productTypes");

            migrationBuilder.DropIndex(
                name: "IX_productTypes_ProductId",
                table: "productTypes");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "productTypes");

            migrationBuilder.CreateTable(
                name: "ProductProductType",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    TypesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProductType", x => new { x.ProductsId, x.TypesId });
                    table.ForeignKey(
                        name: "FK_ProductProductType_products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "products",
                        principalColumn: "prod_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProductType_productTypes_TypesId",
                        column: x => x.TypesId,
                        principalTable: "productTypes",
                        principalColumn: "type_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductType_TypesId",
                table: "ProductProductType",
                column: "TypesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductProductType");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "productTypes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_productTypes_ProductId",
                table: "productTypes",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_productTypes_products_ProductId",
                table: "productTypes",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "prod_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
