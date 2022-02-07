using FreeCourse.Web.Models.Discounts;
using System.Threading.Tasks;

namespace FreeCourse.Web.Services.Abstracts
{
    public interface IDiscountService
    {
        Task<DiscountViewModel> GetDiscount(string discountCode);

    }
}
