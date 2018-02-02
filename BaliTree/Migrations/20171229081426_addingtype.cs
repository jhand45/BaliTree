using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BaliTree.Migrations
{
    public partial class addingtype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockEvent");

            migrationBuilder.DropColumn(
                name: "AmountPaid",
                table: "StockItems");

            migrationBuilder.DropColumn(
                name: "CurrentStock",
                table: "StockItems");

            migrationBuilder.DropColumn(
                name: "RRP",
                table: "StockItems");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "StockItems");

            migrationBuilder.AddColumn<int>(
                name: "AmountRecieved",
                table: "StockItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "CostPrice",
                table: "StockItems",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "StockItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "StockItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StockType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AverageCost = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    InStock = table.Column<int>(type: "int", nullable: false),
                    RRP = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StockItems_TypeId",
                table: "StockItems",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_StockItems_StockType_TypeId",
                table: "StockItems",
                column: "TypeId",
                principalTable: "StockType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockItems_StockType_TypeId",
                table: "StockItems");

            migrationBuilder.DropTable(
                name: "StockType");

            migrationBuilder.DropIndex(
                name: "IX_StockItems_TypeId",
                table: "StockItems");

            migrationBuilder.DropColumn(
                name: "AmountRecieved",
                table: "StockItems");

            migrationBuilder.DropColumn(
                name: "CostPrice",
                table: "StockItems");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "StockItems");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "StockItems");

            migrationBuilder.AddColumn<decimal>(
                name: "AmountPaid",
                table: "StockItems",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "CurrentStock",
                table: "StockItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "RRP",
                table: "StockItems",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "StockItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StockEvent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Change = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    EventType = table.Column<int>(nullable: false),
                    StockItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockEvent_StockItems_StockItemId",
                        column: x => x.StockItemId,
                        principalTable: "StockItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StockEvent_StockItemId",
                table: "StockEvent",
                column: "StockItemId");
        }
    }
}
