using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebTask.EFData.Migrations
{
    public partial class Product_datetime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "prod_saleenddate",
                table: "products",
                type: "datetime",
                nullable: false,
                defaultValueSql: "(sysdatetime())",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "(sysdatetimeoffset())");

            migrationBuilder.AlterColumn<DateTime>(
                name: "prod_datecreated",
                table: "products",
                type: "datetime",
                nullable: false,
                defaultValueSql: "(sysdatetime())",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "(sysdatetimeoffset())");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "prod_saleenddate",
                table: "products",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "(sysdatetimeoffset())",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "(sysdatetime())");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "prod_datecreated",
                table: "products",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "(sysdatetimeoffset())",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "(sysdatetime())");
        }
    }
}
