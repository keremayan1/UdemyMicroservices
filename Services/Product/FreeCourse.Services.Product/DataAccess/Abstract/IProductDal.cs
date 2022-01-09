using FreeCourse.Core.DataAccess.EntityFramework;
using FreeCourse.Services.Product.Entities;

namespace FreeCourse.Services.Product.DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Entities.Product>,IAsyncEntityRepository<Entities.Product>
    {
    }
}
