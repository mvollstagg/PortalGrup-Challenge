using Microsoft.AspNetCore.Mvc;
using PortalGrupChallengeApp.Entities.Concrete;
using PortalGrupChallengeApp.Business.Abstract;
using PortalGrupChallengeApp.API.Models;
using AutoMapper;

namespace PortalGrupChallengeApp.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IAddressService _addressService;
        public readonly IMapper _mapper;
        public CustomersController(ICustomerService customerService,
                                    IAddressService addressService,
                                    IMapper mapper)
        {
            _customerService = customerService;
            _addressService = addressService;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _customerService.GetCustomerListAsync();
            if (customers != null)
            {
                var _customersResources = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDTO>>(customers);
                return Ok(_customersResources);
            }
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _customerService.GetByCustomerIdAsync(id);
            if (customer != null)
            {
                var _mappedCustomer = _mapper.Map<CustomerDTO>(customer);
                _mappedCustomer.Address = _mapper.Map<AddressDTO>(await _addressService.GetByCustomerIdAsync(customer.Id));
                return Ok(_mappedCustomer);
            }
            return NoContent();
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerDTO newCustomer)
        {
            var _mappedCustomer = _mapper.Map<Customer>(newCustomer);
            var _mappedAddress = _mapper.Map<Address>(newCustomer.Address);
            var customer = await _customerService.AddAsync(_mappedCustomer);
            if (customer != null)
            {
                _mappedAddress.CustomerId = customer.Id;
                await _customerService.AddCustomerAddressAsync(_mappedAddress);
                return Ok(customer);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] CustomerDTO customer)
        {
            var customerRow = await _customerService.GetByCustomerIdAsync(id);
            var addressRow = await _addressService.GetByCustomerIdAsync(id);
            if(customerRow == null)
                return NotFound();

            var _mappedCustomer = _mapper.Map<Customer>(customer);
            var _mappedAddress = _mapper.Map<Address>(customer.Address);
            _mappedCustomer.Id = customerRow.Id;
            var updatedCustomer = await _customerService.UpdateAsync(_mappedCustomer);
            if (updatedCustomer != null)
            {
                _mappedAddress.Id = addressRow.Id;
                _mappedAddress.CustomerId = customerRow.Id;
                await _customerService.UpdateCustomerAddressAsync(_mappedAddress);
                return Ok(customer);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _customerService.GetByCustomerIdAsync(id);
            var deletedCustomer = await _customerService.DeleteAsync(customer);
            if (deletedCustomer != null)
            {
                return Ok($"Customer '{customer.FirstName}' is deleted");
            }
            return BadRequest();
        }
    }
}