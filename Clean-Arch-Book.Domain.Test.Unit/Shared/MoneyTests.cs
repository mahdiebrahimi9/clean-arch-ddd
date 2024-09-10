using Book_Domain.Shared;
using Book_Domain.Shared.Exceptions;
using FluentAssertions;

namespace Clean_Arch_Book.Domain.Test.Unit.Shared
{
    public class MoneyTests
    {

        [Fact]
        public void Constructor_Should_Add_New_Money_When_Value_Bigger_Than_Zero()
        {
            //arrange
            var money = new Money(1000);
            //assert
            money.Value.Should().Be(1000);
        }
        [Fact]
        public void Constructor_Should_Throw_InvalidDomainDataException_When_Value_Less_Than_Zero()
        {
            //act
            var result = () => new Money(-100);
            //assert
            result.Should().ThrowExactly<InvalidDomainDataException>();
        }
        [Fact]
        public void FromRial_Add_New_Money()
        {
            //arrange
            var money = Money.FromRial(1000);
            //assert
            money.Value.Should().Be(1000);
        }
        [Fact]
        public void FromToman_Add_New_Money_When_Format_Toman()
        {
            var fromToman = 1000;
            //arrange
            var result = Money.FromToman(fromToman);
            //assert
            result.Value.Should().Be(fromToman * 10);
        }
        [Fact]
        public void PlusOperator_Should_Sum_Money_Value()
        {
            //arrange
            var money = new Money(10000);
            var money2 = new Money(50000);

            //act
            var result = money + money2;
            result.Value.Should().Be(60000);
        }
        [Fact]
        public void MinusOperator_Should_Subtract_Money_Value()
        {
            //arrange
            var money = new Money(10000);
            var money2 = new Money(50000);
            //act 
            var result = money2 - money;
            //assert
            result.Value.Should().Be(40000);

        }
        [Fact]
        public void EqualOperator_Should_To_Be_Equal_Money_Value()
        {
            //arrange 
            var money = new Money(1000);
            var money2 = new Money(1000);
            //act
            var result = money == money2;
            result.Should().BeTrue();
        }
        [Fact]
        public void UnEqualOperator_Should_To_Be_UnEqual_Value()
        {
            //arrange
            var money = new Money(4000);
            var money2 = new Money(2000);
            //act 
            var result = money != money2;
            //assert
            result.Should().BeTrue();
        }
        [Fact]
        public void ToString_Should_Return_Value_StringFormat()
        {
            //arrange
            var money = new Money(10000);
            //act
            var result = money.ToString();
            //assert
            result.Should().Be("10,000");
        }
    }
}
