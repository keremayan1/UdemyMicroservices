using FreeCourse.Services.Basket.Dto;
using FreeCourse.Services.Basket.Services;

namespace FreeCourse.Services.Basket.Redis.DataAccess
{
    public class RedisBasketDal : RedisRepository<BasketDto>, IBasketDal
    {
        public RedisBasketDal(IRedisService redisService) : base(redisService)
        {
        }
    }
}
