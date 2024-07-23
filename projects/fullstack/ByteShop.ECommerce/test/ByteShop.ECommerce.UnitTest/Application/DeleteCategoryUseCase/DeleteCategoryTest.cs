using ByteShop.ECommerce.Application.CategoryUseCases.Create;
using ByteShop.ECommerce.Application.CategoryUseCases.Delete;
using ByteShop.ECommerce.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteShop.ECommerce.UnitTest.Application.DeleteCategoryUseCase;
public class DeleteCategoryTest
{
    [Fact]
    public async Task DeleteCategory()
    {
        // Arrange
        var categoryRepository = new Mock<ICategoryRepository>();

        var createCategory = new CreateCategory(categoryRepository.Object);
        var createCategoryInput = new CreateCategoryInput("Category 1");
        var createCategoryOutput = await createCategory.Handle(createCategoryInput, CancellationToken.None);

        var deleteCategory = new DeleteCategory(categoryRepository.Object);
        var cancellationToken = new CancellationToken();

        // Act
        await deleteCategory.Handle(createCategoryOutput.Id, cancellationToken);

        // Assert
        categoryRepository.Verify(x => x.Delete(createCategoryOutput.Id, cancellationToken), Times.Once);
    }

    [Fact]
    public async Task DeleteCategory_WhenCategoryDoesNotExist()
    {
        // Arrange
        var categoryRepository = new Mock<ICategoryRepository>();

        var deleteCategory = new DeleteCategory(categoryRepository.Object);
        var cancellationToken = new CancellationToken();

        // Act
        await deleteCategory.Handle(Guid.NewGuid(), cancellationToken);

        // Assert
        categoryRepository.Verify(x => x.Delete(It.IsAny<Guid>(), cancellationToken), Times.Once);
    }
}
