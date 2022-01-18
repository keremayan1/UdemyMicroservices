using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreeCourse.Services.Order.Domain.Core;

namespace FreeCourse.Services.Order.Domain.OrderAggregate
{
    public class OrderItem:Entity
    {
        public OrderItem(string productId, string productName, string pictureUrl, decimal price)
        {
            ProductId = productId;
            ProductName = productName;
            PictureUrl = pictureUrl;
            Price = price;
        }

        public string ProductId { get;private set; }
        public string ProductName { get;private set; }
        public string PictureUrl { get;private set; }
        public decimal Price { get;private set; }

        public void UpdateOrderItem2(OrderItem orderItem)
        {
            ProductName = orderItem.ProductName;
            PictureUrl = orderItem.PictureUrl;
            Price = orderItem.Price;
        }
        public void UpdateOrderItem(string productName,string pictureUrl,decimal price)
        {
            ProductName = productName;
            PictureUrl = pictureUrl;
            Price = price;
        }

    }
}
