using Domain.Entities;
using MediatR;

namespace Application.Queries;

public record GetOrdersByUserIdQuery(int UserId) : IRequest<List<Order>>;
