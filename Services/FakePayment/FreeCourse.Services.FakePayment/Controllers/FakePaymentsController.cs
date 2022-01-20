using FreeCourse.Shared.ControllerBases;
using FreeCourse.Shared.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.Services.FakePayment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakePaymentsController : CustomControllerBases
    {
        [HttpPost]
        public IActionResult ReceivePayment()
        {
            return CreateActionResult<NoContent>(Response<NoContent>.Success(200));
        }
    }
}
