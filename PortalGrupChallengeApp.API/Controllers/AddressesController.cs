// using Microsoft.AspNetCore.Mvc;
// using PortalGrupChallengeApp.Entities.Concrete;
// using PortalGrupChallengeApp.Business.Abstract;

// namespace PortalGrupChallengeApp.API.Controllers
// {
//     [Route("[controller]/[action]")]
//     [ApiController]
//     public class AddressesController : ControllerBase
//     {
//         private readonly IAddressService _addressService;
//         public AddressesController(IAddressService addressService)
//         {
//             _addressService = addressService;
//         }

//         [HttpGet("")]
//         public async Task<IActionResult> GetAllAddresses()
//         {
//             var categories = await _addressService.GetAddressListAsync();
//             if (categories != null)
//             {
//                return Ok(categories);
//             }
//             return NoContent();
//         }

//         [HttpGet("{id}")]
//         public async Task<IActionResult> GetAddressByCustomerId(int id)
//         {
//             var address = await _addressService.GetByCustomerIdAsync(id);
//             if (address != null)
//             {
//                return Ok(address);
//             }
//             return NoContent();
//         }

//         [HttpPost("")]
//         public async Task<IActionResult> CreateAddress([FromBody] Address newAddress)
//         {

//             var address = await _addressService.AddAsync(newAddress);
//             if (address != null)
//             {
//                return Ok(address);
//             }
//             return BadRequest();
//         }

//         [HttpPut("{id}")]
//         public async Task<IActionResult> UpdateAddress(int id, [FromBody] Address address)
//         {
//             var addressRow = await _addressService.GetByCustomerIdAsync(id);
//             if(addressRow == null)
//                 return NotFound();
                
//             var updatedAddress = await _addressService.UpdateAsync(address);
//             if (updatedAddress != null)
//             {
//                return Ok(updatedAddress);
//             }
//             return BadRequest();
//         }

//         [HttpDelete("{id}")]
//         public async Task<IActionResult> DeleteAddress(int id)
//         {
//             var address = await _addressService.GetByCustomerIdAsync(id);
//             var deletedAddress = await _addressService.DeleteAsync(address);
//             if (deletedAddress != null)
//             {
//                return Ok($"'{address.Customer.FirstName}' is deleted");
//             }
//             return BadRequest();
//         }
//     }
// }