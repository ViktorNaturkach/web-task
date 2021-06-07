using Microsoft.EntityFrameworkCore.Migrations;

namespace WebTask.EFData.Migrations
{
    public partial class ChangeNameSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "type_name",
                table: "productTypes",
                type: "varchar(20)",
                nullable: false,
                defaultValueSql: "('')",
                oldClrType: typeof(string),
                oldType: "varchar(5)",
                oldDefaultValueSql: "('')");

            migrationBuilder.AlterColumn<string>(
                name: "category_name",
                table: "productCategories",
                type: "varchar(20)",
                nullable: false,
                defaultValueSql: "('')",
                oldClrType: typeof(string),
                oldType: "varchar(5)",
                oldDefaultValueSql: "('')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "type_name",
                table: "productTypes",
                type: "varchar(5)",
                nullable: false,
                defaultValueSql: "('')",
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldDefaultValueSql: "('')");

            migrationBuilder.AlterColumn<string>(
                name: "category_name",
                table: "productCategories",
                type: "varchar(5)",
                nullable: false,
                defaultValueSql: "('')",
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldDefaultValueSql: "('')");
        }
    }
}
