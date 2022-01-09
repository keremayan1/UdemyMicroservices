using FreeCourse.Core.DataAccess.EntityFramework.Concrete;
using FreeCourse.Services.Product.DataAccess.Abstract;
using FreeCourse.Services.Product.DataAccess.Concrete.EntityFramework.MSSQL.Context;
using FreeCourse.Services.Product.Entities;

namespace FreeCourse.Services.Product.DataAccess.Concrete.EntityFramework.MSSQL
{
    public class EfProductDal : EfEntityRepository<Entities.Product, MssqlDbContext>, IProductDal
    {
        public EfProductDal(MssqlDbContext dbContext) : base(dbContext)
        {
        }
    }
}
