using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailsCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetails
{
    public class CreateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateOrderDetailCommand orderDetailCommand)
        {
            await _repository.CreateAsync(new OrderDetail
            {
                OrderingId = orderDetailCommand.OrderingId,
                ProductAmount = orderDetailCommand.ProductAmount,
                ProductId = orderDetailCommand.ProductId,
                ProductName = orderDetailCommand.ProductName,
                ProductPrice = orderDetailCommand.ProductPrice,
                ProductTotalPrice = orderDetailCommand.ProductTotalPrice,                
            });
        }
    }
}
