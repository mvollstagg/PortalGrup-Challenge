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
        #region Address
        builder.RegisterType<AddressManager>().As<IAddressService>();
        builder.RegisterType<EfAddressDal>().As<IAddressDal>();
        #endregion

        #region Category
        builder.RegisterType<CategoryManager>().As<ICategoryService>();
        builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();
        #endregion

        #region Customer
        builder.RegisterType<CustomerManager>().As<ICustomerService>();
        builder.RegisterType<EfCustomerDal>().As<ICustomerDal>();
        #endregion

        #region Order
        builder.RegisterType<OrderManager>().As<IOrderService>();
        builder.RegisterType<EfOrderDal>().As<IOrderDal>();
        #endregion

        #region OrderItem
        builder.RegisterType<OrderItemManager>().As<IOrderItemService>();
        builder.RegisterType<EfOrderItemDal>().As<IOrderItemDal>();
        #endregion

        #region Sku
        builder.RegisterType<SkuManager>().As<ISkuService>();
        builder.RegisterType<EfSkuDal>().As<ISkuDal>();
        #endregion
    }
}