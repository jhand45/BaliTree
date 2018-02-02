using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BaliTree.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockItems_Orders_OrderId",
                table: "StockItems");

            migrationBuilder.DropIndex(
                name: "IX_StockItems_OrderId",
                table: "StockItems");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "StockItems");

            migrationBuilder.AddColumn<int>(
                name: "StockOrderId",
                table: "StockItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockItems_StockOrderId",
                table: "StockItems",
                column: "StockOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_StockItems_Orders_StockOrderId",
                table: "StockItems",
                column: "StockOrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockItems_Orders_StockOrderId",
                table: "StockItems");

            migrationBuilder.DropIndex(
                name: "IX_StockItems_StockOrderId",
                table: "StockItems");

            migrationBuilder.DropColumn(
                name: "StockOrderId",
                table: "StockItems");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "StockItems",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockItems_OrderId",
                table: "StockItems",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_StockItems_Orders_OrderId",
                table: "StockItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
