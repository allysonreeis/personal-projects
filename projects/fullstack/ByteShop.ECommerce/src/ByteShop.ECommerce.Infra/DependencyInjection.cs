using ByteShop.ECommerce.Domain.Interfaces;
using ByteShop.ECommerce.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ByteShop.ECommerce.Infra;
public static class DependencyInjection
{
    public static IServiceCollection AddInfra(this IServiceCollection services)
    {


        services.AddDbContext<ByteShopDbContext>(options =>
        {
            options.UseInMemoryDatabase("BYTESHOP");
            //options.UseSqlServer("Server=127.0.0.1,1433;Database=BYTESHOP;User=sa;Password=yourStrong(!)Password;TrustServerCertificate=true;");
        });

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        return services;
    }
}
