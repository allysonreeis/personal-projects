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
        if (string.IsNullOrWhiteSpace(Name))
        {
            throw new Exception("Name is required");
        }
        if (Name.Length < 3)
        {
            throw new Exception("Name must have at least 3 characters");
        }
    }
}
