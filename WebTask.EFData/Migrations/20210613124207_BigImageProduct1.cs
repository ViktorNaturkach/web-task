using Microsoft.EntityFrameworkCore.Migrations;

namespace WebTask.EFData.Migrations
{
    public partial class BigImageProduct1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BigImageSrc",
                table: "products");

            migrationBuilder.AddColumn<string>(
                name: "prod_imgsrc",
                table: "products",
                type: "varchar(300)",
                nullable: false,
                defaultValueSql: "('')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "prod_imgsrc",
                table: "products");

            migrationBuilder.AddColumn<string>(
                name: "BigImageSrc",
                table: "products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
