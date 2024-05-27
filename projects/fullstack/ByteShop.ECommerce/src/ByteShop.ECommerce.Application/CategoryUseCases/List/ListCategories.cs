using ByteShop.ECommerce.Domain.Interfaces;

namespace ByteShop.ECommerce.Application.CategoryUseCases.List;
public class ListCategories
{
    private readonly ICategoryRepository _categoryRepository;

    public ListCategories(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<ListCategoriesOutput>> Handle(CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetCategories(cancellationToken);
        return categories.Select(c => new ListCategoriesOutput(c.Id, c.Name, c.CreatedAtUTC));
    }
}
