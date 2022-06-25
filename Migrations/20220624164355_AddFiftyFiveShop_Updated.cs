using Microsoft.EntityFrameworkCore.Migrations;

namespace FifyFiveShop.Migrations
{
    public partial class AddFiftyFiveShop_Updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey("FK_Product", "PriceRule");
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "PriceRule");

            migrationBuilder.AddColumn<string>(
                name: "SKU",
                table: "PriceRule",
                nullable: false,
                defaultValue: "");
          // migrationBuilder.AddForeignKey("FK_Product", "PriceRule", "SKU", "Product", principalColumn: "SKU");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SKU",
                table: "PriceRule");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "PriceRule",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
