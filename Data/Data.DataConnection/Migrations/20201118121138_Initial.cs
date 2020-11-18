using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.DataConnection.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    UserName = table.Column<string>(maxLength: 15, nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    ProductName = table.Column<string>(maxLength: 50, nullable: true),
                    ProductPrice = table.Column<decimal>(nullable: false),
                    CurrentCountInWarehouse = table.Column<int>(nullable: false),
                    MinimumCountAlert = table.Column<int>(nullable: false),
                    ManufacturerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    CustomerNumber = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    SellerNumber = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sellers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SellerCustomers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    SellerId = table.Column<string>(nullable: true),
                    CustomerId = table.Column<string>(nullable: true),
                    ProductId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellerCustomers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SellerCustomers_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SellerCustomers_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SellerCustomers_Sellers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Sellers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SellerProduct",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    ProductId = table.Column<string>(nullable: true),
                    SellerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellerProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SellerProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SellerProduct_Sellers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Sellers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "ModifiedAt", "Name" },
                values: new object[] { "583ce722-1eaf-4eb7-9d9a-ed79f00fc498", new DateTime(2020, 11, 18, 14, 11, 38, 265, DateTimeKind.Local).AddTicks(8086), null, null, "Test" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "ModifiedAt", "Password", "UserName" },
                values: new object[,]
                {
                    { "45c402ff-a837-401f-a76f-0b73b32ce8f0", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "123", "Minka" },
                    { "2aed7b9d-7c7b-4b75-8303-2fc29044c5dc", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "123", "Pesho" },
                    { "e0846e07-e605-40c6-9e04-45a1969160dd", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "123", "Gosho" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "CurrentCountInWarehouse", "DeletedAt", "ManufacturerId", "MinimumCountAlert", "ModifiedAt", "ProductName", "ProductPrice" },
                values: new object[,]
                {
                    { "62719331-2b9d-4880-a12e-3f123b03e8ec", new DateTime(2020, 11, 18, 14, 11, 38, 269, DateTimeKind.Local).AddTicks(7609), 10, null, "583ce722-1eaf-4eb7-9d9a-ed79f00fc498", 10, null, "Ball", 1m },
                    { "98810ec2-b859-4f8d-8558-e991722bc92b", new DateTime(2020, 11, 18, 14, 11, 38, 269, DateTimeKind.Local).AddTicks(8408), 10, null, "583ce722-1eaf-4eb7-9d9a-ed79f00fc498", 10, null, "Bat", 11m },
                    { "7e985d13-c0b7-4685-b449-a03e5c7c3f49", new DateTime(2020, 11, 18, 14, 11, 38, 269, DateTimeKind.Local).AddTicks(8441), 10, null, "583ce722-1eaf-4eb7-9d9a-ed79f00fc498", 10, null, "Bike", 100m },
                    { "8db046cf-1750-4f36-9135-404376828bc6", new DateTime(2020, 11, 18, 14, 11, 38, 269, DateTimeKind.Local).AddTicks(8555), 10, null, "583ce722-1eaf-4eb7-9d9a-ed79f00fc498", 10, null, "T-shirt", 15m }
                });

            migrationBuilder.InsertData(
                table: "Sellers",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "ModifiedAt", "SellerNumber", "UserId" },
                values: new object[,]
                {
                    { "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "1", "45c402ff-a837-401f-a76f-0b73b32ce8f0" },
                    { "774f0285-2ecd-4c3f-a323-75d616faa451", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "2", "2aed7b9d-7c7b-4b75-8303-2fc29044c5dc" },
                    { "57efa730-5816-434d-9b5a-004de3cec24a", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "3", "e0846e07-e605-40c6-9e04-45a1969160dd" }
                });

            migrationBuilder.InsertData(
                table: "SellerProduct",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "ModifiedAt", "ProductId", "SellerId" },
                values: new object[,]
                {
                    { "d10891c0-bc4a-4610-9687-baaeb7c91f4f", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(243), null, null, "62719331-2b9d-4880-a12e-3f123b03e8ec", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "fcd22986-ae2d-4bae-ac74-624ff763ad07", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(1274), null, null, "98810ec2-b859-4f8d-8558-e991722bc92b", "774f0285-2ecd-4c3f-a323-75d616faa451" },
                    { "09f29185-54d0-48ce-b07d-0ee64737c73c", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(1244), null, null, "62719331-2b9d-4880-a12e-3f123b03e8ec", "774f0285-2ecd-4c3f-a323-75d616faa451" },
                    { "c55212a7-d382-4158-8f71-e5c183a99d65", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(1213), null, null, "98810ec2-b859-4f8d-8558-e991722bc92b", "774f0285-2ecd-4c3f-a323-75d616faa451" },
                    { "d949cb9e-3e40-4720-9a89-2c42b6ff2f12", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(1116), null, null, "62719331-2b9d-4880-a12e-3f123b03e8ec", "774f0285-2ecd-4c3f-a323-75d616faa451" },
                    { "3fb7355e-9174-471d-975e-689b27225023", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(1054), null, null, "98810ec2-b859-4f8d-8558-e991722bc92b", "774f0285-2ecd-4c3f-a323-75d616faa451" },
                    { "09ec9dbd-7945-4bbe-a339-c533f4096b6c", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(999), null, null, "98810ec2-b859-4f8d-8558-e991722bc92b", "774f0285-2ecd-4c3f-a323-75d616faa451" },
                    { "f1dd098a-6720-4dab-8da9-aba4ec54be36", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(939), null, null, "7e985d13-c0b7-4685-b449-a03e5c7c3f49", "774f0285-2ecd-4c3f-a323-75d616faa451" },
                    { "a30dcb27-0d2a-429c-bc5b-4c72626136c4", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(910), null, null, "62719331-2b9d-4880-a12e-3f123b03e8ec", "774f0285-2ecd-4c3f-a323-75d616faa451" },
                    { "2f969a82-540f-4930-8bf8-b3dac879a23d", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(881), null, null, "62719331-2b9d-4880-a12e-3f123b03e8ec", "774f0285-2ecd-4c3f-a323-75d616faa451" },
                    { "bd61481c-2ad1-4e5d-afb2-37d80ed2faaa", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(850), null, null, "62719331-2b9d-4880-a12e-3f123b03e8ec", "774f0285-2ecd-4c3f-a323-75d616faa451" },
                    { "7503ce66-3417-4715-b6b8-87720b6e5d79", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(819), null, null, "98810ec2-b859-4f8d-8558-e991722bc92b", "774f0285-2ecd-4c3f-a323-75d616faa451" },
                    { "9f1a90fd-07ab-4caf-b33f-9088b6ecc89d", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(792), null, null, "98810ec2-b859-4f8d-8558-e991722bc92b", "774f0285-2ecd-4c3f-a323-75d616faa451" },
                    { "ea9a8588-fd6b-4995-bde3-d5484c08d5ce", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(763), null, null, "62719331-2b9d-4880-a12e-3f123b03e8ec", "774f0285-2ecd-4c3f-a323-75d616faa451" },
                    { "4dab7cb9-395c-4fd3-ba9f-72b16cecb63c", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(628), null, null, "98810ec2-b859-4f8d-8558-e991722bc92b", "774f0285-2ecd-4c3f-a323-75d616faa451" },
                    { "af5e6814-b488-4f17-bacd-37eb18da7cb9", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(534), null, null, "7e985d13-c0b7-4685-b449-a03e5c7c3f49", "774f0285-2ecd-4c3f-a323-75d616faa451" },
                    { "0f984c8f-30bd-48d4-8c26-094829046671", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(405), null, null, "62719331-2b9d-4880-a12e-3f123b03e8ec", "774f0285-2ecd-4c3f-a323-75d616faa451" },
                    { "473a8af3-0d5c-4581-9acd-e93e0f60a3b9", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(344), null, null, "7e985d13-c0b7-4685-b449-a03e5c7c3f49", "774f0285-2ecd-4c3f-a323-75d616faa451" },
                    { "645f6a55-ed53-49c6-be8d-86f6f9353047", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(3326), null, null, "7e985d13-c0b7-4685-b449-a03e5c7c3f49", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "29323d59-e151-4460-9b87-b388b116798f", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(3299), null, null, "98810ec2-b859-4f8d-8558-e991722bc92b", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "c9481f94-5d72-4fd7-a169-8c5a93b9105a", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(3270), null, null, "62719331-2b9d-4880-a12e-3f123b03e8ec", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "559e229f-13c6-46c9-80a1-84eaa00f83cd", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(3243), null, null, "62719331-2b9d-4880-a12e-3f123b03e8ec", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "0d82ba6c-b070-4f61-81f1-efac28096f8e", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(1365), null, null, "62719331-2b9d-4880-a12e-3f123b03e8ec", "774f0285-2ecd-4c3f-a323-75d616faa451" },
                    { "58ec80a4-272a-46ef-af95-4e8f49e0cfb3", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(3190), null, null, "62719331-2b9d-4880-a12e-3f123b03e8ec", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "17f53e78-7ade-4ed5-89a5-67ce00f5e642", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(1397), null, null, "62719331-2b9d-4880-a12e-3f123b03e8ec", "774f0285-2ecd-4c3f-a323-75d616faa451" },
                    { "899033c8-83f2-45cc-b561-db06339e0850", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(1486), null, null, "62719331-2b9d-4880-a12e-3f123b03e8ec", "774f0285-2ecd-4c3f-a323-75d616faa451" },
                    { "42a0b6b1-d99d-45e4-9928-b7791c67fbf9", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(3479), null, null, "62719331-2b9d-4880-a12e-3f123b03e8ec", "774f0285-2ecd-4c3f-a323-75d616faa451" },
                    { "48cc3b5b-12a1-4d63-a599-764a2df09751", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(3451), null, null, "62719331-2b9d-4880-a12e-3f123b03e8ec", "774f0285-2ecd-4c3f-a323-75d616faa451" },
                    { "5fde1b58-69f8-4d19-a81b-c1d528e9d25d", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(3381), null, null, "7e985d13-c0b7-4685-b449-a03e5c7c3f49", "774f0285-2ecd-4c3f-a323-75d616faa451" },
                    { "cbeb668f-024c-4a42-8cfb-77c4ffbcad42", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(3354), null, null, "62719331-2b9d-4880-a12e-3f123b03e8ec", "774f0285-2ecd-4c3f-a323-75d616faa451" },
                    { "1478b4af-930a-46f4-a34b-80db129945ab", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(3217), null, null, "62719331-2b9d-4880-a12e-3f123b03e8ec", "774f0285-2ecd-4c3f-a323-75d616faa451" },
                    { "c4fe7c0a-21be-4da9-92aa-a7ce050f7cde", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(3159), null, null, "62719331-2b9d-4880-a12e-3f123b03e8ec", "774f0285-2ecd-4c3f-a323-75d616faa451" },
                    { "1bc352d1-c2c1-44b6-9a11-5094d91213bf", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(3131), null, null, "98810ec2-b859-4f8d-8558-e991722bc92b", "774f0285-2ecd-4c3f-a323-75d616faa451" },
                    { "8c049110-c185-424c-9ce3-0640c563c07c", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(3044), null, null, "7e985d13-c0b7-4685-b449-a03e5c7c3f49", "774f0285-2ecd-4c3f-a323-75d616faa451" },
                    { "a15a6135-3170-4491-ad7d-d210a9ee1223", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(2747), null, null, "62719331-2b9d-4880-a12e-3f123b03e8ec", "774f0285-2ecd-4c3f-a323-75d616faa451" },
                    { "87b252f8-51b9-49aa-88d5-336111b64fa9", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(2692), null, null, "62719331-2b9d-4880-a12e-3f123b03e8ec", "774f0285-2ecd-4c3f-a323-75d616faa451" },
                    { "fcdb8874-71bd-41a4-814e-5a3469ba59da", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(2660), null, null, "62719331-2b9d-4880-a12e-3f123b03e8ec", "774f0285-2ecd-4c3f-a323-75d616faa451" },
                    { "be1c46c9-156a-4dde-a272-5b4c0eacfd8d", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(2632), null, null, "98810ec2-b859-4f8d-8558-e991722bc92b", "774f0285-2ecd-4c3f-a323-75d616faa451" },
                    { "bd851f7f-3635-470d-8bb6-b7bd52b4b33e", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(2603), null, null, "98810ec2-b859-4f8d-8558-e991722bc92b", "774f0285-2ecd-4c3f-a323-75d616faa451" },
                    { "9edaf118-b07b-44d0-8299-e4576f3a53f2", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(2422), null, null, "7e985d13-c0b7-4685-b449-a03e5c7c3f49", "774f0285-2ecd-4c3f-a323-75d616faa451" },
                    { "6ee9aefa-3d21-4033-82c1-9f9820efe014", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(1911), null, null, "62719331-2b9d-4880-a12e-3f123b03e8ec", "774f0285-2ecd-4c3f-a323-75d616faa451" },
                    { "587ac3e6-dd95-4787-b8a1-190639ca70ca", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(1851), null, null, "62719331-2b9d-4880-a12e-3f123b03e8ec", "774f0285-2ecd-4c3f-a323-75d616faa451" },
                    { "f959fa5b-6a43-47c3-9afa-752bd4a20800", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(1793), null, null, "7e985d13-c0b7-4685-b449-a03e5c7c3f49", "774f0285-2ecd-4c3f-a323-75d616faa451" },
                    { "c60bfce4-d74a-4841-b974-284a5dde9904", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(1673), null, null, "7e985d13-c0b7-4685-b449-a03e5c7c3f49", "774f0285-2ecd-4c3f-a323-75d616faa451" },
                    { "58b652e2-97d9-4dab-b214-871c1293e8e7", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(1645), null, null, "62719331-2b9d-4880-a12e-3f123b03e8ec", "774f0285-2ecd-4c3f-a323-75d616faa451" },
                    { "8d8a3c3e-8f2e-4ab0-99b7-cf460ee1aaae", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(1543), null, null, "7e985d13-c0b7-4685-b449-a03e5c7c3f49", "774f0285-2ecd-4c3f-a323-75d616faa451" },
                    { "b2e359d8-0514-48e2-a091-fa0cd9c43b36", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(1515), null, null, "7e985d13-c0b7-4685-b449-a03e5c7c3f49", "774f0285-2ecd-4c3f-a323-75d616faa451" },
                    { "b0737563-b8dd-4371-8922-db29aa28276c", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(1456), null, null, "7e985d13-c0b7-4685-b449-a03e5c7c3f49", "774f0285-2ecd-4c3f-a323-75d616faa451" },
                    { "1f52506c-95a1-4ca5-bce7-3d27cb17011f", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(3104), null, null, "62719331-2b9d-4880-a12e-3f123b03e8ec", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "6c646884-7fb1-4976-8d9d-516853c41a6a", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(3075), null, null, "62719331-2b9d-4880-a12e-3f123b03e8ec", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "87ec9ae2-8a42-4dd1-b907-0ebbc079862c", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(3016), null, null, "98810ec2-b859-4f8d-8558-e991722bc92b", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "623a2901-1fa7-418b-aa91-b30294bf8ff6", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(1883), null, null, "7e985d13-c0b7-4685-b449-a03e5c7c3f49", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "d7aaddc0-66f7-4280-8427-2657315d3d67", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(1822), null, null, "62719331-2b9d-4880-a12e-3f123b03e8ec", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "f9cf0374-b2c2-4efb-bdd5-ce69cbde4a44", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(1765), null, null, "7e985d13-c0b7-4685-b449-a03e5c7c3f49", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "a365318b-a87a-46df-a48b-0e6c0cec6686", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(1733), null, null, "62719331-2b9d-4880-a12e-3f123b03e8ec", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "b06bff1b-90ff-4bab-a563-4f788837847c", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(1704), null, null, "62719331-2b9d-4880-a12e-3f123b03e8ec", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "93affad1-cccd-483f-9ad4-365d45c09bc1", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(1571), null, null, "7e985d13-c0b7-4685-b449-a03e5c7c3f49", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "8b76f5ba-ca02-49bb-bc8c-f66dca8593f3", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(1427), null, null, "7e985d13-c0b7-4685-b449-a03e5c7c3f49", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "d7a9db5e-11cc-4c17-a874-d19e36583122", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(1333), null, null, "98810ec2-b859-4f8d-8558-e991722bc92b", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "3a9c2262-1cfb-4299-b074-16b09f451f52", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(1303), null, null, "7e985d13-c0b7-4685-b449-a03e5c7c3f49", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "9868bb79-9865-4b51-a78a-03a8183241bd", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(1144), null, null, "62719331-2b9d-4880-a12e-3f123b03e8ec", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "be8de00f-d765-4cb5-b62b-a7cbec142704", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(1086), null, null, "7e985d13-c0b7-4685-b449-a03e5c7c3f49", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "e835e035-3731-48c6-bf8c-01fe35418408", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(1027), null, null, "62719331-2b9d-4880-a12e-3f123b03e8ec", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "2711c625-7f59-439b-ae86-c42ff2210da5", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(971), null, null, "98810ec2-b859-4f8d-8558-e991722bc92b", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "3099dd40-f33c-4774-a7dd-719e4b15f385", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(687), null, null, "98810ec2-b859-4f8d-8558-e991722bc92b", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "4a2c8555-9b0a-492d-b6f1-d0cdb0592198", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(656), null, null, "7e985d13-c0b7-4685-b449-a03e5c7c3f49", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "dfb782f3-fecc-4a75-a18f-e6afafcf3528", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(598), null, null, "7e985d13-c0b7-4685-b449-a03e5c7c3f49", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "3dfae65b-c4ae-4803-8803-acce577a0a21", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(567), null, null, "98810ec2-b859-4f8d-8558-e991722bc92b", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "17849698-bd09-481e-9a41-c55e22bbe4ef", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(504), null, null, "7e985d13-c0b7-4685-b449-a03e5c7c3f49", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "b406d86c-508e-4c04-94be-01f20cfa4bc5", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(475), null, null, "62719331-2b9d-4880-a12e-3f123b03e8ec", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "0793986c-8908-4944-9bc0-1692c7b8a05b", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(441), null, null, "98810ec2-b859-4f8d-8558-e991722bc92b", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "f6534118-82a9-4462-821e-2ad781a9a6bd", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(375), null, null, "62719331-2b9d-4880-a12e-3f123b03e8ec", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "23703c4e-c91d-46f2-9742-c2adab9e332d", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(1939), null, null, "62719331-2b9d-4880-a12e-3f123b03e8ec", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "d9e578d5-3ea3-42f9-a61e-04fc78bd29ea", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(1967), null, null, "98810ec2-b859-4f8d-8558-e991722bc92b", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "a8e00c9a-fe66-4036-a24d-a5452f9bda6a", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(1997), null, null, "7e985d13-c0b7-4685-b449-a03e5c7c3f49", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "ad03df5c-6030-4c69-b28f-92313caf1050", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(2026), null, null, "7e985d13-c0b7-4685-b449-a03e5c7c3f49", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "4e82b2b6-d51e-4048-80b9-886081c72919", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(2988), null, null, "7e985d13-c0b7-4685-b449-a03e5c7c3f49", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "28d532bf-7e67-43fb-879a-4dbafbddc669", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(2920), null, null, "62719331-2b9d-4880-a12e-3f123b03e8ec", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "7acc83c9-3efe-4f69-b0ea-a1af1483ded5", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(2890), null, null, "7e985d13-c0b7-4685-b449-a03e5c7c3f49", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "da115d83-6444-48fc-b643-80828a5e90ed", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(2861), null, null, "98810ec2-b859-4f8d-8558-e991722bc92b", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "aff28b3c-a433-4a75-a2a4-606c70df8307", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(2833), null, null, "7e985d13-c0b7-4685-b449-a03e5c7c3f49", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "2ac920bc-782a-49f7-862c-e7c086719ff4", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(2804), null, null, "62719331-2b9d-4880-a12e-3f123b03e8ec", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "2be6addb-ec77-4519-baa8-c5f3fa59648d", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(2774), null, null, "98810ec2-b859-4f8d-8558-e991722bc92b", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "c34c8706-8962-4f03-b622-3e574baa5554", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(2718), null, null, "62719331-2b9d-4880-a12e-3f123b03e8ec", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "833453b3-efa3-41f4-9756-d419c20dd638", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(2575), null, null, "62719331-2b9d-4880-a12e-3f123b03e8ec", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "3083144c-7688-4476-96b6-9badeb2ed5e8", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(2546), null, null, "62719331-2b9d-4880-a12e-3f123b03e8ec", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "8fd6ae81-277b-4452-ae86-8b218e3be9d1", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(3505), null, null, "62719331-2b9d-4880-a12e-3f123b03e8ec", "774f0285-2ecd-4c3f-a323-75d616faa451" },
                    { "68f03add-62d7-427c-8948-865dc7736795", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(2479), null, null, "98810ec2-b859-4f8d-8558-e991722bc92b", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "f02de763-5779-4f73-9bd8-ddc89b117198", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(2391), null, null, "7e985d13-c0b7-4685-b449-a03e5c7c3f49", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "68db73cc-f323-4bbe-ab60-98699659ac93", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(2363), null, null, "98810ec2-b859-4f8d-8558-e991722bc92b", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "be72bfed-940f-4d5b-9004-8ba9656c0578", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(2335), null, null, "62719331-2b9d-4880-a12e-3f123b03e8ec", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "68e43b0d-b264-4fd2-b7f5-2d6dfe2203a5", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(2306), null, null, "98810ec2-b859-4f8d-8558-e991722bc92b", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "c8dca0e9-b42a-40c0-b807-c34e54c2808d", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(2275), null, null, "7e985d13-c0b7-4685-b449-a03e5c7c3f49", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "98f678c2-0f9f-491a-b864-fb720bbbb525", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(2247), null, null, "7e985d13-c0b7-4685-b449-a03e5c7c3f49", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "94dfc0cd-7622-424a-8c68-c670d1a421b3", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(2218), null, null, "98810ec2-b859-4f8d-8558-e991722bc92b", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "3bf47206-3b91-43bf-a7e6-19f83d3d94ff", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(2189), null, null, "98810ec2-b859-4f8d-8558-e991722bc92b", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "ec84d9e6-bc86-4900-8668-9c2e6263eb14", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(2159), null, null, "62719331-2b9d-4880-a12e-3f123b03e8ec", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "4427b088-d616-4c97-a790-a39e7859e70c", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(2129), null, null, "7e985d13-c0b7-4685-b449-a03e5c7c3f49", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "ed9ebd01-c0ca-4242-898b-2e2f6d72a25b", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(2450), null, null, "7e985d13-c0b7-4685-b449-a03e5c7c3f49", "ac1159e2-d8de-4d34-a0c7-9a2e8bd823ce" },
                    { "d46db939-6b16-4844-a5e9-7c33f35fa259", new DateTime(2020, 11, 18, 14, 11, 38, 270, DateTimeKind.Local).AddTicks(3533), null, null, "7e985d13-c0b7-4685-b449-a03e5c7c3f49", "774f0285-2ecd-4c3f-a323-75d616faa451" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ManufacturerId",
                table: "Products",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_SellerCustomers_CustomerId",
                table: "SellerCustomers",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SellerCustomers_ProductId",
                table: "SellerCustomers",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SellerCustomers_SellerId",
                table: "SellerCustomers",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_SellerProduct_ProductId",
                table: "SellerProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SellerProduct_SellerId",
                table: "SellerProduct",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sellers_UserId",
                table: "Sellers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SellerCustomers");

            migrationBuilder.DropTable(
                name: "SellerProduct");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Sellers");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
