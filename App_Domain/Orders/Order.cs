namespace Book_Domain.Orders
{
    public class Order
    {
        public long Id { get; private set; }
        public Guid ProductId { get; private set; }
        public int Price { get; private set; }
        public int Count { get; private set; }
        public DateTime CreationData { get; private set; }
        public bool IsFinally { get; private set; }
        public DateTime FinallyDate { get; private set; }
        public int TotalPrice => Count * Price;
        public Order(Guid productId, int price, int count)
        {
            CountExep(count);
            PriceExep(price);
            ProductId = productId;
            Price = price;
            Count = count;

        }

        public void IncreaseProductCount(int count)
        {
            CountExep(count);
            Count += Count;
        }
        public void Finally()
        {
            IsFinally = true;
            FinallyDate = DateTime.Now;

        }
        private void CountExep(int count)
        {
            if (count < 1)
                throw new ArgumentException();
        }
        private void PriceExep(int price)
        {
            if (price < 0)
                throw new ArgumentOutOfRangeException();
        }
    }
}
