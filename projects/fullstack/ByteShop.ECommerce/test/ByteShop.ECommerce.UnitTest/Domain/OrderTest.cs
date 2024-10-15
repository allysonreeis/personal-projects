using ByteShop.ECommerce.Domain.Entities;

namespace ByteShop.ECommerce.UnitTest.Domain;
public class OrderTest
{
    [Fact]
    public void ShouldNotInstantiateOrder()
    {
        var customerId = Guid.NewGuid();
        var items = new List<OrderItem>();
        var order = new Order(customerId, items);
        Assert.NotEqual(Guid.Empty, order.Id);
        Assert.NotEqual(DateTime.MinValue, order.CreatedAtUTC);
        Assert.NotNull(order.Items);
        Assert.Empty(order.Items);
        Assert.Equal(0, order.Total);
    }

    [Fact]
    public void ShouldInstantiateOrder()
    {
        var category = new Category("Category 1");
        var product1 = new Product("Product 1", 10.0m, "Product 1 description", 1, category.Id);
        var product2 = new Product("Product 2", 10.0m, "Product 2 description", 1, category.Id);
        var customerId = Guid.NewGuid();

        var items = new List<OrderItem>();
        var order = new Order(customerId, items);
        var orderItem1 = new OrderItem(product1.Id, order.Id, 1, product1.Price);
        var orderItem2 = new OrderItem(product2.Id, order.Id, 1, product2.Price);
        order.AddItem(orderItem1);
        order.AddItem(orderItem2);

        Assert.Equal(2, order.Items.Count);
        Assert.Equal(orderItem1, order.Items[0]);
        Assert.Equal(orderItem1.Total + orderItem2.Total, order.Total);
    }
}
