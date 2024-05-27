namespace ByteShop.ECommerce.Application.CategoryUseCases.List;
public class ListCategoriesOutput
{
    public Guid Id { get; }
    public string Name { get; }
    public DateTime CreatedAtUTC { get; }

    public ListCategoriesOutput(Guid id, string name, DateTime createdAtUTC)
    {
        Id = id;
        Name = name;
        CreatedAtUTC = createdAtUTC;
    }
}
