using PortalGrupChallengeApp.Entities.Concrete;

namespace PortalGrupChallengeApp.Business.Abstract;

public interface ICustomerService
{
    Task<Customer> GetByCustomerIdAsync(int customerId);
    Task<List<Customer>> GetCustomerListAsync();
    Task<Customer> AddAsync(Customer customer);
    Task<Customer> UpdateAsync(Customer customer);
    Task<string> DeleteAsync(Customer customer);
}
