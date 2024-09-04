using ByteShop.ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteShop.ECommerce.Infra.Mappings;
public class ProductMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(e => e.Price)
            .HasColumnType("decimal(10,2)")
            .IsRequired();
        builder.Property(e => e.Description)
            .HasMaxLength(500)
            .IsRequired();
        builder.Property(e => e.Quantity)
            .IsRequired();
        builder.HasOne(e => e.Category)
            .WithMany()
            .HasForeignKey(e => e.CategoryId);
    }
}
