using PortalGrupChallengeApp.Entities.Concrete;

namespace PortalGrupChallengeApp.Business.Abstract;

public interface ISkuService
{
    Task<SKU> GetBySKUIdAsync(int skuId);
    Task<List<SKU>> GetSKUListAsync();
    Task<SKU> AddAsync(SKU sku);
    Task<SKU> UpdateAsync(SKU sku);
    Task<string> DeleteAsync(SKU sku);
}
