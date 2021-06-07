using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebTask.EFData.Migrations
{
    public partial class Categories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "productSizes",
                newName: "size_datemodified");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "productSizes",
                newName: "size_datecreated");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "products",
                newName: "prod_datemodified");

            migrationBuilder.AlterColumn<DateTime>(
                name: "size_datemodified",
                table: "productSizes",
                type: "datetime",
                nullable: false,
                defaultValueSql: "(sysdatetime())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "size_datecreated",
                table: "productSizes",
                type: "datetime",
                nullable: false,
                defaultValueSql: "(sysdatetime())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "prod_datemodified",
                table: "products",
                type: "datetime",
                nullable: false,
                defaultValueSql: "(sysdatetime())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "productCategories",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_name = table.Column<string>(type: "varchar(5)", nullable: false, defaultValueSql: "('')"),
                    category_datecreated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(sysdatetime())"),
                    category_datemodified = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(sysdatetime())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productCategories", x => x.category_id);
                });

            migrationBuilder.CreateTable(
                name: "productTypes",
                columns: table => new
                {
                    type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type_name = table.Column<string>(type: "varchar(5)", nullable: false, defaultValueSql: "('')"),
                    type_datecreated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(sysdatetime())"),
                    type_datemodified = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(sysdatetime())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productTypes", x => x.type_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "productCategories");

            migrationBuilder.DropTable(
                name: "productTypes");

            migrationBuilder.RenameColumn(
                name: "size_datemodified",
                table: "productSizes",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "size_datecreated",
                table: "productSizes",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "prod_datemodified",
                table: "products",
                newName: "ModifiedDate");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "productSizes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "(sysdatetime())");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "productSizes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "(sysdatetime())");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "products",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "(sysdatetime())");
        }
    }
}
