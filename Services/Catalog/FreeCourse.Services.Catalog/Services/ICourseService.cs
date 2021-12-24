using System.Collections.Generic;
using System.Threading.Tasks;
using FreeCourse.Services.Catalog.Models;
using FreeCourse.Services.Catalog.Models.DTO;
using FreeCourse.Shared.Dto;

namespace FreeCourse.Services.Catalog.Services
{
    public interface ICourseService
    {
        Task<Response<List<CourseDto>>> GetAllAsync();
        Task<Response<CourseDto>> GetByIdAsync(string courseId);
    
        Task<Response<List<CourseDto>>>GetByUserIdAsync(string userId);
        Task<Response<CourseDto>> AddAsync(CourseCreateDto courseCreateDto);
        Task<Response<NoContent>> UpdateAsync(CourseUpdateDto courseUpdateDto);
        Task<Response<NoContent>> DeleteAsync(string courseId);

    }
}
