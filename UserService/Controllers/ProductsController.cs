using Microsoft.AspNetCore.Mvc;

namespace UserService.Controllers
{
    [Route("api/u/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // GET api/products/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return id.ToString();
        }
    }
}