namespace ByteShop.ECommerce.Application.CategoryUseCases.Get;

public class GetCategoryOutput
{
    public Guid Id { get; }
    public string Name { get; }
    public DateTime CreatedAtUTC { get; }

    public GetCategoryOutput(Guid id, string name, DateTime createdAtUTC)
    {
        Id = id;
        Name = name;
        CreatedAtUTC = createdAtUTC;
    }
}
