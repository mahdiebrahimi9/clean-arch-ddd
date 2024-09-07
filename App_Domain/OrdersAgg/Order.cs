using Book_Domain.OrdersAgg;
using Book_Domain.OrdersAgg.Events;
using Book_Domain.OrdersAgg.Exceptions;
using Book_Domain.OrdersAgg.Services;
using Book_Domain.Shared;
using System.Runtime.CompilerServices;

namespace Book_Domain.Orders
{
    public class Order : AggregateRoot
    {
        public long UserId { get; private set; }
        public ICollection<OrderItem> Items { get; private set; }
        public DateTime CreationData { get; private set; }
        public bool IsFinally { get; private set; }
        public DateTime FinallyDate { get; private set; }
        public int TotalPrice;
        public Order(long userId)
        {
            UserId = userId;
        }


        public void AddItem(long productId, int count, int price, IOrderDomainService orderDomainService)
        {
            if (orderDomainService.IsProductNotExsist(productId))
                throw new ProductNotFoundException();

            if (Items.Any(f => f.ProductId == productId))
                throw new Exception("asdqwdqd");
            Items.Add(new OrderItem(Id, productId, count, Money.FromToman(price)));
        }
        public void RemoveItem(long productId)
        {
            var item = Items.FirstOrDefault(f => f.ProductId == productId);
            if (item == null)
                throw new Exception("asdqwdq");
            Items.Remove(item);
        }
        public void IncreaseProductCount(int count)
        {

        }
        public void Finally()
        {
            IsFinally = true;
            FinallyDate = DateTime.Now;
            AddDomainEvent(new OrderFinalized(Id, UserId));
        }

    }
}
