using Microsoft.EntityFrameworkCore.Migrations;

namespace FifyFiveShop.Migrations
{
    public partial class AddFiftyFiveShop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
             name: "Product",
             columns: table => new
             {
                 Id = table.Column<int>(nullable: false)
                     .Annotation("SqlServer:Identity", "1, 1"),
                 SKU = table.Column<string>(nullable: false),
                 UnitPrice = table.Column<double>(nullable: false)
             },
             constraints: table =>
             {
                 table.PrimaryKey("PK_Product", x => x.Id);

             });

            migrationBuilder.CreateTable(
                name: "PriceRule",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceRule", x => x.Id);
                    table.ForeignKey("FK_Product", x => x.ProductId, "Product", "Id");
                });

         
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PriceRule");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
