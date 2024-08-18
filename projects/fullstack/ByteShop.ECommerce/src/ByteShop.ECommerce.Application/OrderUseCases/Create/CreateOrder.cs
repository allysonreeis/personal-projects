using ByteShop.ECommerce.Domain.Entities;
using ByteShop.ECommerce.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteShop.ECommerce.Application.OrderUseCases.Create;
public class CreateOrder
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;

    public CreateOrder(IOrderRepository orderRepository, IProductRepository productRepository)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
    }

    public async Task<OrderOutput> Handle(OrderInput orderInput, CancellationToken cancellationToken)
    {
        var products = new List<Product>(orderInput.Items.Count);
        foreach (var item in orderInput.Items)
        {
            var product = await _productRepository.Get(item.ProductId, cancellationToken);
            products.Add(product);
        }

        var orderItems = orderInput.Items.Select(x => new OrderItem(products.First(p => p.Id == x.ProductId), x.Quantity)).ToList();

        // Decrease the quantity of the products
        foreach (var item in orderItems)
        {
            item.Product.RemoveQuantity(item.Quantity);
        }

        var order = new Order(orderItems);
        Order orderInserted = await _orderRepository.Insert(order, cancellationToken);
        OrderOutput orderOutput = orderInserted;

        return orderOutput;
    }


}
