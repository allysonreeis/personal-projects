﻿using ByteShop.ECommerce.Application.ProductUseCases.Create;
using ByteShop.ECommerce.Domain.Entities;
using ByteShop.ECommerce.Domain.Interfaces;
using Moq;

namespace ByteShop.ECommerce.UnitTest.Application.ProductTests.CreateProductUseCase;
public class CreateProductTest
{
    [Fact]
    public async void ShouldCreateProduct()
    {
        var repositoryMock = new Mock<IProductRepository>();
        var categoryRepositoryMock = new Mock<ICategoryRepository>();

        var category = new Category("Category 1");
        var createProduct = new CreateProduct(repositoryMock.Object, categoryRepositoryMock.Object);
        var createProductInput = new CreateProductInput("Product 1", 10.00m, "Description", category.Id, 5);


        var createProductOutput = await createProduct.Handle(createProductInput, CancellationToken.None);


        repositoryMock.Verify(repository => repository.Insert(It.IsAny<Product>(), It.IsAny<CancellationToken>()), Times.Once);

        Assert.NotNull(createProductOutput);
        Assert.NotEqual(Guid.Empty, createProductOutput.Id);
        Assert.Equal(createProductInput.Name, createProductOutput.Name);
        Assert.Equal(createProductInput.Price, createProductOutput.Price);
        Assert.Equal(createProductInput.Quantity, createProductOutput.Quantity);
    }
}
