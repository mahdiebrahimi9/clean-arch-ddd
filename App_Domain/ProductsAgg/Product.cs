using Book_Domain.ProductsAgg;
using Book_Domain.Shared;
using Book_Domain.Shared.Exceptions;

namespace Book_Domain.Products
{
    public class Product : AggregateRoot
    {
        public string BookName { get; private set; }
        public Money Price { get; private set; }
        public ICollection<ProductImage> Images { get; private set; }

        public Product(string bookName, Money price)
        {
            BooKExep(bookName);
            BookName = bookName;
            Price = price;
            Images = new List<ProductImage>();
        }


        public void AddImage(string imageName)
        {
            Images.Add(new ProductImage(Id, imageName));
        }
        public void RemoveImage(long productId)
        {
            var image = Images.FirstOrDefault(f => f.ProductId == productId);
            if (image == null)
                throw new NullOrEmptyDomainDataException("image not found");
            Images.Remove(image);
        }
        public void EditBook(string bookName, Money price)
        {
            BooKExep(bookName);
            BookName = bookName;
            Price = price;
        }

        private void BooKExep(string bookName)
        {
            NullOrEmptyDomainDataException.CheckString(bookName, nameof(bookName));

        }
    }
}
