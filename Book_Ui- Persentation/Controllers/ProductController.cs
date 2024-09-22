using Book_Application.Products.Create;
using Book_Application.Products.Edit;
using Book_Queary.Products.DTOs;
using Book_Queary.Products.GetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Book_Ui__Persentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<List<ProductDto>> GetProducts()
        {
            return await _mediator.Send(new GetProductListQuery());

        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> EditProduct(EditProductCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
