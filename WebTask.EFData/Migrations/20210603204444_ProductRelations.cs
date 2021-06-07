using Microsoft.EntityFrameworkCore.Migrations;

namespace WebTask.EFData.Migrations
{
    public partial class ProductRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductProductSize");

            migrationBuilder.DropColumn(
                name: "prod_category",
                table: "products");

            migrationBuilder.DropColumn(
                name: "prod_type",
                table: "products");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "productSizes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductTypeId",
                table: "products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_productSizes_ProductId",
                table: "productSizes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_products_CategoryId",
                table: "products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_products_ProductTypeId",
                table: "products",
                column: "ProductTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_productCategories_CategoryId",
                table: "products",
                column: "CategoryId",
                principalTable: "productCategories",
                principalColumn: "category_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_products_productTypes_ProductTypeId",
                table: "products",
                column: "ProductTypeId",
                principalTable: "productTypes",
                principalColumn: "type_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_productSizes_products_ProductId",
                table: "productSizes",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "prod_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_productCategories_CategoryId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_productTypes_ProductTypeId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_productSizes_products_ProductId",
                table: "productSizes");

            migrationBuilder.DropIndex(
                name: "IX_productSizes_ProductId",
                table: "productSizes");

            migrationBuilder.DropIndex(
                name: "IX_products_CategoryId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_ProductTypeId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "productSizes");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "ProductTypeId",
                table: "products");

            migrationBuilder.AddColumn<string>(
                name: "prod_category",
                table: "products",
                type: "varchar(60)",
                nullable: false,
                defaultValueSql: "('')");

            migrationBuilder.AddColumn<string>(
                name: "prod_type",
                table: "products",
                type: "varchar(60)",
                nullable: false,
                defaultValueSql: "('')");

            migrationBuilder.CreateTable(
                name: "ProductProductSize",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    SizesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProductSize", x => new { x.ProductsId, x.SizesId });
                    table.ForeignKey(
                        name: "FK_ProductProductSize_products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "products",
                        principalColumn: "prod_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProductSize_productSizes_SizesId",
                        column: x => x.SizesId,
                        principalTable: "productSizes",
                        principalColumn: "size_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductSize_SizesId",
                table: "ProductProductSize",
                column: "SizesId");
        }
    }
}
