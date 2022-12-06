// using Microsoft.AspNetCore.Mvc;
// using PortalGrupChallengeApp.Entities.Concrete;
// using PortalGrupChallengeApp.Business.Abstract;

// namespace PortalGrupChallengeApp.API.Controllers
// {
//     [Route("[controller]/[action]")]
//     [ApiController]
//     public class OrderItemsController : ControllerBase
//     {
//         private readonly IOrderItemService _orderItemService;
//         public OrderItemsController(IOrderItemService orderItemService)
//         {
//             _orderItemService = orderItemService;
//         }

//         [HttpGet("")]
//         public async Task<IActionResult> GetAllOrderItems()
//         {
//             var categories = await _orderItemService.GetOrderItemListAsync();
//             if (categories != null)
//             {
//                return Ok(categories);
//             }
//             return NoContent();
//         }

//         [HttpGet("{id}")]
//         public async Task<IActionResult> GetOrderItemById(int id)
//         {
//             var orderItem = await _orderItemService.GetByOrderItemIdAsync(id);
//             if (orderItem != null)
//             {
//                return Ok(orderItem);
//             }
//             return NoContent();
//         }

//         [HttpPost("")]
//         public async Task<IActionResult> CreateOrderItem([FromBody] OrderItem newOrderItem)
//         {

//             var orderItem = await _orderItemService.AddAsync(newOrderItem);
//             if (orderItem != null)
//             {
//                return Ok(orderItem);
//             }
//             return BadRequest();
//         }

//         [HttpPut("{id}")]
//         public async Task<IActionResult> UpdateOrderItem(int id, [FromBody] OrderItem orderItem)
//         {
//             var orderItemRow = await _orderItemService.GetByOrderItemIdAsync(id);
//             if(orderItemRow == null)
//                 return NotFound();
                
//             var updatedOrderItem = await _orderItemService.UpdateAsync(orderItem);
//             if (updatedOrderItem != null)
//             {
//                return Ok(updatedOrderItem);
//             }
//             return BadRequest();
//         }

//         [HttpDelete("{id}")]
//         public async Task<IActionResult> DeleteOrderItem(int id)
//         {
//             var orderItem = await _orderItemService.GetByOrderItemIdAsync(id);
//             var deletedOrderItem = await _orderItemService.DeleteAsync(orderItem);
//             if (deletedOrderItem != null)
//             {
//                return Ok($"OrderItem '{orderItem.Id}' is deleted");
//             }
//             return BadRequest();
//         }
//     }
// }