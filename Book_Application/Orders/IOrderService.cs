using Book_Application.Orders.DTOs;

namespace Book_Application.Orders
{
    public interface IOrderService
    {
        void AddOrder(AddOrderDto dtoCommand);
        void FinallyOrder(FinallyOrderDto dtoCommand);
        List<OrderDto> GetOrderList();
        OrderDto GetOrderById(long id);
    }
}
