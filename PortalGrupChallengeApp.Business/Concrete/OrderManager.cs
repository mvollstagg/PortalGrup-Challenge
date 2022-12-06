using PortalGrupChallengeApp.Business.Abstract;
using PortalGrupChallengeApp.Business.Contants;
using PortalGrupChallengeApp.DataAccess.Abstract;
using PortalGrupChallengeApp.Entities.Concrete;

namespace PortalGrupChallengeApp.Business.Concrete;

public class OrderManager : IOrderService
{
    private readonly IOrderDal _orderDal;
    public OrderManager(IOrderDal orderDal)
    {
        _orderDal = orderDal;
    }
    public async Task<Order> AddAsync(Order order)
    {
        await _orderDal.AddAsync(order);
        return order;
    }

    public async Task<string> DeleteAsync(Order order)
    {
        await _orderDal.RemoveAsync(order);
        return Messages.DeleteMessage;
    }

    public async Task<Order> GetByOrderIdAsync(int orderId)
    {
        var result = await _orderDal.GetFirstOrDefaultAsync(x => x.Id == orderId);
        return result;
    }

    public async Task<List<Order>> GetOrderListAsync()
    {
        var resultList = await _orderDal.GetListAsync();
        return resultList.ToList();
    }

    public async Task<Order> UpdateAsync(Order order)
    {
        await _orderDal.UpdateAsync(order);
        return order;
    }
}