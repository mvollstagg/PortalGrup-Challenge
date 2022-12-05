using PortalGrupChallengeApp.Business.Abstract;
using PortalGrupChallengeApp.Business.Contants;
using PortalGrupChallengeApp.DataAccess.Abstract;
using PortalGrupChallengeApp.Entities.Concrete;

namespace PortalGrupChallengeApp.Business.Concrete;

public class CategoryManager : ICategoryService
{
    private readonly ICategoryDal _categoryDal;
    public CategoryManager(ICategoryDal categoryDal)
    {
        _categoryDal = categoryDal;
    }
    public async Task<Category> AddAsync(Category category)
    {
        await _categoryDal.AddAsync(category);
        return category;
    }

    public async Task<string> DeleteAsync(Category category)
    {
        await _categoryDal.UpdateAsync(category);
        return Messages.DeleteMessage;
    }

    public async Task<Category> GetByCategoryIdAsync(int CategoryId)
    {
        var result = await _categoryDal.GetFirstOrDefaultAsync(x => x.Id == CategoryId);
        return result;
    }

    public async Task<List<Category>> GetCategoryListAsync()
    {
        var resultList = await _categoryDal.GetListAsync();
        return resultList.ToList();
    }

    public async Task<string> UpdateAsync(Category category)
    {
        await _categoryDal.UpdateAsync(category);
        return Messages.UpdateMessage;
    }
}