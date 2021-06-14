using Microsoft.EntityFrameworkCore.Migrations;

namespace WebTask.EFData.Migrations
{
    public partial class ManyToMany_types : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_productTypes_ProductTypeId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_ProductTypeId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "ProductTypeId",
                table: "products");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "ProductTypeId",
                table: "products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_ProductTypeId",
                table: "products",
                column: "ProductTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_productTypes_ProductTypeId",
                table: "products",
                column: "ProductTypeId",
                principalTable: "productTypes",
                principalColumn: "type_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
