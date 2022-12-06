using Microsoft.AspNetCore.Mvc;
using PortalGrupChallengeApp.Entities.Concrete;
using PortalGrupChallengeApp.Business.Abstract;

namespace PortalGrupChallengeApp.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class SkusController : ControllerBase
    {
        private readonly ISkuService _skuService;
        public SkusController(ISkuService skuService)
        {
            _skuService = skuService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllSkus()
        {
            var categories = await _skuService.GetSKUListAsync();
            if (categories != null)
            {
               return Ok(categories);
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
        public async Task<IActionResult> CreateSku([FromBody] SKU newSku)
        {

            var sku = await _skuService.AddAsync(newSku);
            if (sku != null)
            {
               return Ok(sku);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSku([FromBody] SKU sku)
        {            
            var updatedSku = await _skuService.UpdateAsync(sku);
            if (updatedSku != null)
            {
               return Ok(updatedSku);
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