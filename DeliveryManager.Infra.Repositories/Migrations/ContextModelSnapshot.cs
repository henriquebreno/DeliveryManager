﻿// <auto-generated />
using System;
using DeliveryManager.Infra.Repositories.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DeliveryManager.Infra.Repositories.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DeliveryManager.Domain.Entities.Client", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BirthDate");

                    b.Property<string>("Cellphone");

                    b.Property<string>("Cpf");

                    b.Property<string>("Email");

                    b.Property<string>("FullName");

                    b.HasKey("Id");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("DeliveryManager.Domain.Entities.ClientAddress", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City");

                    b.Property<long?>("ClientId")
                        .IsRequired();

                    b.Property<string>("Complement");

                    b.Property<string>("District");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Number");

                    b.Property<string>("State");

                    b.Property<string>("Street");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("ClientAddress");
                });

            modelBuilder.Entity("DeliveryManager.Domain.Entities.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ClientId");

                    b.Property<DateTimeOffset>("OrderDate");

                    b.HasKey("Id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("DeliveryManager.Domain.Entities.OrderItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("OrderId")
                        .IsRequired();

                    b.Property<int>("Units");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("DeliveryManager.Domain.Entities.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("DeliveryManager.Domain.Entities.ProductItemOrdered", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<long>("OrderItemId");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("OrderItemId")
                        .IsUnique();

                    b.ToTable("ProductItemOrdered");
                });

            modelBuilder.Entity("DeliveryManager.Domain.Entities.ClientAddress", b =>
                {
                    b.HasOne("DeliveryManager.Domain.Entities.Client", "Client")
                        .WithMany("ClientAddress")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DeliveryManager.Domain.Entities.Order", b =>
                {
                    b.OwnsOne("DeliveryManager.Domain.ValueObject.Address", "Address", b1 =>
                        {
                            b1.Property<long?>("OrderId");

                            b1.Property<string>("City");

                            b1.Property<string>("Complement");

                            b1.Property<string>("District");

                            b1.Property<string>("Number");

                            b1.Property<string>("State");

                            b1.Property<string>("Street");

                            b1.Property<string>("ZipCode");

                            b1.ToTable("OrderAddress");

                            b1.HasOne("DeliveryManager.Domain.Entities.Order")
                                .WithOne("Address")
                                .HasForeignKey("DeliveryManager.Domain.ValueObject.Address", "OrderId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("DeliveryManager.Domain.Entities.OrderItem", b =>
                {
                    b.HasOne("DeliveryManager.Domain.Entities.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DeliveryManager.Domain.Entities.Product", b =>
                {
                    b.OwnsOne("DeliveryManager.Domain.ValueObject.Money", "Price", b1 =>
                        {
                            b1.Property<long?>("ProductId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<decimal>("Amount")
                                .HasColumnName("Amount")
                                .HasColumnType("decimal(18,2)");

                            b1.ToTable("Product");

                            b1.HasOne("DeliveryManager.Domain.Entities.Product")
                                .WithOne("Price")
                                .HasForeignKey("DeliveryManager.Domain.ValueObject.Money", "ProductId")
                                .OnDelete(DeleteBehavior.Cascade);

                            b1.OwnsOne("DeliveryManager.Domain.ValueObject.Currency", "Currency", b2 =>
                                {
                                    b2.Property<long?>("MoneyProductId")
                                        .ValueGeneratedOnAdd()
                                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                                    b2.Property<string>("Name")
                                        .HasColumnName("CurrencyName");

                                    b2.Property<string>("Symbol")
                                        .HasColumnName("CurrencySymbol");

                                    b2.ToTable("Product");

                                    b2.HasOne("DeliveryManager.Domain.ValueObject.Money")
                                        .WithOne("Currency")
                                        .HasForeignKey("DeliveryManager.Domain.ValueObject.Currency", "MoneyProductId")
                                        .OnDelete(DeleteBehavior.Cascade);
                                });
                        });
                });

            modelBuilder.Entity("DeliveryManager.Domain.Entities.ProductItemOrdered", b =>
                {
                    b.HasOne("DeliveryManager.Domain.Entities.OrderItem", "OrderItem")
                        .WithOne("ProductItemOrdered")
                        .HasForeignKey("DeliveryManager.Domain.Entities.ProductItemOrdered", "OrderItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
