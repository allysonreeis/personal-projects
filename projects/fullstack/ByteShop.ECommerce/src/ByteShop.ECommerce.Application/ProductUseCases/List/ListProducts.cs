using ByteShop.ECommerce.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteShop.ECommerce.Application.ProductUseCases.List;
public class ListProducts
{
    private readonly IProductRepository _productRepository;

    public ListProducts(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<ListProductsOutput>> Handle(CancellationToken cancellationToken)
    {
        var products = await _productRepository.Get(cancellationToken);
        return products.Select(p => new ListProductsOutput(p.Id, p.Name, p.Price, p.Quantity, p.Category));
    }
}
