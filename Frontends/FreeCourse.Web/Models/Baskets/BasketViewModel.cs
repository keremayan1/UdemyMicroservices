using System;
using System.Collections.Generic;
using System.Linq;

namespace FreeCourse.Web.Models.Baskets
{
    public class BasketViewModel
    {
        public BasketViewModel()
        {
            _basketItems = new List<BasketItemViewModel>();
        }
        public string UserId { get; set; }
        public string DiscountCode { get; set; }
        public int? DiscountRate { get; set; }
        private List<BasketItemViewModel> _basketItems { get; set; }
        public List<BasketItemViewModel> BasketItems { 
            get { 
                if (HasDiscount)
                {
                    _basketItems.ForEach(basketItem =>
                    {
                        var discountPrice = basketItem.Price * ((decimal)DiscountRate.Value   / 100);
                        basketItem.AppliedDiscount(Math.Round(basketItem.Price - discountPrice, 2));
                    });
                }
                return _basketItems;
            }
            set
            {
                _basketItems = value;
            }
        }

        public decimal TotalPrice => _basketItems.Sum(x => x.GetCurrentPrice * x.Quantity);
        public bool HasDiscount { get => !string.IsNullOrEmpty(DiscountCode) && DiscountRate.HasValue; }
    }
}
