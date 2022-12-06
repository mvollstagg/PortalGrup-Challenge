using PortalGrupChallengeApp.Entities.Concrete;

namespace PortalGrupChallengeApp.Business.Abstract;

public interface IOrderItemService
{
    Task<OrderItem> GetByOrderItemIdAsync(int orderItemId);
    Task<List<OrderItem>> GetOrderItemListAsync();
    Task<OrderItem> AddAsync(OrderItem orderItem);
    Task<OrderItem> UpdateAsync(OrderItem orderItem);
    Task<string> DeleteAsync(OrderItem orderItem);
}
