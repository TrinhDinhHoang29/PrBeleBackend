using Microsoft.AspNetCore.Mvc;
using PrBeleBackend.Core.DTO.ProductDTOs;

namespace PrBeleBackend.API.Areas.Admin.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class TagController : Controller
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductByTagId(int id)
        {
            try
            {
                

                return Ok(new
                {
                    status = 200,
                    data = new
                    {
                     
                    },
                    message = "Get products by tag id success !"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = 400,
                    message = ex.Message
                });
            }
        }
    }
}
