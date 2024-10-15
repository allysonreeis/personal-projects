using ByteShop.ECommerce.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteShop.ECommerce.Application.ProductUseCases.Get;
public class GetProduct
{
    private readonly IProductRepository _productRepository;

    public GetProduct(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<GetProductOutput> Handle(Guid id, CancellationToken cancellationToken)
    {
        var product = await _productRepository.Get(id, cancellationToken);
        return new GetProductOutput(product.Id, product.Name, product.Price, product.Quantity, product.Category);
    }
}
