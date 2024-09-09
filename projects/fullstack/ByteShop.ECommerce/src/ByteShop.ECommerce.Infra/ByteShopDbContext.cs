using ByteShop.ECommerce.Domain.Entities;
using ByteShop.ECommerce.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace ByteShop.ECommerce.Infra;
public class ByteShopDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    public ByteShopDbContext(DbContextOptions<ByteShopDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoryMap());
        modelBuilder.ApplyConfiguration(new ProductMap());
        modelBuilder.ApplyConfiguration(new OrderMap());
        modelBuilder.ApplyConfiguration(new OrderItemMap());
    }
}
