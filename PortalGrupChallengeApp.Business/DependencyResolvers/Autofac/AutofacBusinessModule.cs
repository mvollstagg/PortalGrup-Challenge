using Autofac;
using PortalGrupChallengeApp.Business.Abstract;
using PortalGrupChallengeApp.Business.Concrete;
using PortalGrupChallengeApp.DataAccess.Abstract;
using PortalGrupChallengeApp.DataAccess.Concrete.EntityFramework;

namespace PortalGrupChallengeApp.Business.DependencyResolvers.Autofac;

public class AutofacBusinessModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        #region Category
        builder.RegisterType<CategoryManager>().As<ICategoryService>();
        builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();
        #endregion
    }
}