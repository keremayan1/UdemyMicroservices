using System.Collections.Generic;
using System.Threading.Tasks;
using FreeCourse.Services.Product.Business.Abstract;
using FreeCourse.Services.Product.DataAccess.Abstract;
using FreeCourse.Services.Product.Entities;
using FreeCourse.Shared.Dto;

namespace FreeCourse.Services.Product.Business.Concrete
{
    public class ProductManager:IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public async Task<Response<IEnumerable<Entities.Product>>> GetAll()
        {
            var result = await _productDal.GetAllAsync();
           return Response<IEnumerable<Entities.Product>>.Success(result,200);
        }

        public async Task<Response<Entities.Product>> AddAsync(Entities.Product product)
        {
            await _productDal.AddAsync(product);
            return Response<Entities.Product>.Success(201);
        }

        public Response<Entities.Product> Add(Entities.Product products)
        {
            _productDal.Add(products);
            return Response<Entities.Product>.Success(200);
        }
    }
}
