using ByteShop.ECommerce.Domain.Entities;

namespace ByteShop.ECommerce.Domain.Interfaces;
public interface IProductRepository
{
    Task Insert(Product product, CancellationToken cancellationToken);
    Task<Product> Get(Guid productId, CancellationToken cancellationToken);
    Task<IEnumerable<Product>> Get(CancellationToken cancellationToken);
    Task Delete(Guid productOd, CancellationToken cancellationToken);
}
