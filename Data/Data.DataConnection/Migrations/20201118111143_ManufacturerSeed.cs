using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.DataConnection.Migrations
{
    public partial class ManufacturerSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "7d21418b-a457-497f-9486-404fb86ad26a");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "b863c825-cdd4-4470-9471-06cd4dcb1309");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "df221151-cb27-4c41-ba27-e4021a644702");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "f4a4d4fa-8336-4c8b-bfb0-7c5f1f0528d1");

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "ModifiedAt", "Name" },
                values: new object[] { "d1811abc-1917-4d70-a8cc-0b2befe42cc0", new DateTime(2020, 11, 18, 13, 11, 42, 685, DateTimeKind.Local).AddTicks(7388), null, null, "Test" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "CurrentCountInWarehouse", "DeletedAt", "ManufacturerId", "MinimumCountAlert", "ModifiedAt", "ProductName", "ProductPrice" },
                values: new object[,]
                {
                    { "f29f53a5-346f-42ba-8f27-530a9cc1bdbb", new DateTime(2020, 11, 18, 13, 11, 42, 689, DateTimeKind.Local).AddTicks(3671), 10, null, "d1811abc-1917-4d70-a8cc-0b2befe42cc0", 10, null, "Ball", 1m },
                    { "f82840a4-7007-4267-9dea-065af5b667ca", new DateTime(2020, 11, 18, 13, 11, 42, 689, DateTimeKind.Local).AddTicks(4929), 10, null, "d1811abc-1917-4d70-a8cc-0b2befe42cc0", 10, null, "Bat", 11m },
                    { "e4f36e7c-fa6c-4010-a070-086771a52a8c", new DateTime(2020, 11, 18, 13, 11, 42, 689, DateTimeKind.Local).AddTicks(4982), 10, null, "d1811abc-1917-4d70-a8cc-0b2befe42cc0", 10, null, "Bike", 100m },
                    { "91cb7dfe-f54c-447d-a3d5-8b9b27da1759", new DateTime(2020, 11, 18, 13, 11, 42, 689, DateTimeKind.Local).AddTicks(4990), 10, null, "d1811abc-1917-4d70-a8cc-0b2befe42cc0", 10, null, "T-shirt", 15m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "91cb7dfe-f54c-447d-a3d5-8b9b27da1759");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "e4f36e7c-fa6c-4010-a070-086771a52a8c");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "f29f53a5-346f-42ba-8f27-530a9cc1bdbb");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "f82840a4-7007-4267-9dea-065af5b667ca");

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: "d1811abc-1917-4d70-a8cc-0b2befe42cc0");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "CurrentCountInWarehouse", "DeletedAt", "ManufacturerId", "MinimumCountAlert", "ModifiedAt", "ProductName", "ProductPrice" },
                values: new object[,]
                {
                    { "7d21418b-a457-497f-9486-404fb86ad26a", new DateTime(2020, 11, 18, 11, 8, 57, 429, DateTimeKind.Local).AddTicks(2977), 10, null, null, 10, null, "Ball", 1m },
                    { "df221151-cb27-4c41-ba27-e4021a644702", new DateTime(2020, 11, 18, 11, 8, 57, 433, DateTimeKind.Local).AddTicks(3755), 10, null, null, 10, null, "Bat", 11m },
                    { "b863c825-cdd4-4470-9471-06cd4dcb1309", new DateTime(2020, 11, 18, 11, 8, 57, 433, DateTimeKind.Local).AddTicks(3819), 10, null, null, 10, null, "Bike", 100m },
                    { "f4a4d4fa-8336-4c8b-bfb0-7c5f1f0528d1", new DateTime(2020, 11, 18, 11, 8, 57, 433, DateTimeKind.Local).AddTicks(3828), 10, null, null, 10, null, "T-shirt", 15m }
                });
        }
    }
}
