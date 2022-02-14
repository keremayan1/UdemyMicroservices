using FreeCourse.Services.Basket.Dto;

namespace FreeCourse.Services.Basket.Redis.DataAccess
{
    public interface IBasketDal : IRedisRepository<BasketDto>
    {
    }
}
