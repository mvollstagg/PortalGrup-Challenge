using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PortalGrupChallengeApp.API.Controllers;
using PortalGrupChallengeApp.API.Models;
using PortalGrupChallengeApp.Business.Abstract;
using PortalGrupChallengeApp.Entities.Concrete;
using PortalGrupChallengeApp.Tests.MockData;

namespace PortalGrupChallengeApp.Tests;

public class CategoryServiceTest
{
    private readonly Mock<ICategoryService> _mockCategoryService;
    private readonly Mock<IMapper> _mockMapperService;
    public CategoryServiceTest()
    {
        _mockCategoryService = new Mock<ICategoryService>();
        _mockMapperService = new Mock<IMapper>();
    }

    [Theory]
    [InlineData(1)]
    public async Task Get_ByCategoryId_OnSuccess(int categoryId)
    {
        // Arrange
        _mockCategoryService
            .Setup(service => service.GetByCategoryIdAsync(categoryId))
            .ReturnsAsync(CategoryMD.GetCategoryById(categoryId));
            
        var sut = new CategoriesController(_mockCategoryService.Object, _mockMapperService.Object);
        
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
            
        var sut = new CategoriesController(_mockCategoryService.Object, _mockMapperService.Object);
        
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
            
        var sut = new CategoriesController(_mockCategoryService.Object, _mockMapperService.Object);
        
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
            
        var sut = new CategoriesController(_mockCategoryService.Object, _mockMapperService.Object);
        
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
        var newCategoryDto = CategoryMD.GetNewCategoryDTO();
        _mockMapperService.Setup(service => service.Map<Category>(It.IsAny<CategoryDTO>()))
            .Returns(newCategory);
        _mockCategoryService
            .Setup(service => service.AddAsync(newCategory))
            .ReturnsAsync(newCategory);
        var sut = new CategoriesController(_mockCategoryService.Object, _mockMapperService.Object);

        //Act
        var result = await sut.CreateCategory(newCategoryDto);
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
            
        var sut = new CategoriesController(_mockCategoryService.Object, _mockMapperService.Object);
        
        // Act
        var result = await sut.CreateCategory(CategoryMD.GetNewCategoryDTO());

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
            .Setup(service => service.GetByCategoryIdAsync(newCategory.Id))
            .ReturnsAsync(newCategory);
        _mockCategoryService
            .Setup(service => service.UpdateAsync(newCategory))
            .ReturnsAsync(updatedCategory);            
        var sut = new CategoriesController(_mockCategoryService.Object, _mockMapperService.Object);
        
        // Act
        var result = await sut.UpdateCategory(newCategory.Id, CategoryMD.GetNewCategoryDTO());
        var resultValue = (BadRequestResult)result;

        // Assert
        result.Should().BeOfType<BadRequestResult>();
        resultValue.StatusCode.Should().Be(400);
    }

    [Fact]
    public async Task Put_UpdateCategory_OnNotFound()
    {
        // Arrange
        var newCategory = CategoryMD.GetNewCategory();
        var updatedCategory = CategoryMD.GetNullCategory();
        _mockCategoryService
            .Setup(service => service.UpdateAsync(newCategory))
            .ReturnsAsync(updatedCategory);            
        var sut = new CategoriesController(_mockCategoryService.Object, _mockMapperService.Object);
        
        // Act
        var result = await sut.UpdateCategory(newCategory.Id, CategoryMD.GetNewCategoryDTO());
        var resultValue = (NotFoundResult)result;

        // Assert
        result.Should().BeOfType<NotFoundResult>();
        resultValue.StatusCode.Should().Be(404);
    }

    [Fact]
    public async Task Put_UpdateCategory_OnSuccess()
    {
        //Arrange
        var newCategory = CategoryMD.GetNewCategory();
        var updatedCategory = CategoryMD.GetUpdatedCategory();
        _mockMapperService.Setup(service => service.Map<Category>(It.IsAny<CategoryDTO>()))
            .Returns(newCategory);
        _mockCategoryService
            .Setup(service => service.GetByCategoryIdAsync(newCategory.Id))
            .ReturnsAsync(newCategory);
        _mockCategoryService
            .Setup(service => service.UpdateAsync(newCategory))
            .ReturnsAsync(updatedCategory);
        var sut = new CategoriesController(_mockCategoryService.Object, _mockMapperService.Object);

        //Act
        var result = await sut.UpdateCategory(newCategory.Id, CategoryMD.GetNewCategoryDTO());
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
            .Setup(service => service.GetByCategoryIdAsync(deleteCategory.Id))
            .ReturnsAsync(deleteCategory);
        _mockCategoryService
            .Setup(service => service.DeleteAsync(deleteCategory))
            .ReturnsAsync($"Category '{deleteCategory.Name}' is deleted");
        var sut = new CategoriesController(_mockCategoryService.Object, _mockMapperService.Object);

        //Act
        var result = await sut.DeleteCategory(deleteCategory.Id);
        var resultValue = (ObjectResult)result;
        //Assert
        result.Should().BeOfType<OkObjectResult>();
        resultValue.Should().BeOfType<OkObjectResult>();
        resultValue.StatusCode.Should().Be(200);
        Assert.True(resultValue.Value.ToString() == $"Category '{deleteCategory.Name}' is deleted");
    }

    [Fact]
    public async Task Delete_RemoveCategory_OnFailure()
    {
        //Arrange
        var deleteCategory = CategoryMD.GetNewCategory();
        _mockCategoryService
            .Setup(service => service.DeleteAsync(deleteCategory));
        var sut = new CategoriesController(_mockCategoryService.Object, _mockMapperService.Object);

        //Act
        var result = await sut.DeleteCategory(deleteCategory.Id);
        var resultValue = (BadRequestResult)result;
        //Assert
        result.Should().BeOfType<BadRequestResult>();
        resultValue.Should().BeOfType<BadRequestResult>();
        resultValue.StatusCode.Should().Be(400);
    }
}