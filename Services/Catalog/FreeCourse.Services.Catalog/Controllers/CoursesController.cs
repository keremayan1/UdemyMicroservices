using System.Threading.Tasks;
using FreeCourse.Services.Catalog.Models.DTO;
using FreeCourse.Services.Catalog.Services;
using FreeCourse.Shared.ControllerBases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : CustomControllerBases
    {
        private ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _courseService.GetAllAsync();
          return  CreateActionResult(result);
        }
        [HttpGet("GetAllByUserId")]
      
        public async Task<IActionResult> GetAllByUserId(string userId)
        {
            var result = await _courseService.GetByUserIdAsync(userId);
            return CreateActionResult(result);
        }
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            var result = await _courseService.GetByIdAsync(id);
            return CreateActionResult(result);
        }


        [HttpPost("add")]
        public async Task<IActionResult> Add(CourseCreateDto courseCreateDto)
        {
            var result = await _courseService.AddAsync(courseCreateDto);
            return CreateActionResult(result);
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update(CourseUpdateDto courseUpdateDto)
        {
            var result = await _courseService.UpdateAsync(courseUpdateDto);
            return CreateActionResult(result);
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _courseService.DeleteAsync(id);
            return CreateActionResult(result);
        }
    }
}
