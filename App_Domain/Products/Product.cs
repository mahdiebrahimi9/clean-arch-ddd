using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Domain.Products
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string BookName { get; private set; }
        public int Price { get; private set; }

        public Product(string bookName, int price)
        {
            BooKExep(bookName, price);
            Id = Guid.NewGuid();
            BookName = bookName;
            Price = price;
        }

        public void EditBook(string bookName, int price)
        {
            BooKExep(bookName, price);
            BookName = bookName;
            Price = price;
        }

        private void BooKExep(string bookName, int price)
        {
            if (string.IsNullOrEmpty(bookName))
                throw new ArgumentNullException("BookName");

            if (price < 0)
                throw new ArgumentOutOfRangeException();
        }
    }
}
