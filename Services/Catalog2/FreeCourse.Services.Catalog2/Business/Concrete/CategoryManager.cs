using System.Collections.Generic;
using System.Threading.Tasks;

using FreeCourse.Services.Catalog2.Business.Abstract;
using FreeCourse.Services.Catalog2.DataAccess.Abstract;
using FreeCourse.Services.Catalog2.Entities;
using FreeCourse.Shared.Dto;

namespace FreeCourse.Services.Catalog2.Business.Concrete
{
    public class CategoryManager:ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public async Task<Response<Category>> CreateAsync(Category category)
        {
           await _categoryDal.AddAsync(category);
           return Response<Category>.Success(200);
        }

        public async Task<Response<Category>> GetByIdAsync(string id)
        {
            var data = await _categoryDal.GetByIdAsync(id);
            return Response<Category>.Success(data,200);
        }

      
        public async Task<Response<Category>> GetByIdAsync2(string categoryId)
        {
            await _categoryDal.GetByIdAsync(categoryId);
            return Response<Category>.Success(200);
        }

        public async Task<Response<IEnumerable<Category>>> GetAllAsync()
        {
           var categories = await _categoryDal.GetListAsync();
            return Response<IEnumerable<Category>>.Success(categories,200);
        }

   

        public async Task<Response<Category>> DeleteAsync(string id)
        {
         await _categoryDal.DeleteAsync(id);
           return Response<Category>.Success(204);
        }

        public async Task<Response<Category>> UpdateAsync(Category category)
        {
            await _categoryDal.UpdateAsync(category.Id, category);
            return Response<Category>.Success(204);
        }
    }
}
