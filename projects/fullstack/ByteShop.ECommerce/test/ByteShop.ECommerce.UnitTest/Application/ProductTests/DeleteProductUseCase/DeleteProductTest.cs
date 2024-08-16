using ByteShop.ECommerce.Application.Exceptions;
using ByteShop.ECommerce.Application.ProductUseCases.Create;
using ByteShop.ECommerce.Application.ProductUseCases.Delete;
using ByteShop.ECommerce.Domain.Entities;
using ByteShop.ECommerce.Domain.Interfaces;
using Moq;

namespace ByteShop.ECommerce.UnitTest.Application.ProductTests.DeleteProductUseCase;
public class DeleteProductTest
{
    [Fact]
    public async Task ShouldDeleteAProductAsync()
    {
        var repositoryMock = new Mock<IProductRepository>();

        var deleteProductUseCase = new DeleteProduct(repositoryMock.Object);

        var category = new Category("Category 1");
        var productInput = new CreateProductInput("Product 1", 10.00m, "Description", category, 5);

        var product = new Product(productInput.Name, productInput.Price, productInput.Description, productInput.Category, productInput.Quantity);

        repositoryMock
            .Setup(r => r.Get(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(product);

        await deleteProductUseCase.Handle(product.Id, CancellationToken.None);

        repositoryMock.Verify(repo => repo.Get(It.IsAny<Guid>(), It.IsAny<CancellationToken>()), Times.Once);
        repositoryMock.Verify(repo => repo.Delete(It.IsAny<Product>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async void ShouldThrowNotFoundException_WhenTryDeleteNonExistingProduct()
    {
        var repositoryMock = new Mock<IProductRepository>();
        var productId = Guid.NewGuid();

        var deleteProductUseCase = new DeleteProduct(repositoryMock.Object);

        repositoryMock
            .Setup(r => r.Get(productId, It.IsAny<CancellationToken>()))
            .ThrowsAsync(new NotFoundException($"Product '{productId}' not found."));

        Func<Task> action = async () => await deleteProductUseCase.Handle(productId, CancellationToken.None);

        var exception = await Assert.ThrowsAsync<NotFoundException>(action);

        Assert.Equal($"Product '{productId}' not found.", exception.Message);
        repositoryMock.Verify(repo => repo.Get(It.IsAny<Guid>(), It.IsAny<CancellationToken>()), Times.Once);
        repositoryMock.Verify(repo => repo.Delete(It.IsAny<Product>(), It.IsAny<CancellationToken>()), Times.Never);
    }
}
