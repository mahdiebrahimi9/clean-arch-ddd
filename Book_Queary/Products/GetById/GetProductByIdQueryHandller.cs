using Book_Infrastructre.Persestent.Ef;
using Book_Queary.Products.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Book_Queary.Products.GetById
{
    public class GetProductByIdQueryHandller : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly BookDbContext _context;
        public GetProductByIdQueryHandller(BookDbContext context)
        {
            _context = context;
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == request.id);
            return  ProductMapper.MapProductToDto(product);
        }
    }
}
