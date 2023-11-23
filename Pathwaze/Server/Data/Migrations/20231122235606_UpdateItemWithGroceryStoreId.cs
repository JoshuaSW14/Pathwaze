using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pathwaze.Server.Migrations
{
    /// <inheritdoc />
    public partial class UpdateItemWithGroceryStoreId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreationUserId",
                table: "Items",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "GroceryStoreId",
                table: "Items",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "LastUpdatedUserId",
                table: "Items",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SupplierId",
                table: "Items",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_GroceryStoreId",
                table: "Items",
                column: "GroceryStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_SupplierId",
                table: "Items",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_GroceryStores_GroceryStoreId",
                table: "Items",
                column: "GroceryStoreId",
                principalTable: "GroceryStores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Suppliers_SupplierId",
                table: "Items",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_GroceryStores_GroceryStoreId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Suppliers_SupplierId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_GroceryStoreId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_SupplierId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CreationUserId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "GroceryStoreId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "LastUpdatedUserId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Items");
        }
    }
}
