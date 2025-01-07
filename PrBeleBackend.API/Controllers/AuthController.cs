using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrBeleBackend.Core.DTO.CustomerDTOs;
using PrBeleBackend.Core.DTO.JwtDTOs;
using PrBeleBackend.Core.ServiceContracts.CustomerContracts;
using PrBeleBackend.Core.ServiceContracts.JwtContracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PrBeleBackend.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly ICustomerGetterService _customerGetterService;
        public AuthController(IJwtService jwtService,ICustomerGetterService customerGetterService)
        {
            _jwtService = jwtService;
            _customerGetterService = customerGetterService;
        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            CustomerResponse? customerResponse = await _customerGetterService.GetCustomerById(2);
            JwtResponse jwt = await _jwtService.GenarateJwtClient(customerResponse);
            return Ok(jwt);
        }
        [Authorize(Roles = "Client")]
        [HttpGet]
        public async Task<IActionResult> GetMe()
        {
            var customerId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            CustomerResponse? customerResponse = await _customerGetterService.GetCustomerById(int.Parse(customerId));
            return Ok(new
            {
                status = 200,
                data = new
                {
                    name = customerResponse.FullName,
                    email = customerResponse.Email,
                    phoneNumber = customerResponse.PhoneNumber,
                    sex = customerResponse.Sex,
                    birthDay = customerResponse.Birthday,
                    password = "***********",
                    createdAt = customerResponse.CreatedAt,
                },
                mesmessage = "Data fetched successfully."
            });
        }

    }
}
