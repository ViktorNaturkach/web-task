using Microsoft.EntityFrameworkCore.Migrations;

namespace WebTask.EFData.Migrations
{
    public partial class AddSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productSizes_products_ProductId",
                table: "productSizes");

            migrationBuilder.DropIndex(
                name: "IX_productSizes_ProductId",
                table: "productSizes");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "productSizes");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductProductSize");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "productSizes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_productSizes_ProductId",
                table: "productSizes",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_productSizes_products_ProductId",
                table: "productSizes",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "prod_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
