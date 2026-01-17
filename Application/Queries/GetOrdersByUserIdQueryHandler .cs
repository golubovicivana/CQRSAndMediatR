using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Queries;

public class GetOrdersByUserIdQueryHandler
    : IRequestHandler<GetOrdersByUserIdQuery, List<Order>>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrdersByUserIdQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<List<Order>> Handle(
        GetOrdersByUserIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _orderRepository.GetByUserIdAsync(request.UserId);
    }
}