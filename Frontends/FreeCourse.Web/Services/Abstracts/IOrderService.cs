using FreeCourse.Web.Models.Orders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeCourse.Web.Services.Abstracts
{
    public interface IOrderService
    {
        /// <summary>
        /// Senkron Iletisim - direk order microservicesine istek yapilacak
        /// </summary>
        /// <param name="checkoutInfoInput"></param>
        /// <returns></returns>
        Task<OrderCreatedViewModel> CreateOrder(CheckoutInfoInput checkoutInfoInput);
        /// <summary>
        /// Asenkron Iletisim - siparis bilgileri rabbitMQ'ya gonderilecek
        /// </summary>
        /// <param name="checkoutInfoInput"></param>
        /// <returns></returns>
        Task SuspendOrder(CheckoutInfoInput checkoutInfoInput);
        Task<List<OrderViewModel>> GetOrder();
    }
}
