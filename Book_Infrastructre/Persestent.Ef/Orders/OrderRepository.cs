using Book_Domain.Orders;
using Book_Domain.Orders.Repository;
using Microsoft.EntityFrameworkCore;

namespace Book_Infrastructre.Persestent.Ef.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BookDbContext _context;
        public OrderRepository(BookDbContext context)
        {
            _context = context;
        }
        public void Add(Order order)
        {
            _context.Add(order);
        }

        public async Task<Order> GetById(long id)
        {
            return await _context.Orders.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Order order)
        {
            _context.Update(order);
        }
    }
}
