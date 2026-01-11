using Domain.Entities;

namespace Application.Interfaces;

public interface IOrderRepository
{
    Task<int> CreateAsync(Order newOrder);
    Task<Order> GetByIdAsync(int id);
    Task UpdateStauts(Order updatedOrder);
    Task DeleteAsync(int id);   
}
