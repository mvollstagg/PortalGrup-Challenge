using PortalGrupChallengeApp.Core.DataAccess.EntityFramework;
using PortalGrupChallengeApp.DataAccess.Abstract;
using PortalGrupChallengeApp.DataAccess.Concrete.EntityFramework.Context;
using PortalGrupChallengeApp.Entities.Concrete;

namespace PortalGrupChallengeApp.DataAccess.Concrete.EntityFramework;

public class EfCustomerDal : EfEntityRepositoryBaseAsync<Customer, PortalGrupChallengeContext>, ICustomerDal
{
    public async Task AddAddress(Address address)
    {
        using var context = new PortalGrupChallengeContext();
        context.Addresses.Add(address);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAddress(Address address)
    {
        using var context = new PortalGrupChallengeContext();
        context.Addresses.Update(address);
        await context.SaveChangesAsync();
    }
}