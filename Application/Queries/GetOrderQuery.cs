using Domain.Entities;
using MediatR;

namespace Application.Queries;

public record GetOrderQuery(int Id) : IRequest<Order>;