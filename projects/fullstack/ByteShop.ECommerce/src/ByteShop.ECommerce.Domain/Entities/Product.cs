using ByteShop.ECommerce.Domain.Exceptions;

namespace ByteShop.ECommerce.Domain.Entities;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public Guid CategoryId { get; private set; }
    public Category Category { get; set; }
    public int Quantity { get; private set; }

    public Product(string name, decimal price, string description, int quantity, Guid categoryId)
    {
        Id = Guid.NewGuid();
        Name = name;
        Price = price;
        Description = description;
        Quantity = quantity;
        CategoryId = categoryId;
        Validate();
    }

    public void Validate()
    {
        List<string> errors = new List<string>();
        if (string.IsNullOrWhiteSpace(Name))
        {
            errors.Add("Name is required");
        }
        if (Price <= 0)
        {
            errors.Add("Price must be greater than zero");
        }
        if (Quantity < 0)
        {
            errors.Add("Quantity must be greater than zero");
        }

        if (errors.Any())
        {
            throw new DomainValidationException(errors);
        }
    }

    public void AddQuantity(int quantity)
    {
        if (quantity <= 0)
        {
            throw new DomainValidationException("Quantity must be greater than zero");
        }
        Quantity += quantity;
    }

    public void RemoveQuantity(int quantity)
    {
        if (quantity <= 0)
        {
            throw new DomainValidationException("Quantity must be greater than zero");
        }
        if (Quantity < quantity)
        {
            throw new DomainValidationException("Quantity is not enough");
        }
        Quantity -= quantity;
    }
}
