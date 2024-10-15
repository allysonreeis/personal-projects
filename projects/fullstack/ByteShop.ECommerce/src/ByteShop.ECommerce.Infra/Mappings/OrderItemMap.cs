using ByteShop.ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ByteShop.ECommerce.Infra.Mappings;

public class OrderItemMap : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(e => e.Id);

        builder.HasOne(e => e.Product)
            .WithMany()
            .HasForeignKey(e => e.ProductId);

        builder.HasOne<Order>()
            .WithMany()
            .HasForeignKey(e => e.OrderId);

        builder.Property(e => e.Quantity)
            .IsRequired();
        builder.Property(e => e.UnitPrice)
            .HasColumnType("decimal(10,2)")
            .IsRequired();

    }

}