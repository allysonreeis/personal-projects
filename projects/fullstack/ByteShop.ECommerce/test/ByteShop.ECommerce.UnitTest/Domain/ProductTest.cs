using ByteShop.ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        // Act
        var product = new Product(name, price, description);

        // Assert
        Assert.Equal(name, product.Name);
        Assert.Equal(price, product.Price);
        Assert.Equal(description, product.Description);
    }
}
