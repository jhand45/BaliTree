using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BaliTree.Migrations
{
    public partial class adddbsets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockItems_Orders_StockOrderId",
                table: "StockItems");

            migrationBuilder.DropForeignKey(
                name: "FK_StockItems_StockType_TypeId",
                table: "StockItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StockType",
                table: "StockType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "StockType",
                newName: "StockTypes");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "StockOrders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockTypes",
                table: "StockTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockOrders",
                table: "StockOrders",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "StockEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Change = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventType = table.Column<int>(type: "int", nullable: false),
                    StockItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockEvents", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_StockItems_StockOrders_StockOrderId",
                table: "StockItems",
                column: "StockOrderId",
                principalTable: "StockOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StockItems_StockTypes_TypeId",
                table: "StockItems",
                column: "TypeId",
                principalTable: "StockTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockItems_StockOrders_StockOrderId",
                table: "StockItems");

            migrationBuilder.DropForeignKey(
                name: "FK_StockItems_StockTypes_TypeId",
                table: "StockItems");

            migrationBuilder.DropTable(
                name: "StockEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StockTypes",
                table: "StockTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StockOrders",
                table: "StockOrders");

            migrationBuilder.RenameTable(
                name: "StockTypes",
                newName: "StockType");

            migrationBuilder.RenameTable(
                name: "StockOrders",
                newName: "Orders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockType",
                table: "StockType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StockItems_Orders_StockOrderId",
                table: "StockItems",
                column: "StockOrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StockItems_StockType_TypeId",
                table: "StockItems",
                column: "TypeId",
                principalTable: "StockType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
