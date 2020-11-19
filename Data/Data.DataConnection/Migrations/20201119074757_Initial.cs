using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.DataConnection.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    MinimumCountAlert = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
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
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    ProductId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
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
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "CurrentCountInWarehouse", "DeletedAt", "MinimumCountAlert", "ModifiedAt", "ProductName", "ProductPrice" },
                values: new object[,]
                {
                    { "79991602-1a2d-4802-8382-49f06fe414ef", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "b7972", 0m },
                    { "3193a9bd-3286-46b4-b47f-00cf30f0c469", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "6f2da", 730m },
                    { "16cfc5cc-d83d-4821-ae17-5b0afb8acd6b", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "667eb", 720m },
                    { "4c5b4522-c4fc-429e-a076-87a0eb6ebddd", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "1e370", 710m },
                    { "dfa341a1-7dfe-409d-951c-0c3cf286f053", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "2fa6f", 700m },
                    { "109e4626-b78d-407e-b7bc-7bd1da13b01d", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "cce7c", 690m },
                    { "a3fdf44a-6567-4177-a66f-429bf7514684", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "f06c5", 680m },
                    { "cd9ea38f-940a-415a-b9ec-e93e0f68ea06", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "8a486", 670m },
                    { "4c7b5672-615b-4460-b24b-975f6cbb2361", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "d8c75", 660m },
                    { "128e11b4-69c2-4859-be41-46354205b50a", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "8d18d", 650m },
                    { "fe3fe276-c381-4a61-8bd1-d967a1d8f71b", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "ab6cd", 640m },
                    { "18a0ff1a-53f0-4848-bed3-3deb689bff98", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "76063", 630m },
                    { "da3bb9ed-6d90-4bfc-be5c-3400cbf158c2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "e0bd0", 620m },
                    { "a9ef0eb7-316c-4ccf-9c68-a8535e551c27", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "24f1f", 610m },
                    { "73d34d35-0cf5-4e03-a666-f7202136749c", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "112b7", 600m },
                    { "5a28f69b-3bfd-4189-9582-105612f8ec3b", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "a5d5b", 590m },
                    { "b0bc2cbc-b19e-4159-badc-58c85581f56f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "30295", 580m },
                    { "343e7b97-d807-4917-ba18-a85aed98fa4f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "86ca6", 570m },
                    { "8ca80082-c545-4c97-9714-23bfdbc5bee8", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "a373c", 560m },
                    { "d288132a-b322-4532-a567-13f750e69400", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "0225b", 550m },
                    { "82459e6f-5362-4c42-9748-2d000617477f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "45580", 540m },
                    { "e8211936-7590-469d-a8b3-5e48c77311f5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "51e3a", 530m },
                    { "467f0265-2b17-4f41-b9e6-60ce78943ac3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "d57f1", 740m },
                    { "a0e24735-be12-40e9-86a1-3862a4ff553c", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "0dd09", 750m },
                    { "069c661d-7c54-4792-8918-1085d11a52e0", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "4e8be", 760m },
                    { "e564452e-d638-42ed-92d7-8cb94669bffc", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "de25b", 770m },
                    { "23fb0efd-0eac-4e41-81c4-649aaca562e9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "aa237", 990m },
                    { "7eeb63f1-3bc7-482a-9635-01f2982a9f65", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "69880", 980m },
                    { "aae71e32-a999-4660-8261-2a0cebac1930", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "a3e30", 970m },
                    { "1e16913f-6364-49d1-a1d6-8478a7218265", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "4cb4b", 960m },
                    { "1aa29566-8101-45a4-adae-f451ba50adad", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "e7733", 950m },
                    { "6f573a3d-c34e-4d59-a4f3-dccbba65dc68", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "973c3", 940m },
                    { "43cb7890-fe76-4a50-b571-5a8be53f5d72", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "61ee6", 930m },
                    { "70a50f39-dfd8-49e1-9c13-56f7cc9abae8", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "6a418", 920m },
                    { "51e09222-c6d6-44b7-aca5-94b9e3399093", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "9323f", 910m },
                    { "3d8c289d-b96b-42c5-a5c0-d00e58da4ad3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "80c59", 900m },
                    { "a6fc3663-4ffa-4f27-ac11-86ec1b4bcac3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "8833a", 520m },
                    { "c0bad910-2b72-4b0d-85bd-bb6fc98bb778", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "b0c73", 890m },
                    { "aeeb5ac5-fe36-48d0-bbb6-7dd2f87692bf", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "12c2d", 870m },
                    { "81cbfc68-4416-4394-955e-0fbc8bfed246", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "3c604", 860m },
                    { "93ee59c5-b119-4baf-9700-864503938ef5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "e764f", 850m },
                    { "bf577890-57a6-4eeb-a124-2ddce9c43ff3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "4276b", 840m },
                    { "88da2ead-44a9-460b-8620-98f9136bcb41", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "345f2", 830m },
                    { "e9124a4e-6292-46a3-90d7-6b44573b1f65", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "63f8d", 820m },
                    { "d3632671-5b45-4d30-84be-5791c4ea09a8", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "c6a12", 810m },
                    { "217e7127-b6dc-4aac-b7cb-65988382fb16", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "62185", 800m },
                    { "25da2764-74d9-47ac-8060-8fbe138157fa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "77ba1", 790m },
                    { "c83ae27d-a4ca-447c-bff7-ea302c9cb3b5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "85ed1", 780m },
                    { "ee06a191-e85c-4920-946a-86f854bb3b5e", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "5953f", 880m },
                    { "ad9226a1-a89a-4c99-aa0e-f5558e9586b0", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "e05d0", 500m },
                    { "5ea6d3e5-92de-454f-9e02-b704e90fccb4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "0f200", 510m },
                    { "699f6da0-5634-4891-9590-cff75863dbb5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "933af", 240m },
                    { "e09d45d6-e6f4-4372-9948-e36bc18f6332", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "e4c3a", 230m },
                    { "67a30e2e-142b-4f9a-8319-85dc6e35eda4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "5b461", 220m },
                    { "3f79d0ef-69bf-499b-8c25-619629394e84", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "5c8da", 210m },
                    { "f05f0c78-c569-48fe-95af-5f5af7b4f751", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "fd897", 200m },
                    { "ec147189-3482-4f78-9dae-d274feef8bf9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "c654d", 190m },
                    { "ce8b8d60-9897-49c4-9056-59bba14fa6a0", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "3e3d6", 180m },
                    { "0971f52f-f98e-4543-9174-5ab5236d3d3c", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "23516", 170m },
                    { "79956d3c-656e-4859-b569-ef2b710b58f1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "56351", 160m },
                    { "b2d80bcd-e262-483b-a082-e2e6529c0d4f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "3c541", 150m },
                    { "db54676c-67f9-406d-93d6-21e269d5f233", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "9912c", 140m },
                    { "55a010fd-d9aa-4152-b474-71434c259a9f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "a2529", 130m },
                    { "9bdc4a8a-39cc-46ae-a29e-185aa6faeea8", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "ebefe", 120m },
                    { "03a70466-dc82-427d-97f0-38a4ba09cbde", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "4d885", 110m },
                    { "7ef5be5a-6033-4bac-b520-7e710a50a94a", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "69fb1", 100m },
                    { "35afa419-73f9-41c1-9f4f-7c86e88b62c8", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "a96ea", 90m },
                    { "370190e4-cf7b-4cb9-a5f8-e94ce111339a", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "5a692", 80m },
                    { "49e8c335-dcc9-4caf-a043-c5c3cf80bc72", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "aa277", 70m },
                    { "66716477-cdc6-434a-9a7a-a47bc27748b4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "191b6", 60m },
                    { "c32459d5-cb0a-410c-abf3-1129dc40c4be", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "be7e0", 50m },
                    { "664e9dc8-770e-4022-b222-eef3d6ed77ea", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "88090", 40m },
                    { "95b059b5-9341-4b63-975e-0be2116ec68a", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "d9d2b", 30m },
                    { "086a240b-2b77-4f2f-b90f-a863b08d07a2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "cbafc", 490m },
                    { "b0836acc-acd3-4408-8af7-c1fe85ff3fcf", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "13d5c", 20m },
                    { "8a4a88b0-0cdd-4ee8-8a55-37d9a716d383", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "52695", 250m },
                    { "73256b55-ec1f-42a3-9b72-bb482f3f3b23", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "80598", 270m },
                    { "f2a8db92-2a82-479c-8ef1-130009871d50", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "af325", 480m },
                    { "4981aec0-6827-453b-b07a-3bec25ac1e9f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "7f285", 470m },
                    { "f0360ae8-eccf-49b0-b402-1324b66cf1a9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "b7da9", 460m },
                    { "814389e4-496e-4942-b9a8-ff5f63316794", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "8edae", 450m },
                    { "19a912c0-05a5-410f-86e5-9f9e45de9452", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "2d0b4", 440m },
                    { "9a1a978d-5dc5-4d79-8486-ad42d8bad805", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "0043f", 430m },
                    { "b664742e-556c-4818-83ff-4279d214de5b", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "c2bda", 420m },
                    { "59df24f4-8d19-4002-9230-6407ab62645f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "3908a", 410m },
                    { "9263e346-7ae4-487a-93bf-cbe5cb9c1955", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "ccaf2", 400m },
                    { "befd0ba9-e08a-4375-b998-ae3b51968ae0", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "2e5a6", 390m },
                    { "7fc6506e-3a51-4399-a9b5-56dfbd158df2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "651bb", 380m },
                    { "31b946c5-fc1e-482a-a55f-0d2a9f2046a4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "917e6", 370m },
                    { "48ddb187-4349-4833-9a38-3f66b7ca64a3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "73a1e", 360m },
                    { "1cf7e17d-beef-43e7-86ed-f79bdc7ba07e", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "160d1", 350m },
                    { "47709512-7e79-466c-9d30-25a25bc0728d", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "1232f", 340m },
                    { "4ddc2010-03cf-4ebf-80f7-ef3f9c92819d", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "e1a3c", 330m },
                    { "1d209a79-c538-4631-a06c-92167b96e04a", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "150d8", 320m },
                    { "f0af55a0-ef13-438f-89bb-bca88b8b2aac", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "f1349", 310m },
                    { "94c07f8c-f5b4-45d3-bf93-7ee72fc933f5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "52404", 300m },
                    { "c835c6e4-5dad-4166-9245-4d77dcb05dad", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "d7311", 290m },
                    { "34ba8422-08b1-4fed-943c-31d080a2a1d9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "7bed6", 280m },
                    { "beddd616-d73d-43d2-b442-64b1e0f2170e", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "befcd", 260m },
                    { "c922d9c3-b8f8-4c11-9516-bb042107f34d", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, null, 10, null, "51458", 10m }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "ModifiedAt", "Password", "UserName" },
                values: new object[,]
                {
                    { "9cb16286-4fc4-4272-8449-f53347bb2926", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "123", "Ginka" },
                    { "929a9893-27af-4f68-8dbd-574ed0ced1ce", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "123", "Minka" },
                    { "21c6fd77-0b9d-4ce1-85d1-9e8ef6eba4cf", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "123", "Gosho" }
                });

            migrationBuilder.InsertData(
                table: "Sellers",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "ModifiedAt", "SellerNumber", "UserId" },
                values: new object[] { "490c3618-f34d-4972-a830-faa7007cc6f0", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "1", "929a9893-27af-4f68-8dbd-574ed0ced1ce" });

            migrationBuilder.InsertData(
                table: "Sellers",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "ModifiedAt", "SellerNumber", "UserId" },
                values: new object[] { "01004ba9-2ff3-4805-87b6-3ec01b8955e4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "1", "9cb16286-4fc4-4272-8449-f53347bb2926" });

            migrationBuilder.InsertData(
                table: "Sellers",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "ModifiedAt", "SellerNumber", "UserId" },
                values: new object[] { "4de91f94-c521-4274-9c5e-c62e0154461e", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "1", "21c6fd77-0b9d-4ce1-85d1-9e8ef6eba4cf" });

            migrationBuilder.InsertData(
                table: "SellerProduct",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "ModifiedAt", "ProductId", "SellerId" },
                values: new object[,]
                {
                    { "2e304bab-31f6-490d-a66c-434bd027956a", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "79991602-1a2d-4802-8382-49f06fe414ef", "490c3618-f34d-4972-a830-faa7007cc6f0" },
                    { "b9a34c27-f879-468e-bed6-b75951077d27", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "55a010fd-d9aa-4152-b474-71434c259a9f", "490c3618-f34d-4972-a830-faa7007cc6f0" },
                    { "824e9fc8-ef6d-4952-a9a3-a02e1acbc2c0", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "b0836acc-acd3-4408-8af7-c1fe85ff3fcf", "490c3618-f34d-4972-a830-faa7007cc6f0" },
                    { "cf9c989a-3a63-4e7b-b2a7-ee4a75ba8f01", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "79991602-1a2d-4802-8382-49f06fe414ef", "01004ba9-2ff3-4805-87b6-3ec01b8955e4" },
                    { "4fcfbdd0-b88f-469c-8851-c58c02407e96", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "c32459d5-cb0a-410c-abf3-1129dc40c4be", "01004ba9-2ff3-4805-87b6-3ec01b8955e4" },
                    { "57e4fc6a-0e24-4fef-a061-8b361f014981", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "370190e4-cf7b-4cb9-a5f8-e94ce111339a", "01004ba9-2ff3-4805-87b6-3ec01b8955e4" },
                    { "bd2951f9-5211-4f25-b887-e47f21b0891f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "95b059b5-9341-4b63-975e-0be2116ec68a", "01004ba9-2ff3-4805-87b6-3ec01b8955e4" },
                    { "15f6dbd2-227e-48b3-aafc-ed998db81f83", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "35afa419-73f9-41c1-9f4f-7c86e88b62c8", "01004ba9-2ff3-4805-87b6-3ec01b8955e4" },
                    { "f7f26f1c-4f35-4a13-b974-29c766bcc697", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "03a70466-dc82-427d-97f0-38a4ba09cbde", "01004ba9-2ff3-4805-87b6-3ec01b8955e4" },
                    { "7877a5ec-5bbc-45d2-afed-cf4a4d8ca8f5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "95b059b5-9341-4b63-975e-0be2116ec68a", "01004ba9-2ff3-4805-87b6-3ec01b8955e4" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                table: "Images",
                column: "ProductId");

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
                name: "Images");

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
                name: "Users");
        }
    }
}
