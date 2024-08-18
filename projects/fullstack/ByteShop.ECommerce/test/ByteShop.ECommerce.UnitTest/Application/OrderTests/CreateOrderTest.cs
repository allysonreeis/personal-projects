using ByteShop.ECommerce.Application.OrderUseCases.Create;
using ByteShop.ECommerce.Domain.Entities;
using ByteShop.ECommerce.Domain.Interfaces;
using Moq;

namespace ByteShop.ECommerce.UnitTest.Application.OrderTests;
public class CreateOrderTest
{
    [Fact]
    public async void ShouldCreateOrder()
    {
        var category = new Category("Category 1");
        var product1 = new Product("Product 1", 10, "description", category, 10);
        var product2 = new Product("Product 2", 20, "description", category, 10);

        var itemsInput = new List<OrderItemInput> {
            new OrderItemInput { ProductId = product1.Id, Quantity = 1 },
            new OrderItemInput { ProductId = product2.Id, Quantity = 2 }
        };

        var orderInput = new OrderInput
        {
            Items = itemsInput
        };

        var orderRepository = new Mock<IOrderRepository>();
        var productRepository = new Mock<IProductRepository>();

        orderRepository.Setup(x => x.Insert(It.IsAny<Order>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Order(new List<OrderItem> { new OrderItem(product1, 1), new OrderItem(product2, 2) }));

        productRepository.Setup(x => x.Get(product1.Id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(product1);
        productRepository.Setup(x => x.Get(product2.Id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(product2);

        var createOrder = new CreateOrder(orderRepository.Object, productRepository.Object);

        var createOrderOutput = await createOrder.Handle(orderInput, CancellationToken.None);

        orderRepository.Verify(x => x.Insert(It.IsAny<Order>(), It.IsAny<CancellationToken>()), Times.Once);
        Assert.NotNull(createOrderOutput);
        Assert.NotEqual(Guid.Empty, createOrderOutput.Id);
        Assert.Equal(2, createOrderOutput.Items.Count);
        Assert.Equal(50, createOrderOutput.Total);
    }

    [Fact]
    public async void ShouldNotCreateOrderWithInvalidQuantity()
    {
        var category = new Category("Category 1");
        var product1 = new Product("Product 1", 10, "description", category, 1);
        var product2 = new Product("Product 2", 10, "description", category, 1);

        var itemsInput = new List<OrderItemInput> {
            new OrderItemInput { ProductId = product1.Id, Quantity = 1 },
            new OrderItemInput { ProductId = product2.Id, Quantity = 2 }
        };

        var orderInput = new OrderInput
        {
            Items = itemsInput
        };

        var orderRepository = new Mock<IOrderRepository>();
        var productRepository = new Mock<IProductRepository>();

        orderRepository.Setup(x => x.Insert(It.IsAny<Order>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Order(new List<OrderItem> { new OrderItem(product1, 1), new OrderItem(product2, 2) }));

        productRepository.Setup(x => x.Get(product1.Id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(product1);
        productRepository.Setup(x => x.Get(product2.Id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(product2);

        var createOrder = new CreateOrder(orderRepository.Object, productRepository.Object);

        Func<Task<OrderOutput>> orderOutput = async () => await createOrder.Handle(orderInput, CancellationToken.None);
        var exception = await Assert.ThrowsAsync<Exception>(orderOutput);
        Assert.Equal("Quantity is not enough", exception.Message);
    }
}
