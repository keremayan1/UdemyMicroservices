using FreeCourse.Services.Basket.Dto;
using FreeCourse.Services.Basket.Redis.DataAccess;
using FreeCourse.Shared.Dto;
using System.Text.Json;
using System.Threading.Tasks;

namespace FreeCourse.Services.Basket.Services
{
    public class BasketService2 : IBasketService
    {
        private readonly IBasketDal _basketDal;

        public BasketService2(IBasketDal basketDal)
        {
            _basketDal = basketDal;
        }

        public async Task<Response<bool>> Delete(string userId)
        {
       var result =    await  _basketDal.Delete(userId);
            return Response<bool>.Success(200);
        }

        public async Task<Response<BasketDto>> GetBasket(string userId)
        {
           var result = await _basketDal.Get(userId);
            return Response<BasketDto>.Success(result,200);
        }

        public Task<Response<BasketDto>> GetBasketByCourseId(string courseId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Response<bool>> SaveOrUpdate(BasketDto basketDto)
        {
            await _basketDal.SaveOrUpdate(basketDto.UserId,basketDto);
            return Response<bool>.Success(200);
        }
    }
}
