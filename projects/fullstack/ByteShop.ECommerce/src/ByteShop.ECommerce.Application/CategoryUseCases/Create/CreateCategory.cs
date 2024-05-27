using ByteShop.ECommerce.Domain.Entities;
using ByteShop.ECommerce.Domain.Interfaces;

namespace ByteShop.ECommerce.Application.CategoryUseCases.Create;

public class CreateCategory
{
    private readonly ICategoryRepository _categoryRepository;

    public CreateCategory(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<CreateCategoryOutput> Handle(CreateCategoryInput createCategoryInput, CancellationToken cancellationToken)
    {
        var category = new Category(createCategoryInput.Name);

        await _categoryRepository.Insert(category, cancellationToken);

        return new CreateCategoryOutput(category.Id, category.Name, category.CreatedAtUTC);
    }
}
