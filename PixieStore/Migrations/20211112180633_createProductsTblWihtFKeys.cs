using Microsoft.EntityFrameworkCore.Migrations;

namespace PixieStore.Migrations
{
    public partial class createProductsTblWihtFKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductCategoryId",
                table: "productCategory",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    ProducTagsId = table.Column<int>(type: "int", nullable: false),
                    ProductTagsId = table.Column<int>(type: "int", nullable: true),
                    ProductCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductTag_ProductTagsId",
                        column: x => x.ProductTagsId,
                        principalTable: "ProductTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_productCategory_ProductCategoryId",
                table: "productCategory",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTagsId",
                table: "Products",
                column: "ProductTagsId");

            migrationBuilder.AddForeignKey(
                name: "FK_productCategory_Products_ProductCategoryId",
                table: "productCategory",
                column: "ProductCategoryId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productCategory_Products_ProductCategoryId",
                table: "productCategory");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropIndex(
                name: "IX_productCategory_ProductCategoryId",
                table: "productCategory");

            migrationBuilder.DropColumn(
                name: "ProductCategoryId",
                table: "productCategory");
        }
    }
}
