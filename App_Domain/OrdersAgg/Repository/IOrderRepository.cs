using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Domain.Orders.Repository
{
    public interface IOrderRepository
    {
        void Add(Order order);
        void Update(Order order);
        Task<Order> GetById(long id);
        Task SaveChanges();
    }
}
