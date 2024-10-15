using ByteShop.ECommerce.Domain.Entities;
using System.Reflection;

namespace ByteShop.ECommerce.Application.ProductUseCases.Create;
public class CreateProductOutput
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public Category Category { get; set; }

    public CreateProductOutput(Guid id, string name, decimal price, int quantity, Category category)
    {
        Id = id;
        Name = name;
        Price = price;
        Quantity = quantity;
        Category = category;
    }
}
