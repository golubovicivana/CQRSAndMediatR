using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(Order newOrder)
        {
            _context.Orders.Add(newOrder);
            _context.SaveChanges();
        }

        public Order Get(int id)
        {
            return _context.Orders.FirstOrDefault(o => o.OrderId == id);
        }

        public void Update(Order updatedOrder)
        {
            _context.Orders.Update(updatedOrder);
            _context.SaveChanges();
        }

        public void UpdateStauts(Order updatedOrder)
        {
            _context.Orders.Attach(updatedOrder);
            _context.Entry(updatedOrder).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
