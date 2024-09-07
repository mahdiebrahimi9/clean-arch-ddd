using Book_Application.Orders.DTOs;
using Book_Contract;
using Book_Domain.Orders;
using Book_Domain.Orders.Repository;

namespace Book_Application.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ISmsService _smsService;
        public OrderService(IOrderRepository orderRepository, ISmsService smsService)
        {
            _orderRepository = orderRepository;
            _smsService = smsService;
        }
        public void AddOrder(AddOrderDto dtoCommand)
        {
            var order = new Order(dtoCommand.ProductId);
            _orderRepository.Add(order);
            _orderRepository.SaveChanges();
        }

        public void FinallyOrder(FinallyOrderDto dtoCommand)
        {
            var order = _orderRepository.GetById(dtoCommand.OrderId);
            order.Finally();
            _orderRepository.Update(order);
            _orderRepository.SaveChanges();
            _smsService.SendSms(new SmsBody
            {
                PhoneNumber = "09038894052",
                Messgae = "0914738541"
            });

        }

        public OrderDto GetOrderById(long id)
        {
            var order = _orderRepository.GetById(id);
            return new OrderDto()
            {
                Id = order.Id,


            };
        }

        public List<OrderDto> GetOrderList()
        {
            return _orderRepository.GetList().Select(order => new OrderDto()
            {
                Id = order.Id,

            }).ToList();
        }
    }
}
