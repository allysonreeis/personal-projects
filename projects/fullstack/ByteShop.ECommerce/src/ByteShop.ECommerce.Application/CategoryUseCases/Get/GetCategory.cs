using ByteShop.ECommerce.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteShop.ECommerce.Application.CategoryUseCases.Get;
public class GetCategory
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategory(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<GetCategoryOutput> Handle(Guid id, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.Get(id, cancellationToken);
        return new GetCategoryOutput(category.Id, category.Name, category.CreatedAtUTC);
    }
}
