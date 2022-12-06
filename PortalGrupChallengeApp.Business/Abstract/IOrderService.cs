using PortalGrupChallengeApp.Entities.Concrete;

namespace PortalGrupChallengeApp.Business.Abstract;

public interface IOrderService
{
    Task<Order> GetByOrderIdAsync(int orderId);
    Task<List<Order>> GetOrderListAsync();
    Task<Order> AddAsync(Order order);
    Task<Order> UpdateAsync(Order order);
    Task<string> DeleteAsync(Order order);
}
