using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Enums;
using MediatR;

namespace Application.Commands;

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, bool>
{
    private readonly IOrderRepository _orderRepository;

    public UpdateOrderCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<bool> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(command.OrderId);
        if (order == null)
            return default;

        order.ProductName = command.productName;
        order.UserId = command.userId;
        order.Created = DateTime.UtcNow;
        order.TotalAmount = command.totalAmount;
        order.Status = OrderStatus.Updated;

        await _orderRepository.UpdateOrderAsync(order);

        return true;
    }
}
