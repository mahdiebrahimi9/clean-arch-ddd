using Book_Application.Orders;
using Book_Application.Orders.DTOs;
using Book_Contract;
using Book_Domain.Orders;
using Book_Domain.Orders.Repository;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReceivedExtensions;
namespace Clean_Arch_Book.Application.Test.Unit
{
    public class OrderServiceTests
    {
        private readonly OrderService _orderService;
        private readonly IOrderRepository _orderRepository;
        private readonly ISmsService _smsService;
        public OrderServiceTests()
        {
            _orderRepository = Substitute.For<IOrderRepository>();
            _smsService = Substitute.For<ISmsService>();
            _orderService = new OrderService(_orderRepository, _smsService);
        }
        [Fact]
        public void Should_Add_Order()
        {
            //arrange
            var command = new AddOrderDto(1, 3000, 2);
            //act 
            _orderService.AddOrder(command);
            //assert
            _orderRepository.Received(1).SaveChanges();
        }
        [Fact]
        public void Should_Finally_And_Send_Sms()
        {
            //arrange
            _orderRepository.GetById(Arg.Any<long>()).Returns(new Order(1));
            var command = new FinallyOrderDto(1);
            //act
            _orderService.FinallyOrder(command);
            //assert
            _orderRepository.Received(1).SaveChanges();
            _smsService.Received(1).SendSms(Arg.Any<SmsBody>());
        }
        [Fact]
        public void Should_Return_Order_By_Id()
        {
            //arrange 
            _orderRepository.GetById(Arg.Any<long>()).Returns(new Order(1));
            //act
            var result = _orderService.GetOrderById(1);
            //assert
            result.UserId.Should().Be(1);

        }
        [Fact]
        public void Should_Return_List_Of_Order()
        {
            //arrange
            _orderRepository.GetList().Returns(new List<Order>()
            {
                new Order(1),
                new Order(2)
            });
            //act
            var result = _orderService.GetOrderList();
            //assert
            result.Should().HaveCount(2);
        }
    }
}
