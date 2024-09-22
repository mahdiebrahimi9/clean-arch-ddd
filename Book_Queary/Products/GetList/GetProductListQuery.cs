using Azure.Core;
using Book_Queary.Products.DTOs;
using MediatR;

namespace Book_Queary.Products.GetList
{
    public record GetProductListQuery : IRequest<List<ProductDto>>;
}
