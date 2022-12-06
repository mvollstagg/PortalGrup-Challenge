using PortalGrupChallengeApp.Core.DataAccess;
using PortalGrupChallengeApp.Entities.Concrete;

namespace PortalGrupChallengeApp.DataAccess.Abstract;

public interface ICustomerDal: IEntityRepositoryAsync<Customer>
{
    
}