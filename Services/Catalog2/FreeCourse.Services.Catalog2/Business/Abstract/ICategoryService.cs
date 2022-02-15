using System.Collections.Generic;
using System.Threading.Tasks;

using FreeCourse.Services.Catalog2.Entities;
using FreeCourse.Shared.Dto;

namespace FreeCourse.Services.Catalog2.Business.Abstract
{
    public interface ICategoryService
    {
        Task<Response<Category>> CreateAsync(Category category);
        Task<Response<Category>> GetByIdAsync(string id);
     

        Task<Response<IEnumerable<Category>>> GetAllAsync();
      
        Task<Response<Category>> DeleteAsync(string id);
        Task<Response<Category>> UpdateAsync(Category category);

    }
}
