using ByteShop.ECommerce.Domain.Entities;
using ByteShop.ECommerce.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ByteShop.ECommerce.Infra.Repositories;
public class CategoryRepository : ICategoryRepository
{
    private readonly ByteShopDbContext _context;

    public CategoryRepository(ByteShopDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Category>> GetCategories(CancellationToken cancellationToken)
    {
        return await _context.Categories.ToListAsync(cancellationToken);
    }

    public async Task Insert(Category category, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(category);

        await _context.Categories.AddAsync(category, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
