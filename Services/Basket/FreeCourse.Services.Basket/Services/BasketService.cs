using System;
using System.Threading.Tasks;
using FreeCourse.Services.Basket.Dto;
using FreeCourse.Shared.Dto;
using Mass= MassTransit;
using JsonSerializer = System.Text.Json.JsonSerializer;
using FreeCourse.Shared.Messages;

namespace FreeCourse.Services.Basket.Services
{
    public class BasketService:IBasketService
    {
        private IRedisService _redisService;
        

        public BasketService(IRedisService redisService)
        {
            _redisService = redisService;
           
        }

        public async Task<Response<BasketDto>> GetBasket(string userId)
        {
            var existBasket = await _redisService.GetDb().StringGetAsync(userId);
            if (String.IsNullOrEmpty(existBasket))
            {
            return   Response<BasketDto>.Fail("Basket Not found",404);
            }
            return  Response<BasketDto>.Success(JsonSerializer.Deserialize<BasketDto>(existBasket),200);
        }
        public async Task<Response<BasketDto>> GetBasketByCourseId(string courseId)
        {
            var existBasket = await _redisService.GetDb().StringGetAsync(courseId);
            if (String.IsNullOrEmpty(existBasket))
            {
                return Response<BasketDto>.Fail("Basket Not found", 404);
            }
            return Response<BasketDto>.Success(JsonSerializer.Deserialize<BasketDto>(existBasket), 200);
        }
        public async Task<Response<bool>> SaveOrUpdate(BasketDto basketDto)
        {
          
            var stock = await _redisService.GetDb()
                .StringSetAsync(basketDto.UserId, JsonSerializer.Serialize(basketDto));
         
         
            return stock ? Response<bool>.Success(204) : Response<bool>.Fail("basket could not update or save", 404);
        }

        public async Task<Response<bool>> Delete(string userId)
        {
            var delete = await _redisService.GetDb().KeyDeleteAsync(userId);
            return delete ? Response<bool>.Success(204) : Response<bool>.Fail("basket  not found", 404);
        }
    }
}
