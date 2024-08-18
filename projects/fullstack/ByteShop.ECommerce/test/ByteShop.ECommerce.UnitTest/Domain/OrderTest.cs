using ByteShop.ECommerce.Domain.Entities;

namespace ByteShop.ECommerce.UnitTest.Domain;
public class OrderTest
{
    [Fact]
    public void ShouldNotInstantiateOrder()
    {
        var items = new List<OrderItem>();
        var order = new Order(items);
        Assert.NotEqual(Guid.Empty, order.Id);
        Assert.NotEqual(DateTime.MinValue, order.CreatedAt);
        Assert.NotNull(order.Items);
        Assert.Empty(order.Items);
        Assert.Equal(0, order.Total);
    }

    [Fact]
    public void ShouldInstantiateOrder()
    {
        var product1 = new Product("Product 1", 10.0m, "Product 1 description", new Category("Category 1"), 1);
        var product2 = new Product("Product 2", 10.0m, "Product 2 description", new Category("Category 1"), 1);

        var items = new List<OrderItem>
        {
            new OrderItem(product1, 1)
        };

        var order = new Order(items);
        var orderItem2 = new OrderItem(product2, 1);

        items.Add(orderItem2);
        order.AddItem(orderItem2);

        Assert.Equal(2, order.Items.Count);
        Assert.Equal(items.First(), order.Items[0]);
        Assert.Equal(items.Sum(x => x.Total), order.Total);
    }
}
