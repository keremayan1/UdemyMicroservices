using System.Collections.Generic;
using System.Threading.Tasks;
using FreeCourse.Services.Catalog2.Entities;
using FreeCourse.Shared.Dto;

namespace FreeCourse.Services.Catalog2.Business.Abstract
{
    public interface ICourseService
    {
        Task<Response<Course>> CreateAsync(Course course);
        Task<Response<Course>> GetByIdAsync(string id);
        Task<Response<IEnumerable<Course>>> GetAllAsync();
        Task<Response<Course>> DeleteAsync(string id);
        Task<Response<Course>> UpdateAsync(Course course);
    }
}
