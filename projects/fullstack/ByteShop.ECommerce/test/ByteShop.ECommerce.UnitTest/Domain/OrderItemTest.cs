using ByteShop.ECommerce.Domain.Entities;

namespace ByteShop.ECommerce.UnitTest.Domain;
public class OrderItemTest
{
    [Fact]
    public void ShouldInstantiateOrderItem()
    {
        var category = new Category("Category 1");
        var product = new Product("Product 1", 10.0m, "Product 1 description", 10, category.Id);

        var listOrderItems = new List<OrderItem>();
        var order = new Order(Guid.NewGuid(), listOrderItems);
        var orderItem = new OrderItem(product.Id, order.Id, 10, product.Price);
        order.AddItem(orderItem);

        Assert.NotEqual(Guid.Empty, orderItem.Id);
        Assert.Equal(product.Quantity, orderItem.Quantity);
        Assert.Equal(product.Quantity * product.Price, orderItem.Total);
    }
}
