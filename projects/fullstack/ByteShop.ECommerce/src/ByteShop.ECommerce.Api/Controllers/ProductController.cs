using ByteShop.ECommerce.Api.Products;
using ByteShop.ECommerce.Application.CategoryUseCases.Get;
using ByteShop.ECommerce.Application.ProductUseCases.Create;
using ByteShop.ECommerce.Application.ProductUseCases.Delete;
using ByteShop.ECommerce.Application.ProductUseCases.Get;
using ByteShop.ECommerce.Application.ProductUseCases.List;
using ByteShop.ECommerce.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ByteShop.ECommerce.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;

    public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductRequest request, CancellationToken cancellationToken)
    {
        var createProduct = new CreateProduct(_productRepository);
        var getCategory = new GetCategory(_categoryRepository);
        var category = await getCategory.Handle(request.CategoryId, cancellationToken);

        if (category == null) return BadRequest("Category not found");


        var createProductInput = new CreateProductInput(request.Name, request.Price, request.Description, request.CategoryId, request.Quantity);
        var createProductOutput = await createProduct.Handle(createProductInput, cancellationToken);

        return CreatedAtAction(nameof(GetProduct), new { id = createProductOutput.Id }, createProductOutput);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        var getProduct = new GetProduct(_productRepository);
        var product = await getProduct.Handle(id, cancellationToken);
        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var listProducts = new ListProducts(_productRepository);
        var products = await listProducts.Handle(cancellationToken);
        return Ok(products);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var getProduct = new GetProduct(_productRepository);
        var deleteProduct = new DeleteProduct(_productRepository);
        var product = await getProduct.Handle(id, cancellationToken);
        if (product == null)
        {
            return NotFound();
        }

        await deleteProduct.Handle(id, cancellationToken);
        return NoContent();
    }
}
