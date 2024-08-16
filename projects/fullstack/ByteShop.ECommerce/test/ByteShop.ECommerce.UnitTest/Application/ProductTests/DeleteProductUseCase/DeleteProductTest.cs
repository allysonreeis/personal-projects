using ByteShop.ECommerce.Application.ProductUseCases.Create;
using ByteShop.ECommerce.Application.ProductUseCases.Delete;
using ByteShop.ECommerce.Domain.Entities;
using ByteShop.ECommerce.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
