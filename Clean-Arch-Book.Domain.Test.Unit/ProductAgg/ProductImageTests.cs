using Book_Domain.ProductsAgg;
using Book_Domain.Shared.Exceptions;
using FluentAssertions;

namespace Clean_Arch_Book.Domain.Test.Unit.ProductAgg
{
    public class ProductImageTests
    {
        [Fact]
        public void Constructor_Create_New_ImageName_To_Product()
        {
            //arrange
            var image = new ProductImage(1, "test.png");
            //assert
            image.ImageName.Should().Be("test.png");
        }
        [Fact]
        public void Constructor_Should_Throw_NullOrEmptyDomainDataException_When_ImageName_Is_Null()
        {
            //act
            var result = () => new ProductImage(1, "");

            //assert
            result.Should().ThrowExactly<NullOrEmptyDomainDataException>().WithMessage("ImageName is null or empty");
        }
    }
}
