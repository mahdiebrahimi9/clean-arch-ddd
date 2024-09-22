using Book_Domain.OrdersAgg;
using Book_Domain.OrdersAgg.Events;
using Book_Domain.OrdersAgg.Exceptions;
using Book_Domain.OrdersAgg.Services;
using Book_Domain.Shared;
using Book_Domain.Shared.Exceptions;

namespace Book_Domain.Orders
{
    public class Order : AggregateRoot
    {
        private Order() { }
        public Order(long userId)
        {
            UserId = userId;
            Items = new List<OrderItem>();
        }
        public long UserId { get; private set; }
        public ICollection<OrderItem> Items { get; private set; }
        public bool IsFinally { get; private set; }
        public DateTime FinallyDate { get; private set; }
        public int TotalPrice => Items.Sum(r => r.Price.Value);
        public int TotalItem { get; private set; }


        public void AddItem(long productId, int count, int price, IOrderDomainService orderDomainService)
        {
            if (orderDomainService.IsProductNotExsist(productId))
                throw new ProductNotFoundException();

            if (Items.Any(f => f.ProductId == productId))
                return;
            Items.Add(new OrderItem(Id, productId, count, Money.FromToman(price)));
            TotalItem += count;
        }
        public void RemoveItem(long productId)
        {
            var item = Items.FirstOrDefault(f => f.ProductId == productId);
            if (item == null)
                throw new InvalidDomainDataException();
            Items.Remove(item);
            TotalItem -= item.Count;
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
