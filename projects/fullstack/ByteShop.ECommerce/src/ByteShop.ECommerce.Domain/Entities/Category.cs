using ByteShop.ECommerce.Domain.Exceptions;

namespace ByteShop.ECommerce.Domain.Entities;

public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAtUTC { get; }

    public Category(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        CreatedAtUTC = DateTime.UtcNow;
        Validate();
    }

    private void Validate()
    {
        var errors = new List<string>();
        if (string.IsNullOrWhiteSpace(Name))
            errors.Add("Name is required");

        if (Name.Length < 3)
            errors.Add("Name must have at least 3 characters");

        if (errors.Any())
        {
            throw new DomainValidationException(errors);
        }
    }
}
