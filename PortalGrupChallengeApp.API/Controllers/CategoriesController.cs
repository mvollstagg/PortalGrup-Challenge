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

        // [HttpPut("{id}")]
        // public async Task<ActionResult<UserDTO>> UpdateUser(int id, [FromBody] SaveUserDTO saveUserResource)
        // {
        //     /*
        //         TODO Validator yazılacak
        //     */
        //     // var validator = new CreateUserResourceValidator();
        //     // var validationResult = await validator.ValidateAsync(saveUserResource);

        //     // if (!validationResult.IsValid)
        //     //     return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

        //     var userToBeUpdated = await _userService.GetUserById(id);

        //     if (userToBeUpdated == null)
        //         return NotFound();

        //     var user = _mapper.Map<SaveUserDTO, User>(saveUserResource);
        //     if(!String.IsNullOrEmpty(saveUserResource.Password) && saveUserResource.Password == saveUserResource.PasswordConfirm)
        //     {
        //         user.PasswordHash = HashHelper.CreatePasswordHash(saveUserResource.Password, userToBeUpdated.SecretKey);
        //     }
            
        //     await _userService.UpdateUser(userToBeUpdated, user);

        //     var updatedUser = await _userService.GetUserById(id);

        //     var updatedUserResource = _mapper.Map<AppUser, UserDTO>(updatedUser);

        //     return Ok(updatedUserResource);
        // }

        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteUser(int id)
        // {
        //     var user = await _userService.GetUserById(id);

        //     await _userService.DeleteUser(user);

        //     return NoContent();
        // }
    }
}