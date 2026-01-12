using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Queries;

public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, Order>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrderQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Order> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        return await _orderRepository.GetByIdAsync(request.Id);
    }
}

