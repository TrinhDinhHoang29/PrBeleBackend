﻿using PrBeleBackend.Core.DTO.AttributeDTOs;
using Microsoft.AspNetCore.Mvc;
using PrBeleBackend.Core.ServiceContracts.AttributeContracts;
using PrBeleBackend.Core.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using PrBeleBackend.API.Filters;
using PrBeleBackend.Core.Enums;

namespace PrBeleBackend.API.Areas.Admin.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    //[Authorize]
    public class AttributeController : ControllerBase
    {
        private readonly IAttributeGetterService _attributeGetterService;
        private readonly IAttributeAdderService _attributeAdderService;
        private readonly IAttributeDeleterService _attributeDeleterService;
        private readonly IAttributeUpdaterService _attributeUpdaterService;
        private readonly IAttributeModifyService _attributeModifyService;
        private readonly IAttributeSorterService _attributeSorterService;

        public AttributeController(
            IAttributeGetterService attributeGetterService, 
            IAttributeAdderService attributeAdderService,
            IAttributeDeleterService attributeDeleterService,
            IAttributeUpdaterService attributeUpdaterService,
            IAttributeModifyService attributeModifyService,
            IAttributeSorterService attributeSorterService
        )
        {
            this._attributeGetterService = attributeGetterService;
            this._attributeAdderService = attributeAdderService;
            this._attributeDeleterService = attributeDeleterService;
            this._attributeUpdaterService = attributeUpdaterService;
            this._attributeModifyService = attributeModifyService;   
            this._attributeSorterService = attributeSorterService;
        }

        //[PermissionAuthorize("A-R")]
        [HttpGet]
        public async Task<IActionResult> GetFilteredAttributeValue(
            string? field,
            string? query,
            string? sort,
            int? status = 1,
            SortOrderOptions? order = SortOrderOptions.ASC,
            int page = 1,
            int limit = 10
        )
        {
            try
            {
                List<AttributeValueResponse> attributeValues = await _attributeGetterService.GetFilteredAttributeValue(field, query, status);

                List<AttributeValueResponse> attributeValuesPagination = attributeValues.Skip(limit * (page - 1)).Take(limit).ToList();

                List<AttributeValueResponse> attributeValuesSort = await this._attributeSorterService.SortAttributeValue(attributeValuesPagination, sort, order);

                return Ok(new
                {
                    status = 200,
                    data = new
                    {
                        attributeValues = attributeValuesSort,
                        pagination = new
                        {
                            currentPage = page,
                            totalPage = Math.Ceiling(Convert.ToDecimal(attributeValues.Count) / limit)
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

        //[PermissionAuthorize("A-C")]
        [HttpPost]
        public async Task<IActionResult> CreateAttributeValue([FromBody] AttributeValueAdderRequest req)
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

        //[PermissionAuthorize("A-U")]
        [HttpPut("{id}")]
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

        //[PermissionAuthorize("A-M")]
        [HttpPatch("{id}")]
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

        //[PermissionAuthorize("A-D")]
        [HttpDelete("{id}")]
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
