using ByteShop.ECommerce.Api.Categories;
using ByteShop.ECommerce.Application.CategoryUseCases.Create;
using ByteShop.ECommerce.Application.CategoryUseCases.Delete;
using ByteShop.ECommerce.Application.CategoryUseCases.List;
using ByteShop.ECommerce.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ByteShop.ECommerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
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
        var category = await createCategory.Handle(new CreateCategoryInput(request.Name), cancellationToken);

        //TODO: See how to return the created category
        return CreatedAtAction(nameof(Get), new { id = category.Id }, category);
    }

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var listCategories = new ListCategories(_categoryRepository);
        var categories = await listCategories.Handle(cancellationToken);
        return Ok(categories);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var deleteCategory = new DeleteCategory(_categoryRepository);
        await deleteCategory.Handle(id, cancellationToken);
        return NoContent();
    }
}
