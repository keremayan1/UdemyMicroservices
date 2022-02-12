using System.Threading.Tasks;
using FreeCourse.Services.Order.Application.Commands;
using FreeCourse.Services.Order.Application.Dtos;
using FreeCourse.Services.Order.Application.Handlers;
using FreeCourse.Services.Order.Application.Queries;
using FreeCourse.Shared.ControllerBases;
using FreeCourse.Shared.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.Services.Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : CustomControllerBases
    {
        private IMediator _mediator;
        private ISharedIdentityService _sharedIdentityService;

        public OrdersController(IMediator mediator, ISharedIdentityService sharedIdentityService)
        {
            _mediator = mediator;
            _sharedIdentityService = sharedIdentityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var result = await _mediator.Send(new GetOrdersByUserIdQuery{UserId = _sharedIdentityService.GetUserId});
            return CreateActionResult(result);

        }

        [HttpPost]
        public async Task<IActionResult> SaveOrders(CreateOrderCommand createOrderCommand)
        {
           
            var response = await _mediator.Send(createOrderCommand);
            return CreateActionResult(response);

        }

    }
}
