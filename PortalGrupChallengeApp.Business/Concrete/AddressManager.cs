using PortalGrupChallengeApp.Business.Abstract;
using PortalGrupChallengeApp.Business.Contants;
using PortalGrupChallengeApp.DataAccess.Abstract;
using PortalGrupChallengeApp.Entities.Concrete;

namespace PortalGrupChallengeApp.Business.Concrete;

public class AddressManager : IAddressService
{
    private readonly IAddressDal _addressDal;
    public AddressManager(IAddressDal addressDal)
    {
        _addressDal = addressDal;
    }
    public async Task<Address> AddAsync(Address address)
    {
        await _addressDal.AddAsync(address);
        return address;
    }

    public async Task<string> DeleteAsync(Address address)
    {
        await _addressDal.RemoveAsync(address);
        return Messages.DeleteMessage;
    }

    public async Task<Address> GetByCustomerIdAsync(int addressId)
    {
        var result = await _addressDal.GetFirstOrDefaultAsync(x => x.CustomerId == addressId);
        return result;
    }

    public async Task<List<Address>> GetAddressListAsync()
    {
        var resultList = await _addressDal.GetListAsync();
        return resultList.ToList();
    }

    public async Task<Address> UpdateAsync(Address address)
    {
        await _addressDal.UpdateAsync(address);
        return address;
    }
}