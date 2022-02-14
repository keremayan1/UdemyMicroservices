using FreeCourse.Shared.Dto;
using System.Threading.Tasks;
using FreeCourse.Services.Basket.Dto;
using StackExchange.Redis;

namespace FreeCourse.Services.Basket.Services
{
    public interface IBasketService
    {
        Task<Response<BasketDto>> GetBasket(string userId);
        Task<Response<bool>> SaveOrUpdate(BasketDto basketDto);
        Task<Response<bool>>Delete(string userId);
        Task<Response<BasketDto>> GetBasketByCourseId(string courseId);
        
    }
}
