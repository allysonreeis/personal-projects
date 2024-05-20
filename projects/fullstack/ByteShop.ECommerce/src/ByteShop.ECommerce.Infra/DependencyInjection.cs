using ByteShop.ECommerce.Domain.Interfaces;
using ByteShop.ECommerce.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ByteShop.ECommerce.Infra;
public static class DependencyInjection
{
    public static IServiceCollection AddInfra(this IServiceCollection servies)
    {
        servies.AddDbContext<ByteShopDbContext>(options =>
        {
            options.UseSqlServer("Server=mssql,1433;Database=master;User=sa;Password=yourStrong(!)Password;");
        });
        servies.AddScoped<ICategoryRepository, CategoryRepository>();
        return servies;
    }
}
