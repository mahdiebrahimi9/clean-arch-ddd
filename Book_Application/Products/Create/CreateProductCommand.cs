using MediatR;

namespace Book_Application.Products.Create
{
    public class CreateProductCommand : IRequest
    {
        public CreateProductCommand(string bookName, int price)
        {
            BookName = bookName;
            Price = price;
        }
        public string BookName { get; set; }
        public int Price { get; set; }
    }
}
