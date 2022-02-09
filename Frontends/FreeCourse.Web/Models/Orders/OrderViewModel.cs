using System;
using System.Collections.Generic;

namespace FreeCourse.Web.Models.Orders
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }

        //Odeme Gecmisinde adres alanina ihtiyac olmadigindan dolayi alinmadi
        //public Address Address { get; set; }
        public string BuyerId { get; set; }
        public List<OrderItemViewModel> OrderItems { get; set; }
    }
}
