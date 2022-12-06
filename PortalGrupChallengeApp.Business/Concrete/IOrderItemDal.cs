using PortalGrupChallengeApp.Business.Abstract;
using PortalGrupChallengeApp.Business.Contants;
using PortalGrupChallengeApp.DataAccess.Abstract;
using PortalGrupChallengeApp.Entities.Concrete;

namespace PortalGrupChallengeApp.Business.Concrete;

public class OrderItemManager : IOrderItemService
{
    private readonly IOrderItemDal _orderItemDal;
    public OrderItemManager(IOrderItemDal orderItemDal)
    {
        _orderItemDal = orderItemDal;
    }
    public async Task<OrderItem> AddAsync(OrderItem orderItem)
    {
        await _orderItemDal.AddAsync(orderItem);
        return orderItem;
    }

    public async Task<string> DeleteAsync(OrderItem orderItem)
    {
        await _orderItemDal.RemoveAsync(orderItem);
        return Messages.DeleteMessage;
    }

    public async Task<OrderItem> GetByOrderItemIdAsync(int orderItemId)
    {
        var result = await _orderItemDal.GetFirstOrDefaultAsync(x => x.Id == orderItemId);
        return result;
    }

    public async Task<List<OrderItem>> GetOrderItemListAsync()
    {
        var resultList = await _orderItemDal.GetListAsync();
        return resultList.ToList();
    }

    public async Task<OrderItem> UpdateAsync(OrderItem orderItem)
    {
        await _orderItemDal.UpdateAsync(orderItem);
        return orderItem;
    }
}