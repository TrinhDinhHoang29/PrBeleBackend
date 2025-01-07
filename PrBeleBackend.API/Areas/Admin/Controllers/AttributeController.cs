using PrBeleBackend.Core.DTO.AttributeDTOs;
using Microsoft.AspNetCore.Mvc;
using PrBeleBackend.Core.ServiceContracts.AttributeContracts;
using PrBeleBackend.Core.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using PrBeleBackend.API.Filters;

namespace PrBeleBackend.API.Areas.Admin.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    [Authorize]
    public class AttributeController : ControllerBase
    {
        private readonly IAttributeGetterService _attributeGetterService;
        private readonly IAttributeAdderService _attributeAdderService;
        private readonly IAttributeDeleterService _attributeDeleterService;
        private readonly IAttributeUpdaterService _attributeUpdaterService;
        private readonly IAttributeModifyService _attributeModifyService;

        public AttributeController(
            IAttributeGetterService attributeGetterService, 
            IAttributeAdderService attributeAdderService,
            IAttributeDeleterService attributeDeleterService,
            IAttributeUpdaterService attributeUpdaterService,
            IAttributeModifyService attributeModifyService
        )
        {
            this._attributeGetterService = attributeGetterService;
            this._attributeAdderService = attributeAdderService;
            this._attributeDeleterService = attributeDeleterService;
            this._attributeUpdaterService = attributeUpdaterService;
            this._attributeModifyService = attributeModifyService;   
        }

        [PermissionAuthorize("A-R")]
        [HttpGet]
        public async Task<IActionResult> GetFilteredAttributeValue([FromBody] AttributeValueGetterRequest req)
        {
            try
            {
                IEnumerable<AttributeValueResponse> attributeValues = await _attributeGetterService.GetFilteredAttributValue(req);

                return Ok(new
                {
                    status = 200,
                    data = new
                    {
                        attributeValues = attributeValues,
                        pagination = new
                        {
                            skip = req.Skip,
                            limit = req.Limit
                        }
                    },
                    message = "Get atribute value list success !"
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

        [PermissionAuthorize("A-C")]
        [HttpPost("{Id}")]
        public async Task<IActionResult> CreateAttributeValue([FromBody] AttributeValueAdderRequest req, int id)
        {
            try
            {
                AttributeValue attributeValue = await this._attributeAdderService.AddAttributeValue(req);

                return Ok(new
                {
                    status = 200,
                    data = new
                    {
                        attributeValue = attributeValue,
                    },
                    message = "Create atribute value success !"
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

        [PermissionAuthorize("A-U")]
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateAttributeValue([FromBody] AttributeValueUpdaterRequest req, int id)
        {
            try
            {
                AttributeValue attributeValue = await this._attributeUpdaterService.UpdateAttributeValue(req, id);

                return Ok(new
                {
                    status = 200,
                    data = new
                    {
                        attributeValue = attributeValue,
                    },
                    message = "Update atribute value success !"
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

        [PermissionAuthorize("A-M")]
        [HttpPatch("{Id}")]
        public async Task<IActionResult> ModifyAttributeValueStatus([FromBody] int status, int id)
        {
            try
            {
                AttributeValue attributeValue = await this._attributeModifyService.ModifyAttributeValueStatus(status, id);

                return Ok(new
                {
                    status = 200,
                    data = new
                    {
                        attributeValue = attributeValue,
                    },
                    message = "Modify atribute value status success !"
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

        [PermissionAuthorize("A-D")]
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAttributeValue(int id)
        {
            try
            {
                AttributeValue attributeValue = await this._attributeDeleterService.DeleteAtributeValue(id);

                return Ok(new
                {
                    status = 200,
                    data = new
                    {
                        attributeValue = attributeValue,
                    },
                    message = "Delete atribute value success !"
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
