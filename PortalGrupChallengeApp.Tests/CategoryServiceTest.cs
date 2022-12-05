using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PortalGrupChallengeApp.API.Controllers;
using PortalGrupChallengeApp.Business.Abstract;
using PortalGrupChallengeApp.Entities.Concrete;
using PortalGrupChallengeApp.Tests.MockData;

namespace PortalGrupChallengeApp.Tests;

public class CategoryServiceTest
{
    private readonly Mock<ICategoryService> _mockCategoryService;
    public CategoryServiceTest()
    {
        _mockCategoryService = new Mock<ICategoryService>();
    }

    [Theory]
    [InlineData(1)]
    public async Task Get_ByCategoryId_OnSuccess(int categoryId)
    {
        // Arrange
        _mockCategoryService
            .Setup(service => service.GetByCategoryIdAsync(categoryId))
            .ReturnsAsync(CategoryMD.GetCategoryById(categoryId));
            
        var sut = new CategoriesController(_mockCategoryService.Object);
        
        // Act
        var result = await sut.GetCategoryById(1);

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        var objectResult = (OkObjectResult)result;
        objectResult.Value.Should().BeOfType<Category>();
        objectResult.StatusCode.Should().Be(200);
    }

    [Theory]
    [InlineData(1)]
    public async Task Get_ByCategoryId_OnFailure(int categoryId)
    {
        // Arrange
        _mockCategoryService
            .Setup(service => service.GetByCategoryIdAsync(categoryId))
            .ReturnsAsync(CategoryMD.GetNullCategoryById(categoryId));
            
        var sut = new CategoriesController(_mockCategoryService.Object);
        
        // Act
        var result = await sut.GetCategoryById(1);

        // Assert
        result.Should().BeOfType<NoContentResult>();
    }

    [Fact]
    public async Task Get_CategoryList_OnSuccess()
    {
        // Arrange
        _mockCategoryService
            .Setup(service => service.GetCategoryListAsync())
            .ReturnsAsync(CategoryMD.GetCategoryList());
            
        var sut = new CategoriesController(_mockCategoryService.Object);
        
        // Act
        var result = await sut.GetAllCategories();

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        var objectResult = (OkObjectResult)result;
        objectResult.Value.Should().BeOfType<List<Category>>();
    }

    [Fact]
    public async Task Get_CategoryList_OnFailure()
    {
        // Arrange
        _mockCategoryService
            .Setup(service => service.GetCategoryListAsync())
            .ReturnsAsync(new List<Category>());
            
        var sut = new CategoriesController(_mockCategoryService.Object);
        
        // Act
        var result = await sut.GetAllCategories();

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        var objectResult = (OkObjectResult)result;
        objectResult.Value.Should().BeOfType<List<Category>>();
    }

    [Fact]
    public async Task Post_CreateCategory_OnSuccess()
    {
        //Arrange
        var newCategory = CategoryMD.GetNewCategory();
        _mockCategoryService
            .Setup(x => x.AddAsync(newCategory))
            .ReturnsAsync(newCategory);
        var sut = new CategoriesController(_mockCategoryService.Object);

        //Act
        var result = await sut.CreateCategory(newCategory);
        var resultValue = (Category)((ObjectResult)result).Value;
        //Assert
        result.Should().BeOfType<OkObjectResult>();
        resultValue.Should().BeOfType<Category>();
        Assert.NotNull(resultValue);
        Assert.Equal(newCategory.Id, resultValue.Id);
        Assert.True(newCategory.Id == resultValue.Id);
    }

    [Fact]
    public async Task Post_CreateCategory_OnFailure()
    {
        // Arrange
        _mockCategoryService
            .Setup(service => service.AddAsync(CategoryMD.GetNewCategory()));
            
        var sut = new CategoriesController(_mockCategoryService.Object);
        
        // Act
        var result = await sut.CreateCategory(CategoryMD.GetNewCategory());

        // Assert
        result.Should().BeOfType<BadRequestResult>();
    }

    [Fact]
    public async Task Put_UpdateCategory_OnFailure()
    {
        // Arrange
        var newCategory = CategoryMD.GetNewCategory();
        var updatedCategory = CategoryMD.GetNullCategory();
        _mockCategoryService
            .Setup(x => x.UpdateAsync(newCategory))
            .ReturnsAsync(updatedCategory);            
        var sut = new CategoriesController(_mockCategoryService.Object);
        
        // Act
        var result = await sut.UpdateCategory(CategoryMD.GetNewCategory());
        var resultValue = (BadRequestResult)result;

        // Assert
        result.Should().BeOfType<BadRequestResult>();
        resultValue.StatusCode.Should().Be(400);
    }

    [Fact]
    public async Task Put_UpdateCategory_OnSuccess()
    {
        //Arrange
        var newCategory = CategoryMD.GetNewCategory();
        var updatedCategory = CategoryMD.GetUpdatedCategory();
        _mockCategoryService
            .Setup(x => x.UpdateAsync(newCategory))
            .ReturnsAsync(updatedCategory);
        var sut = new CategoriesController(_mockCategoryService.Object);

        //Act
        var result = await sut.UpdateCategory(newCategory);
        var resultValue = (Category)((ObjectResult)result).Value;
        //Assert
        result.Should().BeOfType<OkObjectResult>();
        resultValue.Should().BeOfType<Category>();
        Assert.NotNull(resultValue);
        Assert.Equal(newCategory.Id, resultValue.Id);
        Assert.True(resultValue.Name == "Updated Category");
    }

    [Fact]
    public async Task Delete_RemoveCategory_OnSuccess()
    {
        //Arrange
        var deleteCategory = CategoryMD.GetNewCategory();
        _mockCategoryService
            .Setup(x => x.DeleteAsync(deleteCategory))
            .ReturnsAsync($"Category with {deleteCategory.Id} Id is deleted");
        var sut = new CategoriesController(_mockCategoryService.Object);

        //Act
        var result = await sut.DeleteCategory(deleteCategory);
        var resultValue = (ObjectResult)result;
        //Assert
        result.Should().BeOfType<OkObjectResult>();
        resultValue.Should().BeOfType<OkObjectResult>();
        resultValue.StatusCode.Should().Be(200);
        Assert.True(resultValue.Value.ToString() == $"Category with {deleteCategory.Id} Id is deleted");
    }

    [Fact]
    public async Task Delete_RemoveCategory_OnFailure()
    {
        //Arrange
        var deleteCategory = CategoryMD.GetNewCategory();
        _mockCategoryService
            .Setup(x => x.DeleteAsync(deleteCategory));
        var sut = new CategoriesController(_mockCategoryService.Object);

        //Act
        var result = await sut.DeleteCategory(deleteCategory);
        var resultValue = (BadRequestResult)result;
        //Assert
        result.Should().BeOfType<BadRequestResult>();
        resultValue.Should().BeOfType<BadRequestResult>();
        resultValue.StatusCode.Should().Be(400);
    }
}