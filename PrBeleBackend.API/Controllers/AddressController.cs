using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrBeleBackend.Core.DTO.AddressDTOs;
using PrBeleBackend.Core.ServiceContracts.AddressContracts;
using System.Security.Claims;

namespace PrBeleBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Client")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressGetterService _addressGetterService;
        private readonly IAddressAdderSerivce _addressAdderSerivce;
        private readonly IAddressUpdaterService _addressUpdaterService;
        private readonly IAddressDeleterService _addressDeleterService;
        public AddressController(
            IAddressGetterService addressGetterService,
            IAddressAdderSerivce addressAdderSerivce,
            IAddressUpdaterService addressUpdaterService,
            IAddressDeleterService addressDeleterService
            )
        {
            _addressGetterService = addressGetterService;
            _addressAdderSerivce = addressAdderSerivce;
            _addressUpdaterService = addressUpdaterService;
            _addressDeleterService = addressDeleterService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAddress()
        {
            var customerId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            List<AddressResponse> addressResponses = await _addressGetterService.GetAllAddressByCustomerId(int.Parse(customerId));
            return Ok(new
            {
                status = 200,
                data = new
                {
                    address = addressResponses
                },
                message = "Data fetched successfully."
            });
        }
        [HttpPost]
        public async Task<IActionResult> AddAddress(AddressAddRequest addressAddRequest)
        {
            try
            {
                var customerId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                AddressResponse addressResponse = await _addressAdderSerivce.AddAddress(int.Parse(customerId), addressAddRequest);
                return Created("/", new
                {
                    status = 201,
                    data = addressResponse,
                    message = "Address added successfully."
                });
            }
            catch (Exception ex) { 
                return BadRequest(new
                {
                    status = 400,
                    message = ex.Message
                });
            }
            
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateAddress(int Id,AddressAddRequest addressAddRequest)
        {
            try
            {
                var customerId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                AddressResponse addressResponse = await _addressUpdaterService.UpdateAddress(int.Parse(customerId),Id,addressAddRequest);
                return Ok(new
                {
                    status = 200,
                    data = addressResponse,
                    message = "Address updated successfully."
                });
            }
            catch (Exception ex) {
                return BadRequest(new
                {
                    status = 400,
                    message = ex.Message
                });
            
            }
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAddress(int Id)
        {
            bool result = await _addressDeleterService.DeleteAddress(Id);
            if (result == false)
            {
                return NotFound(new
                {
                    status = 404,
                    message = "Address not found !"
                });
            }
            return Ok(new
            {
                status = 200,
                message = "Delete address success !"
            });
        }
    
    }
}
