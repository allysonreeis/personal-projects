﻿using ByteShop.ECommerce.Domain.Entities;
using ByteShop.ECommerce.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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

    public async Task<OrderOutput> Handle(CreateOrderInput orderInput, CancellationToken cancellationToken)
    {
        // 1. Validate if the customer exists
        // 2. Get all products from the order
        // Validate if the products exists and if the quantity is available
        Dictionary<Guid, Product> productsDict = new();
        foreach (var item in orderInput.Items)
        {
            var product = await _productRepository.Get(item.ProductId, cancellationToken);
            if (product == null || product.Quantity < item.Quantity)
            {
                throw new Exception("Product not available or insufficient stock");
            }
            productsDict.Add(product.Id, product);
        }

        // 3. Update the stock of the products
        foreach (var item in orderInput.Items)
        {
            var product = productsDict[item.ProductId];
            product.RemoveQuantity(item.Quantity);
            await _productRepository.Update(product, cancellationToken);
        }


        // 4. Create the order
        var orderItems = new List<OrderItem>();
        var order = new Order(orderInput.CustomerId, orderItems);

        foreach (var item in orderInput.Items)
        {
            if (productsDict.TryGetValue(item.ProductId, out var product))
            {
                var orderItem = new OrderItem(product.Id, order.Id, item.Quantity, product.Price);
                orderItems.Add(orderItem);
            }
        }

        order.AddItem(orderItems);

        await _orderRepository.Insert(order, cancellationToken);

        var orderOutput = new OrderOutput()
        {
            Id = order.Id,
            CreatedAt = order.CreatedAtUTC,
            Total = order.Total,
            /*Items = productsDict.Select(x => new OrderItemOutput
            {
                Id = Guid.NewGuid(),
                Product = new ProductOutput
                {
                    Id = x.Value.Id,
                    Name = x.Value.Name,
                    Description = x.Value.Description,
                    Price = x.Value.Price
                },
                Quantity = x.Value.Quantity,
                Total = x.Value.Price
            }).ToList()*/

            Items = order.Items.Join(
                productsDict,
                item => item.ProductId,
                product => product.Key,
                (item, product) => new OrderItemOutput
                {
                    Id = item.Id,
                    Product = new ProductOutput
                    {
                        Id = product.Value.Id,
                        Name = product.Value.Name,
                        Description = product.Value.Description,
                        Price = product.Value.Price
                    },
                    Quantity = item.Quantity,
                    Total = item.Total
                }
            ).ToList()
        };

        return orderOutput;
    }

}
