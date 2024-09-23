using Book_Application.Shared.Exceptions;
using Book_Domain.Products;
using Book_Domain.Products.Repositorey;
using Book_Domain.Shared;
using MediatR;

namespace Book_Application.Products.Create
{
    public class CreateProductCommandHandller : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMediator _mediator;
        public CreateProductCommandHandller(IProductRepository productRepository, IMediator mediator)
        {
            _productRepository = productRepository;
            _mediator = mediator;
        }
        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {

            var product = new Product(request.BookName, Money.FromToman(request.Price), request.Description);
            _productRepository.Add(product);
            await _productRepository.Save();

            foreach (var @event in product.DomainEvents)
            {
                await _mediator.Publish(@event);
            }
            return await Unit.Task;
        }
    }
}
