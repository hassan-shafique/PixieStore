using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PixieStore.Migrations
{
    public partial class AddedTagsCatOfProductsTbls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "productCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_CatName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Category_Desc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    created_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    last_Update = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    last_Update = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTag", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "productCategory");

            migrationBuilder.DropTable(
                name: "ProductTag");
        }
    }
}
