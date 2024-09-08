using FluentAssertions;

namespace Calculator.Tests.Unit
{
    public class ComputingTest
    {
        Computing computing;
        public ComputingTest()
        {
            computing = new Computing();
        }
        [Fact]
        public void OddOrEven_Should_Return_Odd_When_Input_Is_OddValue()
        {

            var result = computing.OddOrEven(11);
            Assert.Equal("Odd", result);
        }

        [Theory(DisplayName = "even")]
        [InlineData(10)]
        public void OddOrEven_Should_Return_Even_When_Input_Is_EvenValue(int value)
        {

            var result = computing.OddOrEven(value);
            Assert.Equal("Even", result);
        }

        // BirthDate & CurrentYear Tests
        [Fact(DisplayName = "BirthDate Return Zero")]
        public void CalculateAge_Should_Zero_When_BirthDate_LessThan_Zero()
        {
            var result = computing.CalculateAge(-1, 1400);
            result.Should().Be(0);
        }
        [Fact]
        public void CalculateAge_Should_Throw_ArgumentException_When_BirthDate_And_CurrentYear_Zero()
        {
            var result = new Action(() =>
            {
                computing.CalculateAge(0, 0);

            });
            result.Should().Throw<ArgumentException>();
        }
        [Fact]
        public void CalculateAge_Should_CalculateAge_When_BirthDate_And_CurrentYear_Is_Valid_Date()
        {
            var result = computing.CalculateAge(1378, 1403);
            result.Should().Be(25);
        }
    }
}
