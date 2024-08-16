namespace ByteShop.ECommerce.Domain.Entities;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public Category Category { get; set; }
    public int Quantity { get; private set; }

    public Product(string name, decimal price, string description, Category category)
    {
        Id = Guid.NewGuid();
        Name = name;
        Price = price;
        Description = description;
        Category = category;
        Validate();
    }

    public Product(string name, decimal price, string description, Category category, int quantity)
    {
        Id = Guid.NewGuid();
        Name = name;
        Price = price;
        Description = description;
        Category = category;
        Quantity = quantity;
        Validate();
    }

    public void Validate()
    {
        if (string.IsNullOrWhiteSpace(Name))
        {
            throw new Exception("Name is required");
        }
        if (Price <= 0)
        {
            throw new Exception("Price must be greater than zero");
        }
    }

    public void AddQuantity(int quantity)
    {
        if (quantity <= 0)
        {
            throw new Exception("Quantity must be greater than zero");
        }
        Quantity += quantity;
    }
}
