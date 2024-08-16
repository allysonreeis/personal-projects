using ByteShop.ECommerce.Domain.Entities;
using ByteShop.ECommerce.Domain.Interfaces;

namespace ByteShop.ECommerce.Application.ProductUseCases.Create;
public class CreateProduct
{
    private readonly IProductRepository _productRepository;

    public CreateProduct(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<CreateProductOutput> Handle(CreateProductInput createProductInput, CancellationToken cancellationToken)
    {
        var product = new Product(createProductInput.Name, createProductInput.Price, createProductInput.Description, createProductInput.Category, createProductInput.Quantity);
        await _productRepository.Insert(product, cancellationToken);
        return new CreateProductOutput(product.Id, product.Name, product.Price, product.Category);
    }
}
