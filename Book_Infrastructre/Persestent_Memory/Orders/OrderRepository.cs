using Book_Domain.Orders;
using Book_Domain.Orders.Repository;

namespace Book_Infrastructre.Persestent_Memory.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private Context _context;
        public OrderRepository(Context context)
        {
            _context = context;
        }
        public void Add(Order order)
        {
            _context.Orders.Add(order);
        }

        public Order GetById(long id)
        {
            return _context.Orders.FirstOrDefault(f => f.Id == id);
        }

        public List<Order> GetList()
        {
            return _context.Orders;
        }

        public void SaveChanges()
        {
            //
        }

        public void Update(Order order)
        {
            var oldOrder = GetById(order.Id);
            _context.Orders.Remove(oldOrder);
            Add(order);
        }
    }
}
