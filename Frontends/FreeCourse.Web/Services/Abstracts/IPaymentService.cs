using FreeCourse.Web.Models.Payment;
using System.Threading.Tasks;

namespace FreeCourse.Web.Services.Abstracts
{
    public interface IPaymentService
    {
        Task<bool> ReceivePayment(PaymentInfoInput paymentInfoInput);
    }
}
