using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FreeCourse.Services.Order.Application.Commands;
using FreeCourse.Services.Order.Application.Dtos;
using FreeCourse.Services.Order.Domain.OrderAggregate;
using FreeCourse.Services.Order.Infrastracture;
using FreeCourse.Shared.Dto;
using MediatR;

namespace FreeCourse.Services.Order.Application.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Response<CreatedOrderDto>>
    {
        private readonly OrderDbContext _orderDbContext;

        public CreateOrderCommandHandler(OrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }

        public async Task<Response<CreatedOrderDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var newAddress = new Address(request.Address.Province, request.Address.District,
                request.Address.Street, request.Address.ZipCode, request.Address.Line);
            var newOrders = new Domain.OrderAggregate.Order(request.BuyerId, newAddress);
            request.OrderItems.ForEach(x =>
            {
                newOrders.AddOrderItem(x.ProductId, x.ProductName, x.Price, x.PictureUrl);
            });
            await _orderDbContext.Orders.AddAsync(newOrders);
            var result = await _orderDbContext.SaveChangesAsync();
            return Response<CreatedOrderDto>.Success(new CreatedOrderDto { OrderId = newOrders.Id }, 200);
        }
    }
}
