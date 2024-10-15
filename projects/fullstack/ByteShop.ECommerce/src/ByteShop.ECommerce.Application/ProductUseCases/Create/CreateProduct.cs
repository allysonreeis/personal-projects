using ByteShop.ECommerce.Domain.Entities;
using ByteShop.ECommerce.Domain.Interfaces;

namespace ByteShop.ECommerce.Application.ProductUseCases.Create;
public class CreateProduct
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;

    public CreateProduct(IProductRepository productRepository, ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<CreateProductOutput> Handle(CreateProductInput createProductInput, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.Get(createProductInput.CategoryId, cancellationToken);
        var product = new Product(createProductInput.Name, createProductInput.Price, createProductInput.Description, createProductInput.Quantity, createProductInput.CategoryId);
        await _productRepository.Insert(product, cancellationToken);
        return new CreateProductOutput(product.Id, product.Name, product.Price, product.Quantity, category);
    }
}
