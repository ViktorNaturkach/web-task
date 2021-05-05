using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebTask.Migrations.AppDb
{
    public partial class InitAppData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    prod_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    prod_datecreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    prod_name = table.Column<string>(type: "varchar(30)", nullable: false, defaultValueSql: "('')"),
                    prod_description = table.Column<string>(type: "varchar(100)", nullable: false, defaultValueSql: "('')"),
                    prod_price = table.Column<decimal>(type: "decimal(7,2)", nullable: false, defaultValueSql: "(0)"),
                    prod_saleprice = table.Column<decimal>(type: "decimal(7,2)", nullable: false, defaultValueSql: "(0)"),
                    prod_saleenddate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "(sysdatetimeoffset())"),
                    prod_category = table.Column<string>(type: "varchar(30)", nullable: false, defaultValueSql: "('')"),
                    prod_brand = table.Column<string>(type: "varchar(30)", nullable: false, defaultValueSql: "('')"),
                    prod_tag = table.Column<string>(type: "varchar(300)", nullable: false, defaultValueSql: "('')"),
                    prod_color = table.Column<string>(type: "varchar(300)", nullable: false, defaultValueSql: "('')"),
                    prod_size = table.Column<string>(type: "varchar(300)", nullable: false, defaultValueSql: "('')"),
                    prod_imgsrc = table.Column<string>(type: "varchar(300)", nullable: false, defaultValueSql: "('')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.prod_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
