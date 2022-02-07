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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _courseService.GetAllAsync();
          return  CreateActionResult(result);
        }
        [HttpGet("GetByUserId/{userId}")] //2. Yontem HttpGet Istegi Uzerinden
      //  [Route("/api/[controller]/GetByUserId/{userId}")] 1.Yontem Route Yontemi
        //courses/getbyuserid/userId

        public async Task<IActionResult> GetByUserId(string userId)
        {
            var result = await _courseService.GetByUserIdAsync(userId);
            return CreateActionResult(result);
        }
        [HttpGet("getbyid/{courseId}")]
        public async Task<IActionResult> GetByIdAsync(string courseId)
        {
            var result = await _courseService.GetByIdAsync(courseId);
            return CreateActionResult(result);
        }
        //courses/getbyid/id

        [HttpPost]
        public async Task<IActionResult> Add(CourseCreateDto courseCreateDto)
        {
            var result = await _courseService.AddAsync(courseCreateDto);
            return CreateActionResult(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(CourseUpdateDto courseUpdateDto)
        {
            var result = await _courseService.UpdateAsync(courseUpdateDto);
            return CreateActionResult(result);
        }
        [HttpDelete("{courseId}")]
        public async Task<IActionResult> Delete(string courseId)
        {
            var result = await _courseService.DeleteAsync(courseId);
            return CreateActionResult(result);
        }
    }
}
