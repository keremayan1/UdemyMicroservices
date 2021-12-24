using AutoMapper;
using FreeCourse.Services.Catalog.Models;
using FreeCourse.Services.Catalog.Models.DTO;
using FreeCourse.Services.Catalog.Settings;
using FreeCourse.Shared.Dto;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeCourse.Services.Catalog.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionStrings);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task<Response<List<CategoryDto>>> GetAllAsync()
        {
            var categories = await _categoryCollection.Find(category => true).ToListAsync();
            return Response<List<CategoryDto>>.Success(_mapper.Map<List<CategoryDto>>(categories),200);
        }
        public async Task<Response<CategoryDto>> CreateAsync(CategoryDto category)
        {
            var categories = _mapper.Map<Category>(category);
            await _categoryCollection.InsertOneAsync(categories);
            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
        }
        public async Task<Response<CategoryDto>> GetByIdAsync(string id)
        {//1. Yontem
            //var categoryId = await _categoryCollection.FindAsync(category => category.Id == id);
            //return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(categoryId), 200);
            //2. Yontem
            var category = await _categoryCollection.Find<Category>(x => x.Id == id).FirstOrDefaultAsync();
            if (category==null)
            {
                return Response<CategoryDto>.Fail("Category not found", 404);
            }
            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
        }

        public async Task<Response<Category>> GetByCategoryIdAsync(string categoryId)
        {
            var category = await _categoryCollection.Find<Category>(x => x.Id == categoryId).FirstAsync();
            if (category == null)
            {
                return Response<Category>.Fail("Category not found", 404);
            }
            return Response<Category>.Success(_mapper.Map<Category>(category), 200);
        }
    }
}
