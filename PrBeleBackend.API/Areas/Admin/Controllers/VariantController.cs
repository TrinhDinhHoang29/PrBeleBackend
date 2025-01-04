using Microsoft.AspNetCore.Mvc;
using PrBeleBackend.Core.ServiceContracts.VariantContracts;
using PrBeleBackend.Core.DTO.VariantDTOs;

namespace PrBeleBackend.API.Areas.Admin.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class VariantController : Controller
    {
        private readonly IVariantGetterService _variantGetterService;
        private readonly IVariantAdderService _variantAdderService;
        private readonly IVariantUpdaterService _variantUpdaterService;
        private readonly IVariantModifierService _variantModifierService;
        private readonly IVariantDeleterService _variantDeleterService;

        public VariantController(
            IVariantGetterService variantGetterService,
            IVariantAdderService variantAdderService, 
            IVariantUpdaterService variantUpdaterService, 
            IVariantModifierService variantModifierService, 
            IVariantDeleterService variantDeleterService
        )
        {
            this._variantGetterService = variantGetterService;
            this._variantAdderService = variantAdderService;
            this._variantUpdaterService = variantUpdaterService;
            this._variantModifierService = variantModifierService;
            this._variantDeleterService = variantDeleterService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFilteredVariant([FromBody] VariantGetterRequest req)
        {
            try
            {
                IEnumerable<VariantResponse> variants = await this._variantGetterService.GetFilteredVariant(req);

                return Ok(new
                {
                    status = 200,
                    data = new
                    {
                        variants = variants,
                        pagination = new
                        {
                            skip = req.Skip,
                            limit = req.Limit,
                        }
                    },
                    message = "Get variants success!"
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

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetVariantDetail(int id)
        {
            try
            {
                VariantResponse variant = await this._variantGetterService.GetVariantDetail(id);

                return Ok(new
                {
                    status = 200,
                    data = new
                    {
                        variant = variant,

                    },
                    message = "Get variant success!"
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
