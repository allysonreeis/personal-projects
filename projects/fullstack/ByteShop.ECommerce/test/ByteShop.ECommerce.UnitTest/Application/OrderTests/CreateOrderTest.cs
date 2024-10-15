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
        var product1 = new Product("Product 1", 10, "description", 10, category.Id) { Category = category };
        var product2 = new Product("Product 2", 20, "description", 10, category.Id) { Category = category };
        var customerId = Guid.NewGuid();

        var itemsInput = new List<OrderItemInput> {
            new OrderItemInput { ProductId = product1.Id, Quantity = 1 },
            new OrderItemInput { ProductId = product2.Id, Quantity = 2 }
        };

        var orderInput = new CreateOrderInput(customerId, itemsInput);

        var orderRepository = new Mock<IOrderRepository>();
        var productRepository = new Mock<IProductRepository>();
        var categoryRepository = new Mock<ICategoryRepository>();

        var listOrderItems = new List<OrderItem>();
        var order = new Order(customerId, listOrderItems);
        listOrderItems.Add(new OrderItem(product1.Id, order.Id, 1, product1.Price) { Product = product1 });
        listOrderItems.Add(new OrderItem(product2.Id, order.Id, 1, product2.Price) { Product = product2 });

        order.AddItem(listOrderItems[0]);
        order.AddItem(listOrderItems[1]);

        orderRepository.Setup(x => x.Insert(It.IsAny<Order>(), It.IsAny<CancellationToken>()));
        categoryRepository.Setup(x => x.Get(category.Id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(category);
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
        Assert.Equal(orderInput.Items[0].Quantity, createOrderOutput.Items[0].Quantity);
        Assert.Equal(orderInput.Items[1].Quantity, createOrderOutput.Items[1].Quantity);
    }

    [Fact]
    public async void ShouldNotCreateOrderWithInvalidQuantity()
    {
        var category = new Category("Category 1");
        var product1 = new Product("Product 1", 10, "description", 1, category.Id);
        var product2 = new Product("Product 2", 10, "description", 1, category.Id);
        var customerId = Guid.NewGuid();


        var itemsInput = new List<OrderItemInput> {
            new OrderItemInput { ProductId = product1.Id, Quantity = 1 },
            new OrderItemInput { ProductId = product2.Id, Quantity = 2 }
        };

        var orderInput = new CreateOrderInput(customerId, itemsInput);

        var orderRepository = new Mock<IOrderRepository>();
        var productRepository = new Mock<IProductRepository>();

        orderRepository.Setup(x => x.Insert(It.IsAny<Order>(), It.IsAny<CancellationToken>()));

        productRepository.Setup(x => x.Get(product1.Id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(product1);
        productRepository.Setup(x => x.Get(product2.Id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(product2);

        var createOrder = new CreateOrder(orderRepository.Object, productRepository.Object);

        Func<Task<OrderOutput>> orderOutput = async () => await createOrder.Handle(orderInput, CancellationToken.None);
        var exception = await Assert.ThrowsAsync<Exception>(orderOutput);
        Assert.Equal("Product not available or insufficient stock", exception.Message);
    }
}
