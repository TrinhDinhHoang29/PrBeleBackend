using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrBeleBackend.Core.DTO.CustomerDTOs;
using PrBeleBackend.Core.ServiceContracts.CustomerContracts;
using System.Security.Claims;

namespace PrBeleBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Client")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerUpdaterService _customerUpdaterService;
        public CustomerController(ICustomerUpdaterService customerUpdaterService)
        {
            _customerUpdaterService = customerUpdaterService;
        }
        [HttpPut]
        public async Task<IActionResult> UpdateInfo(CliCustomerUpdateRequest cliCustomerUpdateRequest)
        {
            try
            {
                var customerId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                CustomerResponse customerResponse = await _customerUpdaterService.CliUpdateCustomer(int.Parse(customerId),cliCustomerUpdateRequest);
                return Ok(new
                {
                    status = 200,
                    data = new
                    {
                        FullName = customerResponse.FullName,
                        PhoneNumber = customerResponse.PhoneNumber,
                        Birthday = customerResponse.Birthday,
                    },
                    message = "Profile updated successfully."

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

        [HttpPost]
        public async Task<IActionResult> ChangePassword(CliCustomerChangePasswordRequest cliCustomerChangePassword)
        {
            try
            {
                var customerId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                CustomerResponse customerResponse = await _customerUpdaterService.CliUpdatePasswordCustomer(int.Parse(customerId), cliCustomerChangePassword);
                return Ok(new
                {
                    status = 200,
                    data = new
                    {

                    },
                    message = "Password changed successfully."

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
