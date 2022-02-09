﻿using FreeCourse.Web.Models.Orders;
using FreeCourse.Web.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FreeCourse.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IBasketService _basketService;
        private readonly IOrderService _orderService;

        public OrderController(IBasketService basketService, IOrderService orderService)
        {
            _basketService = basketService;
            _orderService = orderService;
        }

        public async Task<IActionResult> Checkout()
        {
            var basket = await _basketService.Get();
            ViewBag.basket = basket;
            return View(new CheckoutInfoInput());
        }
        [HttpPost]
        public async Task<IActionResult> Checkout(CheckoutInfoInput input)
        {
            var orderStatus = await _orderService.CreateOrder(input);
            if (!orderStatus.IsSuccessful)
            {
                var basket = await _basketService.Get();
                ViewBag.error = orderStatus.Error;
                return View();
            }
            return View(nameof(SuccessfulCheckout), new { orderId = orderStatus.OrderId });
        }
        public IActionResult SuccessfulCheckout(int orderId)
        {
            ViewBag.orderId = orderId;
            return View();

        }
    }
}