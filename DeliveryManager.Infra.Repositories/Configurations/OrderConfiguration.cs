using DeliveryManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryManager.Infra.Repositories.Configurations
{
    class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
           .HasMany(e => e.OrderItems)
           .WithOne(c => c.Order)
           .IsRequired()
           .OnDelete(DeleteBehavior.Cascade);

            builder.OwnsOne(
                Order => Order.Address,
                addressNavigationBuilder =>
                {
                    // Configures a different table that the entity type maps to when targeting a relational database.
                    addressNavigationBuilder
                        .ToTable("OrderAddress");

                    // Configures the relationship to the owner, and indicates the Foreign Key.
                    //addressNavigationBuilder
                   
                    //    .HasForeignKey("PersonId"); // Shadow Foreign Key

                    // Configure a property of the owned entity type, in this case the to be used as Primary Key
                    //addressNavigationBuilder
                    //    .Property<Guid>("Id"); // Shadow property

                    // Sets the properties that make up the primary key for this owned entity type.
                    //addressNavigationBuilder
                    //    .HasKey("Id"); // Shadow Primary Key

                    // Configures a relationship where the Street is owned by (or part of) Addresses.
                    // In this case, is not used "ToTable();" to maintain the owned and owner in the same table. 
                    //addressNavigationBuilder.OwnsOne(
                    //    address => address.Street,
                    //    streetNavigationBuilder =>
                    //    {
                    //        ...

                    //        // Configures a relationship where the City is owned by (or part of) Street.
                    //        // In this case, is not used "ToTable();" to maintain the owned and owner in the same table. 
                    //        streetNavigationBuilder.OwnsOne(
                    //            street => street.City,
                    //            cityNavigationBuilder =>
                    //            {
                    //                ...
                    //            });
                    //    });
                }
            );

        }
    }
}
