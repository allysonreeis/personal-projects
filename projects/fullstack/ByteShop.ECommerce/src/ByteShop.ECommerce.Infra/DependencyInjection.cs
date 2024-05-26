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
            options.UseSqlServer("Server=mssql,1433;Database=BYTESHOP;User=sa;Password=yourStrong(!)Password;");
        });
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        return services;
    }
}
