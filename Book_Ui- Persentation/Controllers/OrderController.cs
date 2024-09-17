using Microsoft.AspNetCore.Mvc;

namespace Book_Ui__Persentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
  
        [HttpGet]
        public IActionResult GetOrder()
        {
            return Ok();
        }
    }
}
