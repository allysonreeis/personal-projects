using ByteShop.ECommerce.Api.Categories;
using ByteShop.ECommerce.Application.CategoryUseCases;
using ByteShop.ECommerce.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ByteShop.ECommerce.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryController(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CategoryRequest request, CancellationToken cancellationToken)
    {
        var createCategory = new CreateCategory(_categoryRepository);
        await createCategory.Handle(new CreateCategoryInput(request.Name), cancellationToken);

        //TODO: See how to return the created category
        return Ok();
    }
}
