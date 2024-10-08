﻿using ByteShop.ECommerce.Domain.Entities;

namespace ByteShop.ECommerce.UnitTest.Domain;
public class OrderItemTest
{
    [Fact]
    public void ShouldInstantiateOrderItem()
    {
        var product = new Product("Product 1", 10.0m, "Product 1 description", new Category("Category 1"), 10);

        var orderItem = new OrderItem(product, 10);

        Assert.NotEqual(Guid.Empty, orderItem.Id);
        Assert.NotNull(orderItem.Product);
        Assert.Equal(product.Quantity, orderItem.Quantity);
        Assert.Equal(product.Quantity * product.Price, orderItem.Total);
    }
}
