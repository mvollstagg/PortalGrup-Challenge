using Microsoft.AspNetCore.Mvc;
using PortalGrupChallengeApp.Entities.Concrete;
using PortalGrupChallengeApp.Business.Abstract;
using AutoMapper;
using PortalGrupChallengeApp.API.Models;

namespace PortalGrupChallengeApp.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public readonly IMapper _mapper;
        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
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
        public async Task<IActionResult> CreateCategory([FromBody] CategoryDTO newCategory)
        {

            var _mappedCategory = _mapper.Map<Category>(newCategory);
            var category = await _categoryService.AddAsync(_mappedCategory);
            if (category != null)
            {
                return Ok(category);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryDTO category)
        {
            var categoryRow = await _categoryService.GetByCategoryIdAsync(id);
            if(categoryRow == null)
                return NotFound();
            var _mappedCategory = _mapper.Map<Category>(category);    
            _mappedCategory.Id = categoryRow.Id;
            var updatedCategory = await _categoryService.UpdateAsync(_mappedCategory);
            if (updatedCategory != null)
            {
               return Ok(updatedCategory);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _categoryService.GetByCategoryIdAsync(id);
            var deletedCategory = await _categoryService.DeleteAsync(category);
            if (deletedCategory != null)
            {
               return Ok($"Category '{category.Name}' is deleted");
            }
            return BadRequest();
        }
    }
}