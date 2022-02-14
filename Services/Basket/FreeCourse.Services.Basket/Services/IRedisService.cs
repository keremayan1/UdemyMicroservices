using StackExchange.Redis;
using System.Collections.Generic;

namespace FreeCourse.Services.Basket.Services
{
    public interface IRedisService
    {
        void Connect();
        IDatabase GetDb(int db = 1);
        List<RedisKey> GetKeys();
    }
}
