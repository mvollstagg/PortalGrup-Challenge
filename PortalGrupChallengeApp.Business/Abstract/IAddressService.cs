using PortalGrupChallengeApp.Entities.Concrete;

namespace PortalGrupChallengeApp.Business.Abstract;

public interface IAddressService
{
    Task<Address> GetByCustomerIdAsync(int customerId);
    Task<List<Address>> GetAddressListAsync();
    Task<Address> AddAsync(Address address);
    Task<Address> UpdateAsync(Address address);
    Task<string> DeleteAsync(Address address);
}
