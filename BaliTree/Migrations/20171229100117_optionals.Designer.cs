﻿// <auto-generated />
using BaliTreeData;
using BaliTreeData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace BaliTree.Migrations
{
    [DbContext(typeof(BaliTreeContext))]
    [Migration("20171229100117_optionals")]
    partial class optionals
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BaliTreeData.Models.StockEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Change");

                    b.Property<DateTime>("Date");

                    b.Property<int>("EventType");

                    b.Property<int?>("StockItemId");

                    b.HasKey("Id");

                    b.HasIndex("StockItemId")
                        .IsUnique()
                        .HasFilter("[StockItemId] IS NOT NULL");

                    b.ToTable("StockEvents");
                });

            modelBuilder.Entity("BaliTreeData.Models.StockItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AmountRecieved");

                    b.Property<decimal>("CostPrice");

                    b.Property<DateTime>("Date");

                    b.Property<string>("ItemName");

                    b.Property<int?>("StockOrderId");

                    b.Property<int?>("TypeId");

                    b.HasKey("Id");

                    b.HasIndex("StockOrderId");

                    b.HasIndex("TypeId");

                    b.ToTable("StockItems");
                });

            modelBuilder.Entity("BaliTreeData.Models.StockOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.HasKey("Id");

                    b.ToTable("StockOrders");
                });

            modelBuilder.Entity("BaliTreeData.Models.StockType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal?>("AverageCost");

                    b.Property<int>("InStock");

                    b.Property<decimal?>("RRP");

                    b.Property<string>("TypeName");

                    b.HasKey("Id");

                    b.ToTable("StockTypes");
                });

            modelBuilder.Entity("BaliTreeData.Models.StockEvent", b =>
                {
                    b.HasOne("BaliTreeData.Models.StockItem", "StockItem")
                        .WithOne("Event")
                        .HasForeignKey("BaliTreeData.Models.StockEvent", "StockItemId");
                });

            modelBuilder.Entity("BaliTreeData.Models.StockItem", b =>
                {
                    b.HasOne("BaliTreeData.Models.StockOrder")
                        .WithMany("StockItem")
                        .HasForeignKey("StockOrderId");

                    b.HasOne("BaliTreeData.Models.StockType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");
                });
#pragma warning restore 612, 618
        }
    }
}
