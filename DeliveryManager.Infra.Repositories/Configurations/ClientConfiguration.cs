using DeliveryManager.Domain.Entities;
using DeliveryManager.Domain.ValueObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryManager.Infra.Repositories.Configurations
{
    class ClientConfiguration : IEntityTypeConfiguration<Domain.Entities.Client>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Client> builder)
        {


            builder
            .HasMany(e => e.ClientAddress)
            .WithOne(c => c.Client)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

            //builder
            //.Property(b => b.ClientAddress)
            //.HasField("_clientAddress");

            //builder.Metadata
            //.FindNavigation("ClientAddress")
            //.SetPropertyAccessMode(PropertyAccessMode.Field);


        }
    }
}
