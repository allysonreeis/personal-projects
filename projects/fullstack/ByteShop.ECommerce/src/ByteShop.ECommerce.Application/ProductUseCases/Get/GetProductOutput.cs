using ByteShop.ECommerce.Domain.Entities;

namespace ByteShop.ECommerce.Application.ProductUseCases.Get;
public class GetProductOutput
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public Category Category { get; set; }

    public GetProductOutput(Guid id, string name, decimal price, int quantity, Category category)
    {
        Id = id;
        Name = name;
        Price = price;
        Quantity = quantity;
        Category = category;
    }
}