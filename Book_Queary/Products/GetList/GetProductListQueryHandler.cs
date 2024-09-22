using Book_Infrastructre.Persestent.Ef;
using Book_Queary.Products.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Book_Queary.Products.GetList
{
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, List<ProductDto>>
    {
        private readonly BookDbContext _context;
        public GetProductListQueryHandler(BookDbContext contetx)
        {
            _context = contetx;
        }
        public async Task<List<ProductDto>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            return await _context.Products.Include(r => r.Images).Select(product => ProductMapper.MapProductToDto(product)).ToListAsync();
        }
    }
}
