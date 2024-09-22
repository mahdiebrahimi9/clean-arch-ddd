using Book_Domain.Products.Repositorey;
using Book_Queary.Products.DTOs;
using MediatR;

namespace Book_Queary.Products.GetById
{
    public record GetProductByIdQuery(long id) : IRequest<ProductDto>;
}
