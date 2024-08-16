using ByteShop.ECommerce.Domain.Entities;

namespace ByteShop.ECommerce.UnitTest.Domain;
public class OrderTest
{
    [Fact]
    public void ShouldNotInstantiateOrder()
    {
        var order = new Order();
        Assert.NotEqual(Guid.Empty, order.Id);
        Assert.NotEqual(DateTime.MinValue, order.CreatedAt);
        Assert.NotNull(order.Items);
        Assert.Empty(order.Items);
        Assert.Equal(0, order.Total);
    }

    [Fact]
    public void ShouldInstantiateOrder()
    {
        // Arrange
        var order = new Order();
        var product = new Product("Product 1", 10.0m, "Product 1 description", new Category("Category 1"));
        var orderItem = new OrderItem(product, 1);

        // Act
        order.AddItem(orderItem);

        // Assert
        Assert.Single(order.Items);
        Assert.Equal(orderItem, order.Items[0]);
        Assert.Equal(orderItem.Total, order.Total);
    }
}
