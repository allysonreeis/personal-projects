using ByteShop.ECommerce.Domain.Entities;

namespace ByteShop.ECommerce.Domain.Interfaces;
public interface ICategoryRepository
{
    public Task Insert(Category category, CancellationToken cancellationToken);
}
