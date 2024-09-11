using Book_Domain.Orders;
using Book_Domain.OrdersAgg.Events;
using Book_Domain.OrdersAgg.Exceptions;
using Book_Domain.OrdersAgg.Services;
using Book_Domain.Shared.Exceptions;
using FluentAssertions;
using NSubstitute;

namespace Clean_Arch_Book.Domain.Test.Unit.OrderAgg
{
    public class OrderTests
    {
        [Fact]
        public void ConstRuctor_Create_New_Order_User_Id()
        {
            //arrange
            var order = new Order(1);
            //assert
            order.UserId.Should().Be(1);
            order.IsFinally.Should().BeFalse();
        }
        [Fact]
        public void AddItem_Should_Throw_ProductNotFoundException_When_Is_Product_Not_Exist()
        {
            //arrange 
            var order = new Order(1);
            var orderDomainService = Substitute.For<IOrderDomainService>();
            orderDomainService.IsProductNotExsist(Arg.Any<long>()).Returns(true);
            //act
            var result = () => order.AddItem(1, 2, 3000, orderDomainService);
            //assert
            result.Should().ThrowExactly<ProductNotFoundException>();
        }
        [Fact]
        public void Add_NewItem_In_Order()
        {
            //arrange
            var order = new Order(1);
            var orderDomainService = Substitute.For<IOrderDomainService>();
            orderDomainService.IsProductNotExsist(Arg.Any<long>()).Returns(false);

            //act
            order.AddItem(1, 2, 3000, orderDomainService);
            //assert
            order.TotalItem.Should().Be(2);
        }
        [Fact]
        public void Should_NotAdd_New_Item_When_Item_Exist_Product()
        {
            //arrange
            var order = new Order(1);
            var orderDomainService = Substitute.For<IOrderDomainService>();
            orderDomainService.IsProductNotExsist(Arg.Any<long>()).Returns(false);
            order.AddItem(1, 2, 3000, orderDomainService);
            //act
            order.AddItem(1, 3, 3000, orderDomainService);
            //assert
            order.TotalItem.Should().Be(2);
        }
        [Fact]
        public void RemoveItem_Should_Product_Is_Exist()
        {
            //assert
            var order = new Order(1);
            var orderDomainService = Substitute.For<IOrderDomainService>();
            orderDomainService.IsProductNotExsist(Arg.Any<long>()).Returns(false);
            order.AddItem(1, 2, 3000, orderDomainService);
            //act
            order.RemoveItem(1);
            //assert
            order.TotalItem.Should().Be(0);
        }
        [Fact]
        public void Should_RemoveItem_Throw_InvalidDomainDataException_When_NotExist_Item_In_Order()
        {
            //arrange
            var order = new Order(2);
            //act
            var result = () => order.RemoveItem(1);
            //assert
            result.Should().ThrowExactly<InvalidDomainDataException>();
        }
        [Fact]
        public void Should_Finally_Order_And_Add_DomainEvent()
        {
            //arrange
            var order = new Order(1);
            //act
            order.Finally();
            //assert
            order.DomainEvents.Should().ContainEquivalentOf(new OrderFinalized(0, 1));
        }
    }
}
