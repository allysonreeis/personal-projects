using ByteShop.ECommerce.Application.CategoryUseCases.Create;
using ByteShop.ECommerce.Application.ProductUseCases.Create;
using ByteShop.ECommerce.Application.ProductUseCases.Get;
using ByteShop.ECommerce.Application.ProductUseCases.List;
using ByteShop.ECommerce.Domain.Entities;
using ByteShop.ECommerce.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteShop.ECommerce.UnitTest.Application.ProductTests.GetProductUseCaseTest;
public class GetProductTest
{
    [Fact]
    public async Task ShouldGetProductById()
    {
        var productRepositoryMock = new Mock<IProductRepository>();
        var categoryRepositoryMock = new Mock<ICategoryRepository>();

        var category = new Category("Category 1");
        var createProduct = new CreateProduct(productRepositoryMock.Object, categoryRepositoryMock.Object);
        var createProductInput = new CreateProductInput("Product 1", 10.00m, "Description", category.Id, 5);
        var getProduct = new GetProduct(productRepositoryMock.Object);

        productRepositoryMock.Setup(repository => repository.Get(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Product(createProductInput.Name, createProductInput.Price, createProductInput.Description, createProductInput.Quantity, createProductInput.CategoryId) { Category = category });

        categoryRepositoryMock.Setup(repository => repository.Get(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(category);

        var createProductOutput = await createProduct.Handle(createProductInput, CancellationToken.None);
        var getProductOutput = await getProduct.Handle(createProductOutput.Id, CancellationToken.None);

        categoryRepositoryMock.Verify(repository => repository.Get(It.IsAny<Guid>(), It.IsAny<CancellationToken>()), Times.Once);
        productRepositoryMock.Verify(repository => repository.Insert(It.IsAny<Product>(), It.IsAny<CancellationToken>()), Times.Once);
        Assert.NotNull(createProductOutput);
        Assert.NotNull(createProductOutput.Category);
        Assert.Equal(category.Id, createProductOutput.Category.Id);
        Assert.Equal(createProductInput.Quantity, getProductOutput.Quantity);
    }

    [Fact]
    public async Task ShouldGetAllProducts()
    {
        var productRepositoryMock = new Mock<IProductRepository>();
        var listProducts = new ListProducts(productRepositoryMock.Object);

        productRepositoryMock.Setup(repository => repository.Get(It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<Product>
            {
                new Product("Product 1", 10.00m, "Description", 5, Guid.NewGuid()),
                new Product("Product 2", 20.00m, "Description", 10, Guid.NewGuid())
            });

        var listProductsOutput = await listProducts.Handle(CancellationToken.None);

        productRepositoryMock.Verify(repository => repository.Get(It.IsAny<CancellationToken>()), Times.Once);
        Assert.NotNull(listProductsOutput);
        Assert.NotEmpty(listProductsOutput);
        Assert.Equal(2, listProductsOutput.Count());
        Assert.Equal(5, listProductsOutput.ElementAt(0).Quantity);
        Assert.Equal(10, listProductsOutput.ElementAt(1).Quantity);
    }
}
