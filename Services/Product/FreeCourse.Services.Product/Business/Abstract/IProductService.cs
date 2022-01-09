using System.Collections.Generic;
using System.Threading.Tasks;
using FreeCourse.Services.Product.Entities;
using FreeCourse.Shared.Dto;

namespace FreeCourse.Services.Product.Business.Abstract
{
    public interface IProductService
    {
        Task<Response<IEnumerable<Entities.Product>>> GetAll();
        Task<Response<Entities.Product>> AddAsync(Entities.Product product);
        Response<Entities.Product> Add(Entities.Product products);
    }
}
