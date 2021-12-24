using System.Collections.Generic;
using System.Threading.Tasks;
using FreeCourse.Services.Catalog.Models;
using FreeCourse.Services.Catalog.Models.DTO;
using FreeCourse.Shared.Dto;

namespace FreeCourse.Services.Catalog.Services
{
    public interface ICategoryService
    {
        Task<Response<CategoryDto>> CreateAsync(CategoryDto category);
        Task<Response<CategoryDto>> GetByIdAsync(string id);
        Task<Response<List<CategoryDto>>> GetAllAsync();

        Task<Response<Category>> GetByCategoryIdAsync(string categoryId);

    }
}
