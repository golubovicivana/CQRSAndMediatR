using Domain.Entities;

namespace Application.Interfaces;

public interface IOrderRepository
{
    public Order Get(int id);
    public void Create(Order newOrder);
    public void UpdateStauts(Order updatedOrder);
    public void Update(Order updatedOrder);
}
