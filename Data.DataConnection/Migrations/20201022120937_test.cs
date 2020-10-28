using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.DataConnection.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductId",
                table: "SellerCustomers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SellerProduct",
                columns: table => new
                {
                    ProductId = table.Column<string>(nullable: false),
                    SellerId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellerProduct", x => new { x.ProductId, x.SellerId });
                    table.ForeignKey(
                        name: "FK_SellerProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SellerProduct_Sellers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Sellers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SellerCustomers_ProductId",
                table: "SellerCustomers",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SellerProduct_SellerId",
                table: "SellerProduct",
                column: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_SellerCustomers_Products_ProductId",
                table: "SellerCustomers",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SellerCustomers_Products_ProductId",
                table: "SellerCustomers");

            migrationBuilder.DropTable(
                name: "SellerProduct");

            migrationBuilder.DropIndex(
                name: "IX_SellerCustomers_ProductId",
                table: "SellerCustomers");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "SellerCustomers");
        }
    }
}
