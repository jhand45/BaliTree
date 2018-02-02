using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BaliTree.Migrations
{
    public partial class addeventtoitem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_StockEvents_StockItemId",
                table: "StockEvents",
                column: "StockItemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StockEvents_StockItems_StockItemId",
                table: "StockEvents",
                column: "StockItemId",
                principalTable: "StockItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockEvents_StockItems_StockItemId",
                table: "StockEvents");

            migrationBuilder.DropIndex(
                name: "IX_StockEvents_StockItemId",
                table: "StockEvents");
        }
    }
}
