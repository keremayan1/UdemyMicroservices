using System.Collections.Generic;
using System.Threading.Tasks;
using FreeCourse.Services.Catalog2.Business.Abstract;
using FreeCourse.Services.Catalog2.DataAccess.Abstract;
using FreeCourse.Services.Catalog2.Entities;
using FreeCourse.Shared.Dto;

namespace FreeCourse.Services.Catalog2.Business.Concrete
{
    public class CourseManager:ICourseService
    {
        private ICourseDal _courseDal;

        public CourseManager(ICourseDal courseDal)
        {
            _courseDal = courseDal;
        }

        public async Task<Response<Course>> CreateAsync(Course course)
        {
            await _courseDal.AddAsync(course);
            return Response<Course>.Success(200);
        }

        public async Task<Response<Course>> GetByIdAsync(string id)
        {
            var result = await _courseDal.GetByIdAsync(id);
            return Response<Course>.Success(result, 200);
        }

   

        public async Task<Response<IEnumerable<Course>>> GetAllAsync()
        {
            var result = await _courseDal.GetListAsync();
            return Response<IEnumerable<Course>>.Success(result, 200);
        }

       

        public async Task<Response<Course>> DeleteAsync(string id)
        {
            await _courseDal.DeleteAsync(id);
            return Response<Course>.Success(200);
        }

        public async Task<Response<Course>> UpdateAsync(Course course)
        {
            await _courseDal.UpdateAsync(course.Id,course);
            return Response<Course>.Success(200);
        }
    }
}
