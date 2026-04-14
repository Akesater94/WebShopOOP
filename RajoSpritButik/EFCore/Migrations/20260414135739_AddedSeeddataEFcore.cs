using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCore.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeeddataEFcore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase(
                collation: "Finnish_Swedish_CI_AS");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Öl" },
                    { 2, "Vin" },
                    { 3, "Sprit" },
                    { 4, "Cider" },
                    { 5, "HB" }
                });

            migrationBuilder.InsertData(
                table: "ContactTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Telefonnummer" },
                    { 2, "Epost" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sverige" },
                    { 2, "Tjeckien" },
                    { 3, "USA" },
                    { 4, "Tyskland" },
                    { 5, "Italien" },
                    { 6, "Frankrike" }
                });

            migrationBuilder.InsertData(
                table: "PaymentAlternatives",
                columns: new[] { "Id", "Fee", "Name" },
                values: new object[,]
                {
                    { 1, 29.00m, "Faktura" },
                    { 2, 0.00m, "Kortbetalning" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Kund" },
                    { 2, "Administratör" }
                });

            migrationBuilder.InsertData(
                table: "ShippingAlternatives",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "DHL", 49.00m },
                    { 2, "PostNord", 89.00m }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "CountryId", "Street", "StreetNumber", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Uddevalla", 1, "Äskebacka", "125", "451 95" },
                    { 2, "Uddevalla", 1, "Helenedalsvägen", "16", "451 45" },
                    { 3, "Uddevalla", 1, "Kunsgatan", "22", "451 30" },
                    { 4, "Lidköping", 1, "Stenhammarsvägen", "61", "531 56" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Spendrups" },
                    { 2, 1, "Carlsberg Sverige" },
                    { 3, 2, "Pilsner Urquell" },
                    { 4, 2, "Budvar" },
                    { 5, 3, "Budweiser" },
                    { 6, 3, "Coors" },
                    { 7, 4, "Paulaner" },
                    { 8, 4, "Becks" },
                    { 9, 5, "Peroni" },
                    { 10, 5, "Moretti" },
                    { 11, 6, "Kronenbourg" },
                    { 12, 6, "1664 Blanc" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Name", "RoleId", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", 2, "admin" },
                    { 2, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Olle", 1, "olle" },
                    { 3, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ruhollah", 1, "ruhollah" },
                    { 4, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aron", 1, "aron" },
                    { 5, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jimmy", 1, "jimmy" }
                });

            migrationBuilder.InsertData(
                table: "ContactInfos",
                columns: new[] { "Id", "ContactTypeId", "UserId", "Value" },
                values: new object[,]
                {
                    { 1, 1, 5, "0743905120" },
                    { 2, 2, 5, "eliassmmy76@gmail.com" },
                    { 3, 1, 4, "0765968445" },
                    { 4, 2, 4, "arosater@gmail.com" },
                    { 5, 1, 3, "0713159305" },
                    { 6, 2, 3, "ruhollahkari@gmail.com" },
                    { 7, 1, 2, "0123414142" },
                    { 8, 2, 2, "olle@olle.se" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "AddressId", "PaymentAlternativeId", "ShippingAlternativeId", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, 2, 2, 1, "Mottagen", 5 },
                    { 2, 4, 1, 2, "Mottagen", 4 },
                    { 3, 3, 2, 1, "Mottagen", 3 },
                    { 4, 1, 1, 2, "Mottagen", 2 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ManufacturerId", "Name", "Price", "Showcase", "Stock", "VatRate" },
                values: new object[,]
                {
                    { 1, 1, "Svensk ljus lager.", 1, "Spendrups Bright Lager", 22m, true, 15, 0.25m },
                    { 2, 1, "Klassisk exportlager.", 2, "Carlsberg Export", 23m, false, 18, 0.25m },
                    { 3, 1, "Tjeckisk pilsner.", 3, "Pilsner Urquell Original", 26m, true, 16, 0.25m },
                    { 4, 1, "Maltig lager.", 4, "Budvar Original", 25m, false, 14, 0.25m },
                    { 5, 1, "Amerikansk lager.", 5, "Budweiser Lager", 22m, false, 20, 0.25m },
                    { 6, 1, "Tysk veteöl.", 7, "Paulaner Weissbier", 28m, true, 12, 0.25m },
                    { 7, 2, "Italienskt rödvin.", 9, "Chianti Classico", 119m, false, 10, 0.25m },
                    { 8, 2, "Friskt vitt vin.", 10, "Pinot Grigio", 99m, false, 11, 0.25m },
                    { 9, 2, "Franskt kvalitetsvin.", 11, "Bordeaux Rouge", 149m, false, 8, 0.25m },
                    { 10, 3, "Ren vodka.", 1, "Vodka Premium", 249m, false, 7, 0.25m },
                    { 11, 3, "Lagrad whiskey.", 5, "Whiskey Reserve", 329m, false, 5, 0.25m },
                    { 12, 4, "Päroncider.", 2, "Somersby Pear", 24m, false, 18, 0.25m },
                    { 13, 4, "Torr äppelcider.", 6, "Apple Dry Cider", 26m, false, 14, 0.25m },
                    { 14, 5, "Hemblandad specialdryck.", 1, "HB Stark Special", 189m, false, 3, 0.25m },
                    { 15, 5, "Traditionell HB.", 3, "HB Classic", 169m, false, 4, 0.25m }
                });

            migrationBuilder.InsertData(
                table: "ShoppingCarts",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "Jimmys kundvagn", 5 },
                    { 2, "Arons kundvagn", 4 },
                    { 3, "Ruhollahs kundvagn", 3 },
                    { 4, "Olles kundvagn", 2 }
                });

            migrationBuilder.InsertData(
                table: "UserAddresses",
                columns: new[] { "Id", "AddressId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 2, 3, 3 },
                    { 3, 4, 4 },
                    { 4, 2, 5 }
                });

            migrationBuilder.InsertData(
                table: "OrderRows",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 3, 1 },
                    { 2, 1, 6, 13 },
                    { 3, 2, 14, 3 },
                    { 4, 2, 7, 6 },
                    { 5, 3, 11, 2 },
                    { 6, 3, 5, 1 },
                    { 7, 4, 9, 7 },
                    { 8, 4, 15, 4 }
                });

            migrationBuilder.InsertData(
                table: "ShoppingCartRows",
                columns: new[] { "Id", "ProductId", "Quantity", "ShoppingCartId" },
                values: new object[,]
                {
                    { 1, 2, 3, 1 },
                    { 2, 4, 2, 1 },
                    { 3, 3, 5, 2 },
                    { 4, 12, 2, 2 },
                    { 5, 11, 2, 3 },
                    { 6, 14, 4, 3 },
                    { 7, 7, 3, 4 },
                    { 8, 9, 5, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContactInfos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ContactInfos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ContactInfos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ContactInfos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ContactInfos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ContactInfos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ContactInfos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ContactInfos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "OrderRows",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderRows",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderRows",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderRows",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderRows",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OrderRows",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "OrderRows",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "OrderRows",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ShoppingCartRows",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ShoppingCartRows",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ShoppingCartRows",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ShoppingCartRows",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ShoppingCartRows",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ShoppingCartRows",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ShoppingCartRows",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ShoppingCartRows",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "UserAddresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserAddresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserAddresses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserAddresses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ContactTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ContactTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "PaymentAlternatives",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PaymentAlternatives",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ShippingAlternatives",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ShippingAlternatives",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterDatabase(
                oldCollation: "Finnish_Swedish_CI_AS");
        }
    }
}
