using Book_Application.Products.Create;
using Book_Application.Products.Edit;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Book_Ui__Persentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductComtroller : ControllerBase
    {
        private IMediator _mediator;
        public ProductComtroller(IMediator mediator)
        {
            _mediator = mediator;
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
