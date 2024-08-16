namespace ByteShop.ECommerce.Application.CategoryUseCases.Create;
public class CreateCategoryInput
{
    public CreateCategoryInput(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}
