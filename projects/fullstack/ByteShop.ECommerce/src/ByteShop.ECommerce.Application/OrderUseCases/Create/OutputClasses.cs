using ByteShop.ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteShop.ECommerce.Application.OrderUseCases.Create;
public class OrderItemOutput
{
    public Guid Id { get; set; }
    public ProductOutput Product { get; set; }
    public int Quantity { get; set; }
    public decimal Total { get; set; }

}

public class ProductOutput
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    public static implicit operator ProductOutput(Product product)
    {
        return new ProductOutput
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price
        };
    }
}

public class OrderOutput
{
    public Guid Id { get; set; }
    public List<OrderItemOutput> Items { get; set; } = [];
    public decimal Total { get; set; }
    public DateTime CreatedAt { get; set; }

    public static implicit operator OrderOutput(Order order)
    {
        return new OrderOutput
        {
            Id = order.Id,
            Items = order.Items.Select(x => new OrderItemOutput
            {
                Id = x.Id,
                Product = new ProductOutput
                {
                    Id = x.Product.Id,
                    Name = x.Product.Name,
                    Description = x.Product.Description,
                    Price = x.Product.Price
                },
                Quantity = x.Quantity,
                Total = x.Total
            }).ToList(),
            Total = order.Total,
            CreatedAt = order.CreatedAtUTC
        };
    }
}