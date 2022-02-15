using System.Threading.Tasks;


using FreeCourse.Services.Catalog2.Business.Abstract;
using FreeCourse.Services.Catalog2.Entities;
using FreeCourse.Shared.ControllerBases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.Services.Catalog2.Controllers
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
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(string categoryId)
        {
            var result = await _categoryService.GetByIdAsync(categoryId);
            return CreateActionResult(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(Category category)
        {
            var result = await _categoryService.CreateAsync(category);
            return CreateActionResult(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteById(string categoryId)
        {
            var result = await _categoryService.DeleteAsync(categoryId);
            return CreateActionResult(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Category category)
        {
            var result =await _categoryService.UpdateAsync(category);
            return CreateActionResult(result);
        }
    }
}
