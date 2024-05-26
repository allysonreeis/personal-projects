using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.Configuration;

namespace ByteShop.ECommerce.Infra;

public class ByteShopContextFactory : IDesignTimeDbContextFactory<ByteShopDbContext>
{
    private readonly IConfiguration _configuration;

    public ByteShopContextFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public ByteShopDbContext CreateDbContext(string[] args)
    {
        var connectionString = _configuration["ConnectionStrings:DefaultConnection"];

        var optionsBuilder = new DbContextOptionsBuilder<ByteShopDbContext>();
        optionsBuilder.UseSqlServer(connectionString);
        //optionsBuilder.UseSqlServer("Server=127.0.0.1,1433;Database=BYTESHOP;User=sa;Password=yourStrong(!)Password;TrustServerCertificate=true;");
        return new ByteShopDbContext(optionsBuilder.Options);
    }
}
