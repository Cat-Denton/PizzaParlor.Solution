﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaParlor.Models;

namespace PizzaParlor.Migrations
{
    [DbContext(typeof(PizzaParlorContext))]
    [Migration("20210603021040_updateFromRemoteWorkJune2")]
    partial class updateFromRemoteWorkJune2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("PizzaParlor.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ContactInfo")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("PizzaParlor.Models.CustomerOrder", b =>
                {
                    b.Property<int>("CustomerOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("CustomerOrderId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("OrderId");

                    b.ToTable("CustomerOrder");
                });

            modelBuilder.Entity("PizzaParlor.Models.MenuItem", b =>
                {
                    b.Property<int>("MenuItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("IsTopping")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.HasKey("MenuItemId");

                    b.ToTable("MenuItems");
                });

            modelBuilder.Entity("PizzaParlor.Models.MenuItemOrder", b =>
                {
                    b.Property<int>("MenuItemOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("MenuItemId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("MenuItemOrderId");

                    b.HasIndex("MenuItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("MenuItemOrders");
                });

            modelBuilder.Entity("PizzaParlor.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PizzaParlor.Models.CustomerOrder", b =>
                {
                    b.HasOne("PizzaParlor.Models.Customer", "Customer")
                        .WithMany("JoinEntities")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaParlor.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("PizzaParlor.Models.MenuItemOrder", b =>
                {
                    b.HasOne("PizzaParlor.Models.MenuItem", "MenuItem")
                        .WithMany("JoinEntities")
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaParlor.Models.Order", "Order")
                        .WithMany("JoinEntities")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuItem");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("PizzaParlor.Models.Order", b =>
                {
                    b.HasOne("PizzaParlor.Models.Customer", null)
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PizzaParlor.Models.Customer", b =>
                {
                    b.Navigation("JoinEntities");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("PizzaParlor.Models.MenuItem", b =>
                {
                    b.Navigation("JoinEntities");
                });

            modelBuilder.Entity("PizzaParlor.Models.Order", b =>
                {
                    b.Navigation("JoinEntities");
                });
#pragma warning restore 612, 618
        }
    }
}