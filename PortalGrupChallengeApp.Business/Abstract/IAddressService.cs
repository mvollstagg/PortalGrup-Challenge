using PortalGrupChallengeApp.Entities.Concrete;

namespace PortalGrupChallengeApp.Business.Abstract;

public interface IAddressService
{
    Task<Address> GetByAddressIdAsync(int addressId);
    Task<List<Address>> GetAddressListAsync();
    Task<Address> AddAsync(Address address);
    Task<Address> UpdateAsync(Address address);
    Task<string> DeleteAsync(Address address);
}
