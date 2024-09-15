using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Application.Products.Edit
{
    public class EditProductCommand : IRequest
    {
        public EditProductCommand(long id, string bookName, int price)
        {
            Id = id;
            BookName = bookName;
            Price = price;
        }
        public long Id { get; set; }
        public string BookName { get; set; }
        public int Price { get; set; }
    }
}
