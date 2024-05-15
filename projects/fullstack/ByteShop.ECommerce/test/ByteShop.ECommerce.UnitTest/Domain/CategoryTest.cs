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

    [Fact]
    public void ShouldThrowExceptionWhenNameIsNullOrEmpty()
    {
        Action actEmpty = () => new Category(string.Empty);
        Action actNull = () => new Category(null);

        Assert.Throws<Exception>(actEmpty).Equals("Name is required");
        Assert.Throws<Exception>(actNull).Equals("Name is required");
    }

    [Fact]
    public void ShouldThrowExceptionWhenNameLengthIsLessThanThree()
    {
        Action act = () => new Category("A");

        Assert.Throws<Exception>(act).Equals("Name must have at least 3 characters");
    }
}
