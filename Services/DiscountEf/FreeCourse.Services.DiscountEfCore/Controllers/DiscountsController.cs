using System.Threading.Tasks;
using FreeCourse.Services.DiscountEfCore.Business.Abstract;
using FreeCourse.Services.DiscountEfCore.Entities;
using FreeCourse.Shared.ControllerBases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.Services.DiscountEfCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : CustomControllerBases
    {
        private IDiscountService _discountService;

        public DiscountsController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result =await _discountService.GetAll();
            return CreateActionResult(result);
        }
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _discountService.GetById(id);
            return CreateActionResult(result);
        }
        [HttpGet("getbycodeanduserid")]
        public async Task<IActionResult> GetByCodeAndUserId(string code,string userId)
        {
            var result = await _discountService.GetByCodeAndUserId(code,userId);
            return CreateActionResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Discount discount)
        {
            var result = await _discountService.Save(discount);
            return CreateActionResult(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Discount discount)
        {
            var result = await _discountService.Update(discount);
            return CreateActionResult(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result =await _discountService.Delete(id);
            return CreateActionResult(result);
        }
    }
}
