using PortalGrupChallengeApp.Entities.Concrete;

namespace PortalGrupChallengeApp.Business.Abstract;

public interface ICategoryService
{
    Task<Category> GetByCategoryIdAsync(int categoryId);
    Task<List<Category>> GetCategoryListAsync();
    Task<Category> AddAsync(Category category);
    Task<Category> UpdateAsync(Category category);
    Task<string> DeleteAsync(Category category);
}
