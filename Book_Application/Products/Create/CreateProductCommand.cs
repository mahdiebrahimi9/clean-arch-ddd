using MediatR;

namespace Book_Application.Products.Create
{
    public class CreateProductCommand : IRequest
    {
        public CreateProductCommand(string bookName, int price, string descrption)
        {
            BookName = bookName;
            Price = price;
            Description = descrption;
        }
        public string BookName { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
    }
}
