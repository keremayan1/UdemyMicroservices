using FreeCourse.Shared.Dto;
using FreeCourse.Web.Models.Discounts;
using FreeCourse.Web.Services.Abstracts;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FreeCourse.Web.Services.Concrete
{
    public class DiscountService : IDiscountService
    {
        HttpClient _httpClient;

        public DiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DiscountViewModel> GetDiscount(string discountCode)
        {
            //[controller]/[action]/{code}

            var response = await _httpClient.GetAsync($"discounts/getbycode/{discountCode}");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var discount = await response.Content.ReadFromJsonAsync<Response<DiscountViewModel>>();
            return discount.Data;
         
        }
    }
}
