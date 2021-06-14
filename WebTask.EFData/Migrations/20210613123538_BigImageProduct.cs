using Microsoft.EntityFrameworkCore.Migrations;

namespace WebTask.EFData.Migrations
{
    public partial class BigImageProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "prod_imgsrc",
                table: "products",
                newName: "prod_bigimgsrc");

            migrationBuilder.AddColumn<string>(
                name: "BigImageSrc",
                table: "products",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BigImageSrc",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "prod_bigimgsrc",
                table: "products",
                newName: "prod_imgsrc");
        }
    }
}
