using Book_Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Domain.OrdersAgg
{
    public class OrderItem
    {
        public long Id { get; private set; }
        public long OrderId { get; protected set; }
        public Guid ProductId { get; private set; }
        public int Count { get; private set; }
        public Money Price { get; private set; }

        public OrderItem(long orderId, Guid productId, int count, Money price)
        {
            Guard(count);
            OrderId = orderId;
            ProductId = productId;
            Count = count;
            Price = price;
        }
        private void Guard(int count)
        {
            if (count < 1)
                throw new Exception("asdad");
        }
    }
}
