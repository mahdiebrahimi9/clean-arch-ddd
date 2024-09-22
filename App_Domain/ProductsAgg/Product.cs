using Book_Domain.ProductsAgg;
using Book_Domain.Shared;
using Book_Domain.Shared.Exceptions;

namespace Book_Domain.Products
{
    public class Product : AggregateRoot
    {
        private Product() { }
        public Product(string bookName, Money price, string description)
        {
            BooKExep(bookName);
            BookName = bookName;
            Money = price;
            Images = new List<ProductImage>();
            Description = description;
        }
        public string Description { get;private set; }
        public string BookName { get; private set; }
        public Money Money { get; private set; }
        public ICollection<ProductImage> Images { get; private set; }


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
        public void EditBook(string bookName, Money price, string description)
        {
            BooKExep(bookName);
            BookName = bookName;
            Money = price;
            Description = description;
        }

        private void BooKExep(string bookName)
        {
            NullOrEmptyDomainDataException.CheckString(bookName, nameof(bookName));

        }
    }
}
