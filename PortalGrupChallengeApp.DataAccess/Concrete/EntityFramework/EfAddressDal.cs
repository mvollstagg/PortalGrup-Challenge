using PortalGrupChallengeApp.Core.DataAccess.EntityFramework;
using PortalGrupChallengeApp.DataAccess.Abstract;
using PortalGrupChallengeApp.DataAccess.Concrete.EntityFramework.Context;
using PortalGrupChallengeApp.Entities.Concrete;

namespace PortalGrupChallengeApp.DataAccess.Concrete.EntityFramework;

public class EfAddressDal : EfEntityRepositoryBaseAsync<Address, PortalGrupChallengeContext>, IAddressDal
{

}