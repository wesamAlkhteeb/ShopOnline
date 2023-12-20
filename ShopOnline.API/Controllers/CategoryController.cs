using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.API.Application.Services.interfaces;
using ShopOnline.API.Domain.Helper;
using ShopOnline.API.Domain.Models.Category;

namespace ShopOnline.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpPost]
        [Authorize(Roles =ConstantsService.ADMIN)]
        public async Task<IActionResult> AddCategory([FromBody] AddCategoryModel addCategory)
        {
            return Ok(await categoryService.AddCategory(addCategory));
        }

        [HttpGet("{page}")]
        [Authorize(Roles = ConstantsService.ADMIN + ","+ConstantsService.USER)]
        public async Task<IActionResult> GetCategory(int page)
        {
            return Ok(await categoryService.GetCategory(page));
        }
        
        [HttpPut]
        [Authorize(Roles = ConstantsService.ADMIN)]
        public async Task<IActionResult> PutCategory([FromBody] UpdateCategoryModel updateCategory)
        {
            return Ok(await categoryService.PutCategory(updateCategory));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = ConstantsService.ADMIN)]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            return Ok(await categoryService.DeleteCategory(id));
        }
    }
}
