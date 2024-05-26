using ByteShop.ECommerce.Domain.Entities;
using ByteShop.ECommerce.Domain.Interfaces;

namespace ByteShop.ECommerce.Infra.Repositories;
public class CategoryRepository : ICategoryRepository
{
    private readonly ByteShopDbContext _context;

    public CategoryRepository(ByteShopDbContext context)
    {
        _context = context;
    }

    public async Task Insert(Category category, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(category);

        await _context.Categories.AddAsync(category, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
