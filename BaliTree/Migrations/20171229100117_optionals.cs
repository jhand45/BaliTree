using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BaliTree.Migrations
{
    public partial class optionals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockEvents_StockItems_StockItemId",
                table: "StockEvents");

            migrationBuilder.DropIndex(
                name: "IX_StockEvents_StockItemId",
                table: "StockEvents");

            migrationBuilder.AlterColumn<decimal>(
                name: "RRP",
                table: "StockTypes",
                type: "decimal(18, 2)",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "AverageCost",
                table: "StockTypes",
                type: "decimal(18, 2)",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<int>(
                name: "StockItemId",
                table: "StockEvents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_StockEvents_StockItemId",
                table: "StockEvents",
                column: "StockItemId",
                unique: true,
                filter: "[StockItemId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_StockEvents_StockItems_StockItemId",
                table: "StockEvents",
                column: "StockItemId",
                principalTable: "StockItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockEvents_StockItems_StockItemId",
                table: "StockEvents");

            migrationBuilder.DropIndex(
                name: "IX_StockEvents_StockItemId",
                table: "StockEvents");

            migrationBuilder.AlterColumn<decimal>(
                name: "RRP",
                table: "StockTypes",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "AverageCost",
                table: "StockTypes",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StockItemId",
                table: "StockEvents",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
