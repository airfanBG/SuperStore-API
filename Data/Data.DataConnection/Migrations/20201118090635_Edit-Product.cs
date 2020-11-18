using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.DataConnection.Migrations
{
    public partial class EditProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "223b8e84-df8e-4391-bee9-fb4e76fa44c8");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "71e82f47-ebe8-4e69-985a-3b714671e5be");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "a92c7ce3-9805-4f08-9411-da09f9f5be11");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "e29da608-5653-4d90-89a5-a624a16cbadf");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "CurrentCountInWarehouse", "DeletedAt", "ManufacturerId", "MinimumCountAlert", "ModifiedAt", "ProductName", "ProductPrice" },
                values: new object[,]
                {
                    { "c454d748-ef4f-40df-8edf-60b4048a8390", new DateTime(2020, 11, 18, 11, 6, 35, 49, DateTimeKind.Local).AddTicks(9932), 10, null, null, 10, null, "Ball", 1m },
                    { "48666a56-f732-4a91-8e12-5946f686c688", new DateTime(2020, 11, 18, 11, 6, 35, 53, DateTimeKind.Local).AddTicks(4114), 10, null, null, 10, null, "Bat", 11m },
                    { "f331a6bc-e651-482b-815a-852fc08013e0", new DateTime(2020, 11, 18, 11, 6, 35, 53, DateTimeKind.Local).AddTicks(4165), 10, null, null, 10, null, "Bike", 100m },
                    { "b37a710b-ea03-46fa-b045-6a71bdb4bdda", new DateTime(2020, 11, 18, 11, 6, 35, 53, DateTimeKind.Local).AddTicks(4175), 10, null, null, 10, null, "T-shirt", 15m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "48666a56-f732-4a91-8e12-5946f686c688");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "b37a710b-ea03-46fa-b045-6a71bdb4bdda");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "c454d748-ef4f-40df-8edf-60b4048a8390");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "f331a6bc-e651-482b-815a-852fc08013e0");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "CurrentCountInWarehouse", "DeletedAt", "ManufacturerId", "MinimumCountAlert", "ModifiedAt", "ProductName", "ProductPrice" },
                values: new object[,]
                {
                    { "223b8e84-df8e-4391-bee9-fb4e76fa44c8", new DateTime(2020, 11, 18, 11, 3, 42, 68, DateTimeKind.Local).AddTicks(8718), 10, null, null, 10, null, "Ball", 1m },
                    { "71e82f47-ebe8-4e69-985a-3b714671e5be", new DateTime(2020, 11, 18, 11, 3, 42, 72, DateTimeKind.Local).AddTicks(9369), 10, null, null, 10, null, "Bat", 11m },
                    { "e29da608-5653-4d90-89a5-a624a16cbadf", new DateTime(2020, 11, 18, 11, 3, 42, 72, DateTimeKind.Local).AddTicks(9427), 10, null, null, 10, null, "Bike", 100m },
                    { "a92c7ce3-9805-4f08-9411-da09f9f5be11", new DateTime(2020, 11, 18, 11, 3, 42, 72, DateTimeKind.Local).AddTicks(9435), 10, null, null, 10, null, "T-shirt", 15m }
                });
        }
    }
}
