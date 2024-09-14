namespace Book_Application.Orders.DTOs
{
    public class OrderDto
    {
        public long UserId { get; set; }
        public long Id { get; set; }
        public long ProductId { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
    }
    public class AddOrderDto
    {
        public long ProductId { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public AddOrderDto(long productId, int price, int count)
        {
            ProductId = productId;
            Price = price;
            Count = count;
        }
    }
    public class FinallyOrderDto
    {
        public long OrderId { get; set; }
        public FinallyOrderDto(long orderId)
        {
            OrderId = orderId;
        }
    }
}
