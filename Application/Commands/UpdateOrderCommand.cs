using MediatR;

namespace Application.Commands;

public record UpdateOrderCommand(int OrderId, string productName, int userId, decimal totalAmount) : IRequest<bool>;

