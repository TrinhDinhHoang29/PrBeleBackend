using Microsoft.AspNetCore.Mvc;
using PrBeleBackend.Core.ServiceContracts.VariantContracts;
using PrBeleBackend.Core.DTO.VariantDTOs;
using PrBeleBackend.Core.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using PrBeleBackend.API.Filters;

namespace PrBeleBackend.API.Areas.Admin.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    [Authorize]
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

        [PermissionAuthorize("V-R")]
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

        [PermissionAuthorize("V-R")]
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

        [PermissionAuthorize("V-C")]
        [HttpPost]
        public async Task<IActionResult> CreateVariant([FromBody] VariantAdderRequest req)
        {
            try
            {
                Variant variant = await this._variantAdderService.CreateVariant(req);

                return Ok(new
                {
                    status = 200,
                    data = new
                    {
                        variant = variant,

                    },
                    message = "Create variant success!"
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

        [PermissionAuthorize("V-U")]
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateVariant([FromBody] VariantUpdaterRequest req, [FromQuery] int id)
        {
            try
            {
                Variant variant = await this._variantUpdaterService.UpdateVariant(req, id);

                return Ok(new
                {
                    status = 200,
                    data = new
                    {
                        variant = variant,

                    },
                    message = "Update variant success!"
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

        [PermissionAuthorize("V-M")]
        [HttpPatch("{Id}")]
        public async Task<IActionResult> ModifyVariant([FromBody] VariantModifierRequest req, [FromQuery] int id)
        {
            try
            {
                Variant variant = await this._variantModifierService.UpdateVariant(req, id);

                return Ok(new
                {
                    status = 200,
                    data = new
                    {
                        variant = variant,

                    },
                    message = "Modify variant success!"
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

        [PermissionAuthorize("V-D")]
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteVariant([FromQuery] int id)
        {
            try
            {
                Variant variant = await this._variantDeleterService.DeleteVariant(id);

                return Ok(new
                {
                    status = 200,
                    data = new
                    {
                        variant = variant,

                    },
                    message = "Delete variant success!"
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
