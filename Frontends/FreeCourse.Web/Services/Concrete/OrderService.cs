using FreeCourse.Shared.Dto;
using FreeCourse.Web.Models.Orders;
using FreeCourse.Web.Models.Payment;
using FreeCourse.Web.Services.Abstracts;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FreeCourse.Web.Services.Concrete
{
    public class OrderService:IOrderService
    {
        private readonly HttpClient _httpClient;
        IPaymentService _paymentService;
        private readonly IBasketService _basketService;
        public OrderService(HttpClient httpClient, IPaymentService paymentService, IBasketService basketService)
        {
            _httpClient = httpClient;
            _paymentService = paymentService;
            _basketService = basketService;
        }

        public async Task<OrderCreatedViewModel> CreateOrder(CheckoutInfoInput checkoutInfoInput)
        {
            var basket = await _basketService.Get();
            var payment = new PaymentInfoInput
            {
                CardName = checkoutInfoInput.CardName,
                CardNumber = checkoutInfoInput.CardNumber,
                Expiration = checkoutInfoInput.Expiration,
                CVV = checkoutInfoInput.CVV,
                TotalPrice = basket.TotalPrice
            };
            var responsePayment = await _paymentService.ReceivePayment(payment);
            if (!responsePayment)
            {
                return new OrderCreatedViewModel { Error = "Ödeme Alınmadı", IsSuccessful = false };
            }


            var orderCreateInput = new OrderCreateInput
            {
               
                Address = new AddressCreateInput { Province = checkoutInfoInput.Province, District = checkoutInfoInput.District, Street = checkoutInfoInput.Street, Line = checkoutInfoInput.Line, ZipCode = checkoutInfoInput.ZipCode },
            };
            basket.BasketItems.ForEach(x =>
            {
                var orderItem = new OrderItemCreateInput
                {
                    ProductId = x.CourseId,
                    Price = x.GetCurrentPrice,
                    PictureUrl = "",
                    ProductName = x.CourseName,
                    
                };
                orderCreateInput.OrderItems.Add(orderItem);
            });


            var response = await _httpClient.PostAsJsonAsync<OrderCreateInput>("orders", orderCreateInput);
            if (!response.IsSuccessStatusCode)
            {
                return new OrderCreatedViewModel { Error = "Siparis Olusturulmadi", IsSuccessful = false };
            }
          var orderCreatedViewModel = await response.Content.ReadFromJsonAsync<Response<OrderCreatedViewModel>>();
            orderCreatedViewModel.Data.IsSuccessful = true;
            await _basketService.Delete();
            return orderCreatedViewModel.Data;
    
        }

        public async Task<List<OrderViewModel>> GetOrder()
        {
            var response = await _httpClient.GetFromJsonAsync<Response<List<OrderViewModel>>>("orders");
            return response.Data;
        }

        public Task SuspendOrder(CheckoutInfoInput checkoutInfoInput)
        {
            throw new System.NotImplementedException();
        }
    }
}
