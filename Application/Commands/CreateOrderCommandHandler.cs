using Application.Interfaces;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Commands;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
{
    private readonly IOrderRepository _orderRepository;

    public CreateOrderCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var newOrder = new Order
        {
            ProductName = request.productName,
            TotalAmount = request.totalAmount,
            UserId = request.userId,
            Created = DateTime.UtcNow,
            Status = OrderStatus.Created
        };

        return await _orderRepository.CreateAsync(newOrder);
    }
}
