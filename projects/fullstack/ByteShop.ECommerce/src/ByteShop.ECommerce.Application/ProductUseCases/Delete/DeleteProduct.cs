using ByteShop.ECommerce.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        var product = await _productRepository.Get(productId, cancellationToken);
        await _productRepository.Delete(product, cancellationToken);
    }
}
