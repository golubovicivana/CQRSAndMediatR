using MediatR;

namespace Application.Commands;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
{
    public Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(1);
    }
}
