using Microsoft.AspNetCore.Mvc;
using PrBeleBackend.Core.DTO.ProductDTOs;
using PrBeleBackend.Core.DTO.TagDTOs;
using PrBeleBackend.Core.ServiceContracts.TagContracts;

namespace PrBeleBackend.API.Areas.Admin.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class TagController : Controller
    {
        private readonly ITagGetterService _tagGetterService;

        public TagController(ITagGetterService tagGetterService)
        {
            this._tagGetterService = tagGetterService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTag()
        {
            try
            {
                List<TagResponse> tags = await this._tagGetterService.GetAllTag();

                return Ok(new
                {
                    status = 200,
                    data = new
                    {
                        tags = tags
                    },
                    message = "Get tag list success !"
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
