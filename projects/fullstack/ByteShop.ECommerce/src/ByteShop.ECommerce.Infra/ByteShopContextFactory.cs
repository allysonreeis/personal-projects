using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ByteShop.ECommerce.Infra;

public class ByteShopContextFactory : IDesignTimeDbContextFactory<ByteShopDbContext>
{
    public ByteShopDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ByteShopDbContext>();
        optionsBuilder.UseSqlServer("YourConnectionStringHere");

        return new ByteShopDbContext(optionsBuilder.Options);
    }
}
