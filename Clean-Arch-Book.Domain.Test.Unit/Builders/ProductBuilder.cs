using Book_Domain.Products;
using Book_Domain.ProductsAgg;
using Book_Domain.Shared;

namespace Clean_Arch_Book.Domain.Test.Unit.Builders
{
    public class ProductBuilder
    {
        private string _bookName = "test";
        private Money _price = new Money(1000000);
        private ICollection<ProductImage> _images;
        private string _description = "test";
        public ProductBuilder SetBookName(string bookName)
        {
            _bookName = bookName;
            return this;
        }
        public ProductBuilder SetPrice(int rialValue)
        {
            _price = new Money(rialValue);
            return this;
        }

        public Product Build()
        {
            return new Product(_bookName, _price, _description);
        }
    }
}
