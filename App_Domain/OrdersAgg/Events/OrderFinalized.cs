using Book_Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Domain.OrdersAgg.Events
{
    public class OrderFinalized : BaseDomainEvent
    {
        public long OrderId { get; private set; }
        public long UserId { get; private set; }
        public OrderFinalized(long orderId, long userId)
        {
            OrderId = orderId;
            UserId = userId;
        }
    }
}
