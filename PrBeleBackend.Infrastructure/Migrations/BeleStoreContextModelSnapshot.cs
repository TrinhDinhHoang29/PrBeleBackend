﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PrBeleBackend.Infrastructure.DbContexts;

#nullable disable

namespace PrBeleBackend.Infrastructure.Migrations
{
    [DbContext(typeof(BeleStoreContext))]
    partial class BeleStoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PrBeleBackend.Core.Domain.Entities.AttributeType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("AttributeType", (string)null);
                });

            modelBuilder.Entity("PrBeleBackend.Core.Domain.Entities.AttributeValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AttributeTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AttributeTypeId");

                    b.ToTable("AttributeValue", (string)null);
                });

            modelBuilder.Entity("PrBeleBackend.Core.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReferenceCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("PrBeleBackend.Core.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("BasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionPlainText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Like")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slug")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Thumbnail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("View")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("PrBeleBackend.Core.Domain.Entities.ProductAttributeType", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("AttributeTypeId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "AttributeTypeId");

                    b.HasIndex("AttributeTypeId");

                    b.ToTable("ProductAttributeType", (string)null);
                });

            modelBuilder.Entity("PrBeleBackend.Core.Domain.Entities.Variant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<string>("Thumbnail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Variant", (string)null);
                });

            modelBuilder.Entity("PrBeleBackend.Core.Domain.Entities.VariantAttributeValue", b =>
                {
                    b.Property<int>("VariantId")
                        .HasColumnType("int");

                    b.Property<int>("AttributeValueId")
                        .HasColumnType("int");

                    b.HasKey("VariantId", "AttributeValueId");

                    b.HasIndex("AttributeValueId");

                    b.ToTable("VariantAttributeValue", (string)null);
                });

            modelBuilder.Entity("PrBeleBackend.Core.Domain.Entities.AttributeValue", b =>
                {
                    b.HasOne("PrBeleBackend.Core.Domain.Entities.AttributeType", "AttributeType")
                        .WithMany("AttributeValues")
                        .HasForeignKey("AttributeTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AttributeType");
                });

            modelBuilder.Entity("PrBeleBackend.Core.Domain.Entities.Product", b =>
                {
                    b.HasOne("PrBeleBackend.Core.Domain.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("PrBeleBackend.Core.Domain.Entities.ProductAttributeType", b =>
                {
                    b.HasOne("PrBeleBackend.Core.Domain.Entities.AttributeType", "AttributeType")
                        .WithMany("ProductAttributeTypes")
                        .HasForeignKey("AttributeTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PrBeleBackend.Core.Domain.Entities.Product", "Product")
                        .WithMany("ProductAttributeTypes")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AttributeType");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("PrBeleBackend.Core.Domain.Entities.Variant", b =>
                {
                    b.HasOne("PrBeleBackend.Core.Domain.Entities.Product", "Product")
                        .WithMany("Variants")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("PrBeleBackend.Core.Domain.Entities.VariantAttributeValue", b =>
                {
                    b.HasOne("PrBeleBackend.Core.Domain.Entities.AttributeValue", "AttributeValue")
                        .WithMany("VariantAttributeValues")
                        .HasForeignKey("AttributeValueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PrBeleBackend.Core.Domain.Entities.Variant", "Variant")
                        .WithMany("VariantAttributeValues")
                        .HasForeignKey("VariantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AttributeValue");

                    b.Navigation("Variant");
                });

            modelBuilder.Entity("PrBeleBackend.Core.Domain.Entities.AttributeType", b =>
                {
                    b.Navigation("AttributeValues");

                    b.Navigation("ProductAttributeTypes");
                });

            modelBuilder.Entity("PrBeleBackend.Core.Domain.Entities.AttributeValue", b =>
                {
                    b.Navigation("VariantAttributeValues");
                });

            modelBuilder.Entity("PrBeleBackend.Core.Domain.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("PrBeleBackend.Core.Domain.Entities.Product", b =>
                {
                    b.Navigation("ProductAttributeTypes");

                    b.Navigation("Variants");
                });

            modelBuilder.Entity("PrBeleBackend.Core.Domain.Entities.Variant", b =>
                {
                    b.Navigation("VariantAttributeValues");
                });
#pragma warning restore 612, 618
        }
    }
}
