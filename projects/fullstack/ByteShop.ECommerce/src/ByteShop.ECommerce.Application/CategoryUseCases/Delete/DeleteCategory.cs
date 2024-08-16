using ByteShop.ECommerce.Domain.Interfaces;

namespace ByteShop.ECommerce.Application.CategoryUseCases.Delete;
public class DeleteCategory
{
    private readonly ICategoryRepository _categoryRepository;

    public DeleteCategory(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task Handle(Guid id, CancellationToken cancellationToken)
    {
        await _categoryRepository.Delete(id, cancellationToken);
    }
}
