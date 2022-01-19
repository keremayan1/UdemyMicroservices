using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreeCourse.Services.Order.Application.Dtos;
using FreeCourse.Shared.Dto;
using MediatR;

namespace FreeCourse.Services.Order.Application.Queries
{
    public class GetOrdersByUserIdQuery:IRequest<Response<List<OrderDto>>>
    {
        public string UserId { get; set; }

    }
}
