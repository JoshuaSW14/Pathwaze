using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pathwaze.Server.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GroceryStoreId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SupplierId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<float>(type: "real", nullable: false),
                    Longitude = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GroceryStoreId",
                table: "AspNetUsers",
                column: "GroceryStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SupplierId",
                table: "AspNetUsers",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_GroceryStores_GroceryStoreId",
                table: "AspNetUsers",
                column: "GroceryStoreId",
                principalTable: "GroceryStores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Suppliers_SupplierId",
                table: "AspNetUsers",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_GroceryStores_GroceryStoreId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Suppliers_SupplierId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_GroceryStoreId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SupplierId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GroceryStoreId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "AspNetUsers");
        }
    }
}
