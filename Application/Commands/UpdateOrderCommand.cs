using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Commands;

public record UpdateOrderCommand(Order order) : IRequest<bool>;

