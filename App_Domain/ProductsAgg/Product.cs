using Book_Domain.ProductsAgg;
using Book_Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Book_Domain.Products
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string BookName { get; private set; }
        public Money Price { get; private set; }
        public ICollection<ProductImage> Images { get; private set; }
        public Product(string bookName, Money price)
        {
            BooKExep(bookName);
            Id = Guid.NewGuid();
            BookName = bookName;
            Price = price;
        }


        public void AddImage(Guid productId, string imageName)
        {
            if (Images.Any(f => f.ProductId == productId))
                throw new Exception("adwd");
            Images.Add(new ProductImage(productId, imageName));
        }
        public void RemoveImage(Guid productId)
        {
            var image = Images.FirstOrDefault(f => f.ProductId == productId);
            if (image == null)
                throw new Exception("adqwd");
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
            if (string.IsNullOrEmpty(bookName))
                throw new ArgumentNullException("BookName");

        }
    }
}
