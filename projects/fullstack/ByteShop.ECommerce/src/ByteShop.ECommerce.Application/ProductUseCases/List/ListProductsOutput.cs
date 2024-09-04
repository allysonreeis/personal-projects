using ByteShop.ECommerce.Domain.Entities;

namespace ByteShop.ECommerce.Application.ProductUseCases.List;

public class ListProductsOutput
{
    public Guid id { get; set; }
    public string name { get; set; }
    public decimal price { get; set; }
    public Category category { get; set; }

    public ListProductsOutput(Guid id, string name, decimal price, Category category)
    {
        this.id = id;
        this.name = name;
        this.price = price;
        this.category = category;
    }
}