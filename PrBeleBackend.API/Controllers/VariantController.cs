using Microsoft.AspNetCore.Mvc;
using PrBeleBackend.Core.DTO.ProductDTOs;
using PrBeleBackend.Core.DTO.VariantDTOs;
using PrBeleBackend.Core.ServiceContracts.VariantContracts;

namespace PrBeleBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VariantController : Controller
    {
        private readonly IVariantGetterService _variantGetterService;

        public VariantController(IVariantGetterService variantGetterService)
        {
            this._variantGetterService = variantGetterService;
        }

        [HttpGet]
        public async Task<IActionResult> GetVariantByProductIdAndColor(
            int productId,
            int colorId
        )
        {
            try
            {
                List<VariantSizeResponse> variants = await this._variantGetterService.GetVariantByProductIdAndColorId(productId, colorId);

                return Ok(new
                {
                    status = 200,
                    data = new
                    {
                        variants = variants
                    },
                    message = "Get variant size list success !"
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
