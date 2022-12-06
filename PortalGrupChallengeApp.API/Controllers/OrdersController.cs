using Microsoft.AspNetCore.Mvc;
using PortalGrupChallengeApp.Entities.Concrete;
using PortalGrupChallengeApp.Business.Abstract;

namespace PortalGrupChallengeApp.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllOrders()
        {
            var categories = await _orderService.GetOrderListAsync();
            if (categories != null)
            {
               return Ok(categories);
            }
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _orderService.GetByOrderIdAsync(id);
            if (order != null)
            {
               return Ok(order);
            }
            return NoContent();
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateOrder([FromBody] Order newOrder)
        {

            var order = await _orderService.AddAsync(newOrder);
            if (order != null)
            {
               return Ok(order);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] Order order)
        {
            var orderRow = await _orderService.GetByOrderIdAsync(id);
            if(orderRow == null)
                return NotFound();
                
            var updatedOrder = await _orderService.UpdateAsync(order);
            if (updatedOrder != null)
            {
               return Ok(updatedOrder);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _orderService.GetByOrderIdAsync(id);
            var deletedOrder = await _orderService.DeleteAsync(order);
            if (deletedOrder != null)
            {
               return Ok($"Order '{order.Customer.FirstName}' is deleted");
            }
            return BadRequest();
        }
    }
}