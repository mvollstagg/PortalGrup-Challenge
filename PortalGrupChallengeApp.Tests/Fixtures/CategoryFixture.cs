using PortalGrupChallengeApp.Entities.Concrete;

namespace PortalGrupChallengeApp.Tests.Fixtures;

public static class CategoryFixture
{
    public static List<Category> GetCategoriesList() => new()
    {
        new Category
        {
            Id = 1,
            Name = "Category 1",
            Status = true,
            CreationDate = DateTime.Now
        },
        new Category
        {
            Id = 2,
            Name = "Category 2",
            Status = false,
            CreationDate = DateTime.Now.AddDays(1)
        },
        new Category
        {
            Id = 3,
            Name = "Category 3",
            Status = true,
            CreationDate = DateTime.Now.AddDays(2)
        },
    };

    public static Category GetCategoryById(int id)
    {
        return new Category
        {
            Id = id,
            Name = "Category 1",
            Status = true,
            CreationDate = DateTime.Now
        };                
    }

    public static Category GetCategoryById_Fail(int id)
    {
        return null;           
    }

    public static Category NewCategory()
    {
        return new Category
        {
            Id = 1,
            Name = "New Category",
            Status = true,
            CreationDate = DateTime.Now
        };                
    }
}