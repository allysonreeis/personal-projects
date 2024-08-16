using ByteShop.ECommerce.Application.CategoryUseCases.Create;
using ByteShop.ECommerce.Domain.Entities;
using ByteShop.ECommerce.Domain.Interfaces;
using Moq;

namespace ByteShop.ECommerce.UnitTest.Application.CategoryTests.CreateCategoryUseCase;
public class CreateCategoryTest
{
    [Fact]
    public async void ShouldCreateCategory()
    {
        var repositoryMock = new Mock<ICategoryRepository>();
        var createCategory = new CreateCategory(repositoryMock.Object);
        var createCategoryInput = new CreateCategoryInput("Category 1");
        var createCategoryOutput = await createCategory.Handle(createCategoryInput, CancellationToken.None);

        repositoryMock.Verify(repository => repository.Insert(
                It.IsAny<Category>(),
                It.IsAny<CancellationToken>()),
            Times.Once);

        Assert.NotNull(createCategoryOutput);
        Assert.NotEqual(Guid.Empty, createCategoryOutput.Id);
        Assert.Equal(createCategoryInput.Name, createCategoryOutput.Name);
    }
}
