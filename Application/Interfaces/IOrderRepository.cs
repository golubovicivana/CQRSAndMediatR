using Domain.Entities;

namespace Application.Interfaces;

public interface IOrderRepository
{
    Task<int> CreateAsync(Order newOrder);
    Task<Order> GetByIdAsync(int id);
    Task UpdateOrderAsync(Order updatedOrder);
    Task DeleteAsync(int id);
    Task<List<Order>> GetByUserIdAsync(int userId);
}
