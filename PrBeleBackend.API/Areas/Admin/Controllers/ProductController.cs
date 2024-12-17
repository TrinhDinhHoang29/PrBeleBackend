using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PrBeleBackend.API.Areas.Admin.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("ok");
        }
    }
}
