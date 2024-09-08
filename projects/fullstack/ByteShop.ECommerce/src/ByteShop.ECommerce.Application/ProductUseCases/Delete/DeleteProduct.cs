using ByteShop.ECommerce.Domain.Interfaces;

namespace ByteShop.ECommerce.Application.ProductUseCases.Delete;
public class DeleteProduct
{
    private readonly IProductRepository _productRepository;

    public DeleteProduct(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task Handle(Guid productId, CancellationToken cancellationToken)
    {
        await _productRepository.Delete(productId, cancellationToken);
    }
}
