using Microsoft.AspNetCore.Mvc;
using PortalGrupChallengeApp.Entities.Concrete;
using PortalGrupChallengeApp.Business.Abstract;
using AutoMapper;
using PortalGrupChallengeApp.API.Models;

namespace PortalGrupChallengeApp.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class SkusController : ControllerBase
    {
        private readonly ISkuService _skuService;
        private readonly IMapper _mapper;
        public SkusController(ISkuService skuService, IMapper mapper)
        {
            _skuService = skuService;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllSkus()
        {
            var skus = await _skuService.GetSKUListAsync();
            if (skus != null)
            {
                // var _skusResources = _mapper.Map<IEnumerable<SKU>, IEnumerable<SkuDTO>>(skus);
                return Ok(skus);
            }
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSkuById(int id)
        {
            var sku = await _skuService.GetBySKUIdAsync(id);
            if (sku != null)
            {
               return Ok(sku);
            }
            return NoContent();
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateSku([FromBody] SkuDTO newSku)
        {
            var _mappedSku = _mapper.Map<SKU>(newSku);
            var sku = await _skuService.AddAsync(_mappedSku);
            if (sku != null)
            {
                return Ok(sku);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSku([FromBody] SkuDTO sku)
        {            
            var skuRow = await _skuService.GetBySKUIdAsync(id);
            if(skuRow == null)
                return NotFound();

            var _mappedCustomer = _mapper.Map<Customer>(sku);
            _mappedCustomer.Id = skuRow.Id;
            var updatedCustomer = await _skuService.UpdateAsync(_mappedCustomer);
            if (updatedCustomer != null)
            {
                return Ok(sku);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSku([FromBody] SKU sku)
        {
            var deletedSku = await _skuService.DeleteAsync(sku);
            if (deletedSku != null)
            {
               return Ok($"Sku with {sku.Id} Id is deleted");
            }
            return BadRequest();
        }
    }
}