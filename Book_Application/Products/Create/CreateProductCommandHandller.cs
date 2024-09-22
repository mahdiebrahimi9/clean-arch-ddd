using Book_Domain.Products;
using Book_Domain.Products.Repositorey;
using Book_Domain.Shared;
using MediatR;

namespace Book_Application.Products.Create
{
    public class CreateProductCommandHandller : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        public CreateProductCommandHandller(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {

            var product = new Product(request.BookName, Money.FromToman(request.Price), request.Description);
            _productRepository.Add(product);
            await _productRepository.Save();
            return await Unit.Task;
        }
    }
}
