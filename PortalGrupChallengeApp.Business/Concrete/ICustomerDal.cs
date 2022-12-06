using PortalGrupChallengeApp.Business.Abstract;
using PortalGrupChallengeApp.Business.Contants;
using PortalGrupChallengeApp.DataAccess.Abstract;
using PortalGrupChallengeApp.Entities.Concrete;

namespace PortalGrupChallengeApp.Business.Concrete;

public class CustomerManager : ICustomerService
{
    private readonly ICustomerDal _customerDal;
    public CustomerManager(ICustomerDal customerDal)
    {
        _customerDal = customerDal;
    }
    public async Task<Customer> AddAsync(Customer customer)
    {
        await _customerDal.AddAsync(customer);
        return customer;
    }

    public async Task<string> DeleteAsync(Customer customer)
    {
        await _customerDal.RemoveAsync(customer);
        return Messages.DeleteMessage;
    }

    public async Task<Customer> GetByCustomerIdAsync(int customerId)
    {
        var result = await _customerDal.GetFirstOrDefaultAsync(x => x.Id == customerId);
        return result;
    }

    public async Task<List<Customer>> GetCustomerListAsync()
    {
        var resultList = await _customerDal.GetListAsync();
        return resultList.ToList();
    }

    public async Task<Customer> UpdateAsync(Customer customer)
    {
        await _customerDal.UpdateAsync(customer);
        return customer;
    }
}