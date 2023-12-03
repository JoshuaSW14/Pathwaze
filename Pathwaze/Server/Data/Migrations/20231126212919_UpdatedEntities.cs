using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pathwaze.Server.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Addresses_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Suppliers_SupplierId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Addresses_AddressId",
                table: "Suppliers");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_AddressId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Items_SupplierId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Suppliers",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Suppliers",
                newName: "LastUpdatedUserId");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Recipes",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "RecipeBooks",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "GroceryStores",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "AspNetUsers",
                newName: "Deleted");

            migrationBuilder.AddColumn<Guid>(
                name: "CreationUserId",
                table: "Suppliers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreationUserId",
                table: "Recipes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LastUpdatedUserId",
                table: "Recipes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreationUserId",
                table: "RecipeBooks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LastUpdatedUserId",
                table: "RecipeBooks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Preferences",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreationUserId",
                table: "Preferences",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Preferences",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "Preferences",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "LastUpdatedUserId",
                table: "Preferences",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Nutritions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreationUserId",
                table: "Nutritions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Nutritions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "Nutritions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "LastUpdatedUserId",
                table: "Nutritions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Locations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreationUserId",
                table: "Locations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Locations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "FullName",
                table: "Locations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<Guid>(
                name: "GroceryStoreId",
                table: "Locations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "Locations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "LastUpdatedUserId",
                table: "Locations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StreetName",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StreetNumber",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreationUserId",
                table: "GroceryStores",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LastUpdatedUserId",
                table: "GroceryStores",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Locations_GroceryStoreId",
                table: "Locations",
                column: "GroceryStoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_GroceryStores_GroceryStoreId",
                table: "Locations",
                column: "GroceryStoreId",
                principalTable: "GroceryStores",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_GroceryStores_GroceryStoreId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_GroceryStoreId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "CreationUserId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "CreationUserId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "LastUpdatedUserId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "CreationUserId",
                table: "RecipeBooks");

            migrationBuilder.DropColumn(
                name: "LastUpdatedUserId",
                table: "RecipeBooks");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Preferences");

            migrationBuilder.DropColumn(
                name: "CreationUserId",
                table: "Preferences");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Preferences");

            migrationBuilder.DropColumn(
                name: "LastUpdatedDate",
                table: "Preferences");

            migrationBuilder.DropColumn(
                name: "LastUpdatedUserId",
                table: "Preferences");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Nutritions");

            migrationBuilder.DropColumn(
                name: "CreationUserId",
                table: "Nutritions");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Nutritions");

            migrationBuilder.DropColumn(
                name: "LastUpdatedDate",
                table: "Nutritions");

            migrationBuilder.DropColumn(
                name: "LastUpdatedUserId",
                table: "Nutritions");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "CreationUserId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "GroceryStoreId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "LastUpdatedDate",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "LastUpdatedUserId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "StreetName",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "StreetNumber",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "CreationUserId",
                table: "GroceryStores");

            migrationBuilder.DropColumn(
                name: "LastUpdatedUserId",
                table: "GroceryStores");

            migrationBuilder.DropColumn(
                name: "LastUpdatedDate",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "LastUpdatedUserId",
                table: "Suppliers",
                newName: "AddressId");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Suppliers",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "Recipes",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "RecipeBooks",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "GroceryStores",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "AspNetUsers",
                newName: "IsDeleted");

            migrationBuilder.AddColumn<Guid>(
                name: "SupplierId",
                table: "Items",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FullName = table.Column<long>(type: "bigint", nullable: false),
                    GroceryStoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_GroceryStores_GroceryStoreId",
                        column: x => x.GroceryStoreId,
                        principalTable: "GroceryStores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_AddressId",
                table: "Suppliers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_SupplierId",
                table: "Items",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AddressId",
                table: "AspNetUsers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_GroceryStoreId",
                table: "Addresses",
                column: "GroceryStoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Addresses_AddressId",
                table: "AspNetUsers",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Suppliers_SupplierId",
                table: "Items",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Addresses_AddressId",
                table: "Suppliers",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
