﻿// <auto-generated />
using System;
using ManicOceanic.DOMAIN.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ManicOceanic.DOMAIN.Migrations
{
    [DbContext(typeof(MOContext))]
    partial class MOContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ManicOceanic.DOMAIN.Entities.Administrator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdminName")
                        .IsRequired();

                    b.Property<bool>("IsLoggedIn");

                    b.Property<string>("Password");

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAlternateKey("AdminName");

                    b.HasAlternateKey("UserName");

                    b.ToTable("Administrators");
                });

            modelBuilder.Entity("ManicOceanic.DOMAIN.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<int>("CustomerNumber");

                    b.Property<string>("EmailAddress");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsLoggedIn");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("SocialSecurityNumber")
                        .IsRequired();

                    b.Property<string>("StreetAddress");

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.HasAlternateKey("CustomerNumber");

                    b.HasAlternateKey("SocialSecurityNumber");

                    b.HasAlternateKey("UserName");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ManicOceanic.DOMAIN.Entities.Products.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ManicOceanic.DOMAIN.Entities.Products.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<string>("Description");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<int>("ProductNumber");

                    b.Property<int>("Stock");

                    b.Property<int>("UnitOfMeasure");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ManicOceanic.DOMAIN.Entities.Sales.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CustomerId");

                    b.Property<string>("CustomerName");

                    b.Property<DateTime>("OrderDate");

                    b.Property<int>("OrderNumber");

                    b.Property<int>("PaymentType");

                    b.Property<int?>("ShippingId");

                    b.Property<decimal>("Tax");

                    b.HasKey("Id");

                    b.HasAlternateKey("OrderNumber");

                    b.HasIndex("ShippingId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ManicOceanic.DOMAIN.Entities.Sales.OrderLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrderId");

                    b.Property<Guid>("ProductId");

                    b.Property<int>("Quantity");

                    b.Property<decimal>("Subtotal");

                    b.Property<decimal>("UnitCost");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderLines");
                });

            modelBuilder.Entity("ManicOceanic.DOMAIN.Entities.Sales.Shipping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Price");

                    b.Property<int>("ShippingType");

                    b.HasKey("Id");

                    b.ToTable("Shippings");
                });

            modelBuilder.Entity("ManicOceanic.DOMAIN.Entities.Products.Category", b =>
                {
                    b.HasOne("ManicOceanic.DOMAIN.Entities.Products.Category")
                        .WithMany("Categories")
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("ManicOceanic.DOMAIN.Entities.Products.Product", b =>
                {
                    b.HasOne("ManicOceanic.DOMAIN.Entities.Products.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ManicOceanic.DOMAIN.Entities.Sales.Order", b =>
                {
                    b.HasOne("ManicOceanic.DOMAIN.Entities.Sales.Shipping", "Shipping")
                        .WithMany()
                        .HasForeignKey("ShippingId");
                });

            modelBuilder.Entity("ManicOceanic.DOMAIN.Entities.Sales.OrderLine", b =>
                {
                    b.HasOne("ManicOceanic.DOMAIN.Entities.Products.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
