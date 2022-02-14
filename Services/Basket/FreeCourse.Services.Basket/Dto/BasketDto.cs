using FreeCourse.Services.Basket.Redis;
using System.Collections.Generic;
using System.Linq;

namespace FreeCourse.Services.Basket.Dto
{
    public class BasketDto:IRedisEntity
    {
        public string UserId { get; set; }
        public string DiscountCode { get; set; }
        public int? DiscountRate { get; set; }
        public List<BasketItemDto> BasketItems { get; set; }

        public decimal TotalPrice => BasketItems.Sum(x => x.Price * x.Quantity);
    }
}
