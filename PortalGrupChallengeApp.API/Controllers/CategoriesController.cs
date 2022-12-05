using Microsoft.AspNetCore.Mvc;
using PortalGrupChallengeApp.Entities.Concrete;
using PortalGrupChallengeApp.Business.Abstract;

namespace PortalGrupChallengeApp.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryService.GetCategoryListAsync();
            if (categories != null)
            {
               return Ok(categories);
            }
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryService.GetByCategoryIdAsync(id);
            if (category != null)
            {
               return Ok(category);
            }
            return NoContent();
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateCategory([FromBody] Category newCategory)
        {

            var category = await _categoryService.AddAsync(newCategory);
            if (category != null)
            {
               return Ok(category);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory([FromBody] Category category)
        {            
            var updatedCategory = await _categoryService.UpdateAsync(category);
            if (updatedCategory != null)
            {
               return Ok(updatedCategory);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory([FromBody] Category category)
        {
            var deletedCategory = await _categoryService.DeleteAsync(category);
            if (deletedCategory != null)
            {
               return Ok($"Category with {category.Id} Id is deleted");
            }
            return BadRequest();
        }
    }
}