using System.Threading.Tasks;
using FreeCourse.Services.Discount.Services;
using FreeCourse.Shared.ControllerBases;
using FreeCourse.Shared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.Services.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : CustomControllerBases
    {
        private IDiscountService _discountService;
        private ISharedIdentityService _identityService;

        public DiscountsController(IDiscountService discountService, ISharedIdentityService identityService)
        {
            _discountService = discountService;
            _identityService = identityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _discountService.GetAll();
            return CreateActionResult(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _discountService.GetById(id);
            return CreateActionResult(result);
        }

        [HttpGet("getcodeanduserid")]
        public async Task<IActionResult> GetByCodeAndUserId(string code, string userId)
        {
            var result = await _discountService.GetByCodeAndUserId(code, userId);
            return CreateActionResult(result);
        }
        [HttpGet]
        [Route("/api/[controller]/[action]/{code}")]
        public async Task<IActionResult> GetByCode(string code)

        {
            var userId = _identityService.GetUserId;

            var discount = await _discountService.GetByCodeAndUserId(code, userId);

            return CreateActionResult(discount);
        }
        [HttpPost]
        public async Task<IActionResult> Save(Models.Discount discount)
        {
            return CreateActionResult(await _discountService.Save(discount));
        }

        [HttpPut]
        public async Task<IActionResult> Update(Models.Discount discount)
        {
            return CreateActionResult(await _discountService.Update(discount));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return CreateActionResult(await _discountService.Delete(id));
        }
    }
}
