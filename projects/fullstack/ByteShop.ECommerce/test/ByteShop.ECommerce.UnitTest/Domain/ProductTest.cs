﻿using ByteShop.ECommerce.Domain.Entities;

namespace ByteShop.ECommerce.UnitTest.Domain;

public class ProductTest
{
    [Fact]
    public void ShouldInstantiateProduct()
    {
        // Arrange
        var name = "Product 1";
        var price = 10.0m;
        var description = "Product 1 description";
        var category = new Category("Category 1");

        // Act
        var product = new Product(name, price, description, 1, category.Id);

        // Assert
        Assert.Equal(name, product.Name);
        Assert.Equal(price, product.Price);
        Assert.Equal(description, product.Description);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void ShouldNotInstantiateProductWithEmptyName(string? name)
    {
        // Arrange
        var price = 10.0m;
        var description = "Product 1 description";
        var category = new Category("Category 1");

        // Act
        Action act = () => new Product(name, price, description, 1, category.Id);

        // Assert
        var ex = Assert.Throws<Exception>(act);
        Assert.Equal("Name is required", ex.Message);
    }

    [Theory]
    [InlineData(-10.0)]
    [InlineData(0)]
    public void ShouldNotInstantiateWithPriceLessThanZero(decimal price)
    {
        // Arrange
        var name = "Product 1";
        var description = "Product 1 description";
        var category = new Category("Category 1");

        // Act
        Action act = () => new Product(name, price, description, 1, category.Id);

        // Assert
        var ex = Assert.Throws<Exception>(act);
        Assert.Equal("Price must be greater than zero", ex.Message);
    }

    [Fact]
    public void ShouldAddQuantity()
    {
        // Arrange
        var name = "Product 1";
        var price = 10.0m;
        var description = "Product 1 description";
        var category = new Category("Category 1");
        var product = new Product(name, price, description, 10, category.Id);

        // Act
        product.AddQuantity(10);

        // Assert
        Assert.Equal(20, product.Quantity);
    }
}
