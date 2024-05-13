using ByteShop.ECommerce.Domain.Entities;

namespace ByteShop.ECommerce.UnitTest.Domain;

public class CategoryTest
{
    [Fact]
    public void ShouldInstantiateCategory()
    {
        // Arrange
        var name = "Category 1";

        // Act
        var category = new Category(name);

        // Assert
        Assert.Equal(name, category.Name);
    }
}
