using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryManager.Infra.Repositories.Configurations
{
    class ProductConfiguration : IEntityTypeConfiguration<Domain.Entities.Product>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Product> builder)
        {


            builder.OwnsOne(o =>o.Price).Property(o =>o.Amount).HasColumnName("Amount");
            builder.OwnsOne(o => o.Price).OwnsOne(o => o.Currency).Property(o => o.Name).HasColumnName("CurrencyName");
            builder.OwnsOne(o => o.Price).OwnsOne(o => o.Currency).Property(o => o.Symbol).HasColumnName("CurrencySymbol");

            //builder.OwnsOne(o => o.Price).Property(o => o.Currency.Symbol).HasColumnName("CurrencySymbol");

            //builder
            //.Property(b => b.ClientAddress)
            //.HasField("_clientAddress");

            //builder.Metadata
            //.FindNavigation("ClientAddress")
            //.SetPropertyAccessMode(PropertyAccessMode.Field);


        }
    }
}
