﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace WebApplication1.Data.Migrations
{
    [DbContext(typeof(CatalogDbContext))]
    partial class CatalogDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.25");

            modelBuilder.Entity("Catalog", b =>
                {
                    b.Property<int>("CatalogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CatalogId1")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("ParentCatalogId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CatalogId");

                    b.HasIndex("CatalogId1");

                    b.ToTable("Catalogs");
                });

            modelBuilder.Entity("Catalog", b =>
                {
                    b.HasOne("Catalog", null)
                        .WithMany("ChildCatalogs")
                        .HasForeignKey("CatalogId1");
                });

            modelBuilder.Entity("Catalog", b =>
                {
                    b.Navigation("ChildCatalogs");
                });
#pragma warning restore 612, 618
        }
    }
}
