using FreeCourse.Core.DataAccess.EntityFramework.Concrete;
using FreeCourse.Services.DiscountEfCore.DataAccess.Abstract;
using FreeCourse.Services.DiscountEfCore.DataAccess.Concrete.PostgreSQL.Context;
using FreeCourse.Services.DiscountEfCore.Entities;

namespace FreeCourse.Services.DiscountEfCore.DataAccess.Concrete.PostgreSQL
{
    public class EfPDiscountDal:EfEntityRepository<Discount,PostgreSqlContext>,IDiscountDal
    {
        public EfPDiscountDal(PostgreSqlContext context) : base(context)
        {
        }
    }
}
