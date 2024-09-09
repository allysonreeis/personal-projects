using ByteShop.ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteShop.ECommerce.Infra.Mappings;
public class OrderMap : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.CreatedAtUTC)
            .HasColumnName("Created_At_UTC")
            .IsRequired();

        builder.Property(e => e.Total)
            .HasField("_total")
            .HasColumnType("decimal(10,2)");

        builder.HasMany(e => e.Items)
            .WithOne()
            .HasForeignKey(e => e.Id);

        builder.Property(e => e.CustomerId)
            .IsRequired();

        /*builder.HasOne<Customer>()
            .WithMany()
            .HasForeignKey(e => e.CustomerId);*/
    }
}
