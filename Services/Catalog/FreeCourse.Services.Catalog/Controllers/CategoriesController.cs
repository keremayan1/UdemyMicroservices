using System.Threading.Tasks;
using FreeCourse.Services.Catalog.Models;
using FreeCourse.Services.Catalog.Models.DTO;
using FreeCourse.Services.Catalog.Services;
using FreeCourse.Shared.ControllerBases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : CustomControllerBases
    {
        private ICategoryService _categoryService; 

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _categoryService.GetAllAsync();
            return CreateActionResult(result);
        }
        [HttpGet("getbyid/{categoryId}")]
        public async Task<IActionResult> GetById(string categoryId)
        {
            var result = await _categoryService.GetByCategoryIdAsync(categoryId);
            return CreateActionResult(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(CategoryDto category)
        {
            var result = await _categoryService.CreateAsync(category);
            return CreateActionResult(result);
        }
    }
}
