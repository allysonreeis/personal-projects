using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteShop.ECommerce.Domain.Entities;
public class OrderItem
{
    public Guid Id { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public decimal Total { get; set; }

    public OrderItem(Product product, int quantity)
    {
        Id = Guid.NewGuid();
        Product = product;
        Quantity = quantity;
        Total = product.Price * quantity;
    }
}
