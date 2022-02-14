using System.Threading.Tasks;
using FreeCourse.Services.Basket.Dto;
using FreeCourse.Services.Basket.Services;
using FreeCourse.Shared.ControllerBases;
using FreeCourse.Shared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.Services.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : CustomControllerBases
    {
        private IBasketService _basketService;
        private ISharedIdentityService _sharedIdentityService;

        public BasketsController(IBasketService basketService, ISharedIdentityService sharedIdentityService)
        {
            _basketService = basketService;
            _sharedIdentityService = sharedIdentityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasket()
        {
             return CreateActionResult(await _basketService.GetBasket(_sharedIdentityService.GetUserId));
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrUpdateBasket(BasketDto basket)
        {
            basket.UserId = _sharedIdentityService.GetUserId;
            var response = await _basketService.SaveOrUpdate(basket);
            return CreateActionResult(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            var response = await _basketService.Delete(_sharedIdentityService.GetUserId);
            return CreateActionResult(response);
        }
    }
}
