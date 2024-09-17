using Book_Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Domain.OrdersAgg
{
    public class OrderItem : BaseEntity
    {
        private OrderItem() { }

        public OrderItem(long orderId, long productId, int count, Money price)
        {
            Guard(count);
            OrderId = orderId;
            ProductId = productId;
            Count = count;
            Price = price;
        }
        public long OrderId { get; protected set; }
        public long ProductId { get; private set; }
        public int Count { get; private set; }
        public Money Price { get; private set; }


        private void Guard(int count)
        {
            if (count < 1)
                throw new Exception("asdad");
        }
    }
}
