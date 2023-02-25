using PortalGrupChallengeApp.Business.Abstract;
using PortalGrupChallengeApp.Business.Contants;
using PortalGrupChallengeApp.DataAccess.Abstract;
using PortalGrupChallengeApp.Entities.Concrete;

namespace PortalGrupChallengeApp.Business.Concrete;

public class SkuManager : ISkuService
{
    private readonly ISkuDal _skuDal;
    public SkuManager(ISkuDal skuDal)
    {
        _skuDal = skuDal;
    }
    public async Task<SKU> AddAsync(SKU sku)
    {
        await _skuDal.AddAsync(sku);
        return sku;
    }

    public async Task<string> DeleteAsync(SKU sku)
    {
        await _skuDal.RemoveAsync(sku);
        return Messages.DeleteMessage;
    }

    public async Task<SKU> GetBySKUIdAsync(int skuId)
    {
        var result = await _skuDal.GetFirstOrDefaultAsync(x => x.Id == skuId, x => x.Category);
        return result;
    }

    public async Task<List<SKU>> GetSKUListAsync()
    {
        var resultList = await _skuDal.GetListAsync(null, null, x => x.Category);
        return resultList.ToList();
    }

    public async Task<SKU> UpdateAsync(SKU sku)
    {
        await _skuDal.UpdateAsync(sku);
        return sku;
    }
}