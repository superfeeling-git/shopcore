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
    [Migration("20220106032013_initialCreate")]
    partial class initialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

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

                    b.Property<int?>("GoodsCategoryCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("GoodsName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LastModityId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModityTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
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