using PortalGrupChallengeApp.Entities.Concrete;

namespace PortalGrupChallengeApp.Tests.MockData;

public class CategoryMD
{
    public static List<Category> GetCategoryList()
    {
        return new List<Category>{
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
            }
         };        
    }

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

    public static Category GetNullCategoryById(int id)
    {
        return null;           
    }

    public static Category GetNullCategory()
    {
        return null;           
    }

    public static Category GetNewCategory()
    {
        return new Category
        {
            Id = 1,
            Name = "New Category",
            Status = true,
            CreationDate = DateTime.Now
        };
    }

    public static Category GetUpdatedCategory()
    {
        return new Category
        {
            Id = 1,
            Name = "Updated Category",
            Status = false,
            CreationDate = DateTime.Now
        };
    }
}