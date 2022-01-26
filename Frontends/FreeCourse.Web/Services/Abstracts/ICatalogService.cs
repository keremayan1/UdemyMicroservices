using FreeCourse.Web.Models.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeCourse.Web.Services.Abstracts
{
   public interface ICatalogService
    {
        Task<List<CourseViewModel>> GetAllCourse();
        Task<List<CategoryViewModel>> GetAllCategoryAsync();
        Task<List<CourseViewModel>> GetAllCourseByUserId(string userId);
      
        Task<CourseViewModel> GetByCourseId(string courseId);

        Task<bool> AddCourseAsync(CourseCreateInput courseCreateInput);
        Task<bool> UpdateCourseAsync(CourseUpdateInput courseUpdateInput);
        Task<bool> DeleteCourseAsync(string courseId);
    }
}
