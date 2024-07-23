using ByteShop.ECommerce.Domain.Entities;

namespace ByteShop.ECommerce.Domain.Interfaces;
public interface ICategoryRepository
{
    Task Insert(Category category, CancellationToken cancellationToken);
    Task<IEnumerable<Category>> GetCategories(CancellationToken cancellationToken);
    Task Delete(Guid id, CancellationToken cancellationToken);

}
