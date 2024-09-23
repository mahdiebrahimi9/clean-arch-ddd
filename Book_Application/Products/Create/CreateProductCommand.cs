using MediatR;

namespace Book_Application.Products.Create
{
    public class CreateProductCommand : IRequest
    {
 

        public string BookName { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
    }
}
