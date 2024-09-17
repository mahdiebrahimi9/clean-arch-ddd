using Book_Domain.Products;
using Book_Domain.ProductsAgg;
using Book_Domain.Shared;
using Book_Domain.Shared.Exceptions;
using Clean_Arch_Book.Domain.Test.Unit.Builders;
using FluentAssertions;

namespace Clean_Arch_Book.Domain.Test.Unit.ProductAgg
{
    public class ProductTests
    {
        private ProductBuilder _prodBuilder;

        public ProductTests()
        {
            _prodBuilder = new ProductBuilder();

        }

        [Fact]
        public void Constructor_Should_Create_Product_When_bookName_And_Price_Value_Is_Ok()
        {
            //arrange 
            _prodBuilder.SetBookName("test2").SetPrice(1000);
            //act
            var product = _prodBuilder.Build();
            //asserts
            product.BookName.Should().Be("test2");

        }
        [Fact]
        public void Constructor_Should_Throw_NullOrEmptyException_When_BookName_Data_Is_NullOrEmpty()
        {

            //act
            var action = () => _prodBuilder.SetBookName("").Build();
            //asserts
            action.Should().ThrowExactly<NullOrEmptyDomainDataException>().WithMessage("BookName is null or empty");
        }
        [Fact]
        public void EditBook_Should_Update_Product_When_BookName_And_Price_Data_Is_Ok()
        {
            //arrange
            var product = _prodBuilder.SetBookName("edit").SetPrice(1000).Build();
            //act
            product.EditBook("editBook", new Money(1000000),"des");
            // assert
            product.BookName.Should().Be("editBook");
            product.Price.Value.Should().Be(1000000);
        }
        [Fact]
        public void AddImage_Should_Add_New_Image_To_Product()
        {
            //arrange
            var product = _prodBuilder.SetBookName("test2").SetPrice(1000).Build();
            //act
            product.AddImage("test.png");
            // assert
            product.Images.Should().HaveCount(1);
        }
        [Fact]
        public void RemoveImage_Should_Remove_Image_When_ProductId_Data_Is_Ok()
        {
            //arrange 
            var product = _prodBuilder.SetBookName("test2").SetPrice(1000).Build();
            product.AddImage("test.png");
            //act
            product.RemoveImage(0);
            product.Images.Should().HaveCount(0);
        }
        [Fact]
        public void RemoveImage_Should_Throw_NullOrEmptyException_When_Image_NotExsist()
        {
            //arrange 
            var product = _prodBuilder.SetBookName("test2").SetPrice(1000).Build();

            //act
            var action = () => product.RemoveImage(0);
            // asserts
            action.Should().ThrowExactly<NullOrEmptyDomainDataException>().WithMessage("image not found");
        }
    }
}
