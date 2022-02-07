using FreeCourse.Web.Models.Baskets;
using FreeCourse.Web.Models.Discounts;
using FreeCourse.Web.Services.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FreeCourse.Web.Controllers
{
    [Authorize]
    public class BasketController : Controller
    {
        ICatalogService _courseService;

        public BasketController(ICatalogService courseService, IBasketService basketService)
        {
            _courseService = courseService;
            _basketService = basketService;
        }

        IBasketService _basketService;
        public async Task<IActionResult> Index()
        {

            return View(await _basketService.Get());
        }
        public async Task<IActionResult> AddBasketItem(string courseId)
        {
            var course = await _courseService.GetByCourseId(courseId);
            var basketItem = new BasketItemViewModel
            {
                CourseId = course.Id,
                CourseName = course.Name,
                Price = course.Price,
            };
            await _basketService.AddBasketItem(basketItem);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> RemoveBasketItem(string courseId)
        {
            await _basketService.RemoveBasketItem(courseId);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ApplyDiscount(DiscountApplyInput discountApplyInput)
        {
            var discountStatus = await _basketService.ApplyDiscount(discountApplyInput.Code);
            TempData["discountStatus"]=discountStatus;
            return RedirectToAction(nameof(Index));
        } 
        public async Task<IActionResult> CancelApplyDiscount(DiscountApplyInput discountApplyInput)
        {
           await _basketService.CancelApplyDiscount();
            return RedirectToAction(nameof(Index));

        }
    }
}
