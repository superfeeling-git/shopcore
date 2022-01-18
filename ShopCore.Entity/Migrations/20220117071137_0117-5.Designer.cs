﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopCore.Entity;

namespace ShopCore.Entity.Migrations
{
    [DbContext(typeof(ShopCoreContext))]
    [Migration("20220117071137_0117-5")]
    partial class _01175
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("ShopCore.Entity.Cart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BuyCount")
                        .HasColumnType("int");

                    b.Property<int>("SKUID")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CartId");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("ShopCore.Entity.Goods", b =>
                {
                    b.Property<int>("GoodsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("CreateId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GoodsCategoryCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("GoodsImg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GoodsName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LastModityId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModityTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("GoodsId");

                    b.HasIndex("GoodsCategoryCategoryId");

                    b.ToTable("Goods");
                });

            modelBuilder.Entity("ShopCore.Entity.GoodsCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CreateId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LastModityId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModityTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("Remark")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("GoodsCategories");
                });

            modelBuilder.Entity("ShopCore.Entity.SKU", b =>
                {
                    b.Property<int>("SKUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("GoodsId")
                        .HasColumnType("int");

                    b.Property<int>("TasteId")
                        .HasColumnType("int");

                    b.HasKey("SKUID");

                    b.ToTable("SKU");
                });

            modelBuilder.Entity("ShopCore.Entity.ShipAddress", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Area")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Province")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TEL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("AddressId");

                    b.ToTable("ShipAddresses");
                });

            modelBuilder.Entity("ShopCore.Entity.Taste", b =>
                {
                    b.Property<int>("TasteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("TasteName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TasteId");

                    b.ToTable("Tastes");
                });

            modelBuilder.Entity("ShopCore.Entity.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ShopCore.Entity.Goods", b =>
                {
                    b.HasOne("ShopCore.Entity.GoodsCategory", null)
                        .WithMany("Goods")
                        .HasForeignKey("GoodsCategoryCategoryId");
                });

            modelBuilder.Entity("ShopCore.Entity.GoodsCategory", b =>
                {
                    b.Navigation("Goods");
                });
#pragma warning restore 612, 618
        }
    }
}
