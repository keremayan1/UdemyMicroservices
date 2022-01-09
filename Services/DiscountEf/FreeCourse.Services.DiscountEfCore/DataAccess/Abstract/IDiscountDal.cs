using FreeCourse.Core.DataAccess.EntityFramework;
using FreeCourse.Services.DiscountEfCore.Entities;

namespace FreeCourse.Services.DiscountEfCore.DataAccess.Abstract
{
    public interface IDiscountDal:IEntityRepository<Discount>,IAsyncEntityRepository<Discount>
    {
    }
}
