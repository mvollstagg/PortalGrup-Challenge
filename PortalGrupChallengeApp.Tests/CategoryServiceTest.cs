using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PortalGrupChallengeApp.API.Controllers;
using PortalGrupChallengeApp.Business.Abstract;
using PortalGrupChallengeApp.Entities.Concrete;
using PortalGrupChallengeApp.Tests.Fixtures;

namespace PortalGrupChallengeApp.Tests;

public class CategoryServiceTest
{
    Mock<ICategoryService> mockCategoryService = new Mock<ICategoryService>();

    [Theory]
    [InlineData(1)]
    public async Task Get_ByCategoryId_OnSuccess(int categoryId)
    {
        // Arrange
        mockCategoryService
            .Setup(service => service.GetByCategoryIdAsync(categoryId))
            .ReturnsAsync(CategoryFixture.GetCategoryById(categoryId));
            
        var sut = new CategoriesController(mockCategoryService.Object);
        
        // Act
        var result = await sut.GetCategoryById(1);

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        var objectResult = (OkObjectResult)result;
        objectResult.Value.Should().BeOfType<Category>();
    }

    [Theory]
    [InlineData(1)]
    public async Task Get_ByCategoryId_OnFailure(int categoryId)
    {
        // Arrange
        mockCategoryService
            .Setup(service => service.GetByCategoryIdAsync(categoryId))
            .ReturnsAsync(CategoryFixture.GetCategoryById_Fail(categoryId));
            
        var sut = new CategoriesController(mockCategoryService.Object);
        
        // Act
        var result = await sut.GetCategoryById(1);

        // Assert
        result.Should().BeOfType<NoContentResult>();
    }

    [Fact]
    public async Task Get_CategoryList_OnSuccess()
    {
        // Arrange
        mockCategoryService
            .Setup(service => service.GetCategoryListAsync())
            .ReturnsAsync(CategoryFixture.GetCategoriesList());
            
        var sut = new CategoriesController(mockCategoryService.Object);
        
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
        mockCategoryService
            .Setup(service => service.GetCategoryListAsync())
            .ReturnsAsync(new List<Category>());
            
        var sut = new CategoriesController(mockCategoryService.Object);
        
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
        // Arrange
        mockCategoryService
            .Setup(service => service.AddAsync(CategoryFixture.NewCategory()))
            .ReturnsAsync(CategoryFixture.NewCategory());
            
        var sut = new CategoriesController(mockCategoryService.Object);
        
        // Act
        var result = await sut.CreateCategory(CategoryFixture.NewCategory());

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        var objectResult = (OkObjectResult)result;
        objectResult.Value.Should().BeOfType<Category>();
    }

    [Fact]
    public async Task Post_CreateCategory_OnFailure()
    {
        // Arrange
        mockCategoryService
            .Setup(service => service.AddAsync(CategoryFixture.NewCategory()));
            
        var sut = new CategoriesController(mockCategoryService.Object);
        
        // Act
        var result = await sut.CreateCategory(CategoryFixture.NewCategory());

        // Assert
        result.Should().BeOfType<BadRequestResult>();
    }
}