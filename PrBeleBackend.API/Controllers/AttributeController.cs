﻿using Microsoft.AspNetCore.Mvc;
using PrBeleBackend.Core.DTO.AttributeDTOs;
using PrBeleBackend.Core.ServiceContracts.AttributeContracts;

namespace PrBeleBackend.API.Controllers
{
    [Route("api/[controller]")]
    public class AttributeController : Controller
    {
        private readonly IAttributeGetterService _attributeGetterService;

        public AttributeController(
            IAttributeGetterService attributeGetterService
        )
        {
            this._attributeGetterService = attributeGetterService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAttributeType()
        {

            try
            {
                List<AttributeTypeResponse> attTyps = await this._attributeGetterService.GetAttributeType();

                return Ok(new
                {
                    status = 200,
                    data = new
                    {
                        attributeTypes = attTyps
                    },
                    message = "Get atribute type list success !"
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
