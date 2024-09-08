using ByteShop.ECommerce.Domain.Entities;
using ByteShop.ECommerce.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ByteShop.ECommerce.Infra.Repositories;
internal class ProductRepository : IProductRepository
{
    private readonly ByteShopDbContext _context;

    public ProductRepository(ByteShopDbContext context)
    {
        _context = context;
    }

    public async Task Delete(Guid productId, CancellationToken cancellationToken)
    {
        var product = await _context.Products
            .FindAsync(productId);
        if (product == null)
        {
            throw new Exception("Product not found");
        }
        _context.Products.Remove(product);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Product> Get(Guid productId, CancellationToken cancellationToken)
    {
        var product = await _context.Products
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Id == productId, cancellationToken);

        if (product == null)
        {
            throw new Exception("Product not found");
        }
        return product;
    }

    public async Task<IEnumerable<Product>> Get(CancellationToken cancellationToken)
    {
        return await _context.Products
            .Include(p => p.Category)
            .ToListAsync(cancellationToken);
    }

    public async Task Insert(Product product, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(product);
        await _context.Products.AddAsync(product, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
