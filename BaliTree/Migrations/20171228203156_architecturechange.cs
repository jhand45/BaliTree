using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BaliTree.Migrations
{
    public partial class architecturechange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockItems_Orders_StockOrderId",
                table: "StockItems");

            migrationBuilder.DropIndex(
                name: "IX_StockItems_StockOrderId",
                table: "StockItems");

            migrationBuilder.DropColumn(
                name: "InStock",
                table: "StockItems");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "StockItems");

            migrationBuilder.DropColumn(
                name: "StockOrderId",
                table: "StockItems");

            migrationBuilder.DropColumn(
                name: "NunberOfStockItems",
                table: "Orders");

            migrationBuilder.AddColumn<decimal>(
                name: "AmountPaid",
                table: "StockItems",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "CurrentStock",
                table: "StockItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "StockItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RRP",
                table: "StockItems",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockItems_Orders_OrderId",
                table: "StockItems");

            migrationBuilder.DropIndex(
                name: "IX_StockItems_OrderId",
                table: "StockItems");

            migrationBuilder.DropColumn(
                name: "AmountPaid",
                table: "StockItems");

            migrationBuilder.DropColumn(
                name: "CurrentStock",
                table: "StockItems");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "StockItems");

            migrationBuilder.DropColumn(
                name: "RRP",
                table: "StockItems");

            migrationBuilder.AddColumn<int>(
                name: "InStock",
                table: "StockItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "StockItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StockOrderId",
                table: "StockItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NunberOfStockItems",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

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
    }
}
