using Book_Domain.Products.Repositorey;
using Book_Domain.Shared;
using MediatR;

namespace Book_Application.Products.Edit
{
    public class EditProductCommandHandller : IRequestHandler<EditProductCommand>
    {
        private readonly IProductRepository _productRepository;
        public EditProductCommandHandller(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Unit> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(request.Id);
            product.EditBook(request.BookName, Money.FromRial(request.Price),request.Description);
            _productRepository.Update(product);
           await _productRepository.Save();
            return  Unit.Value;
        }
    }
}
