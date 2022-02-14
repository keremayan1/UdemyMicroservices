using FreeCourse.Services.Basket.Services;
using StackExchange.Redis;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeCourse.Services.Basket.Redis
{
    public interface IRedisRepository<T> where T : IRedisEntity
    {
        Task<bool> SaveOrUpdate(string id,T entity);
        Task<bool> Delete(string id);
        Task<T> Get(string id);
        List<RedisKey> GetKeys();
    }
}
