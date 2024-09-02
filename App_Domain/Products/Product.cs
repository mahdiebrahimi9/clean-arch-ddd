using Book_Domain.Shared;
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
        public Money Price { get; private set; }

        public Product(string bookName, Money price)
        {
            BooKExep(bookName);
            Id = Guid.NewGuid();
            BookName = bookName;
            Price = price;
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
