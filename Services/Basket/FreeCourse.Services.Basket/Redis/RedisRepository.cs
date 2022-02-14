using FreeCourse.Services.Basket.Services;
using StackExchange.Redis;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace FreeCourse.Services.Basket.Redis
{
    public class RedisRepository<T> : IRedisRepository<T> where T : IRedisEntity
    {
        private readonly IRedisService _redisService;

        public RedisRepository(IRedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task<bool> Delete(string id)
        {
            var result =await  _redisService.GetDb().KeyDeleteAsync(id);
            return result;
        }

        public async Task<T> Get(string id)
        {
            var result = await _redisService.GetDb().StringGetAsync(id);
            return JsonSerializer.Deserialize<T>(result);
        }

        public  List<RedisKey> GetKeys()
        {
         return   _redisService.GetKeys(); 

        }

        public async Task<bool> SaveOrUpdate(string id,T entity)
        {
            var result = await _redisService.GetDb().StringSetAsync(id,JsonSerializer.Serialize(entity));
            return result;
        }
    }
}
