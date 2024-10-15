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
        var productInput = new CreateProductInput("Product 1", 10.00m, "Description", category.Id, 5);

        var product = new Product(productInput.Name, productInput.Price, productInput.Description, productInput.Quantity, productInput.CategoryId);

        repositoryMock
            .Setup(r => r.Delete(It.IsAny<Guid>(), It.IsAny<CancellationToken>()));

        await deleteProductUseCase.Handle(product.Id, CancellationToken.None);

        repositoryMock.Verify(repo => repo.Delete(It.IsAny<Guid>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async void ShouldThrowNotFoundException_WhenTryDeleteNonExistingProduct()
    {
        var repositoryMock = new Mock<IProductRepository>();
        var productId = Guid.NewGuid();

        var deleteProductUseCase = new DeleteProduct(repositoryMock.Object);

        repositoryMock
            .Setup(r => r.Delete(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception($"Product not found"));

        Func<Task> action = async () => await deleteProductUseCase.Handle(productId, CancellationToken.None);

        var exception = await Assert.ThrowsAsync<Exception>(action);

        Assert.Equal($"Product not found", exception.Message);

        repositoryMock.Verify(repo => repo.Delete(It.IsAny<Guid>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}
