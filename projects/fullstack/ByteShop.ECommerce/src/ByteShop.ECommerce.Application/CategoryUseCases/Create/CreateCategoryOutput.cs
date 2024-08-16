namespace ByteShop.ECommerce.Application.CategoryUseCases.Create;
public class CreateCategoryOutput
{
    public CreateCategoryOutput(Guid id, string name, DateTime createdAtUTC)
    {
        Id = id;
        Name = name;
        CreatedAtUTC = createdAtUTC;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAtUTC { get; }
}
