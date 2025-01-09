using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrBeleBackend.Core.DTO.AuthDTOs;
using PrBeleBackend.Core.DTO.CustomerDTOs;
using PrBeleBackend.Core.DTO.JwtDTOs;
using PrBeleBackend.Core.ServiceContracts.AuthContracts;
using PrBeleBackend.Core.ServiceContracts.CustomerContracts;
using System.Security.Claims;

namespace PrBeleBackend.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ICustomerGetterService _customerGetterService;
        private readonly ICustomerAdderService _customerAdderService;
        private readonly IAuthService _authService;
        public AuthController(
            ICustomerGetterService customerGetterService,
            ICustomerAdderService customerAdderService,
            IAuthService authService
            )
        {
            _customerGetterService = customerGetterService;
            _customerAdderService = customerAdderService;
            _authService = authService;
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            try
            {
                JwtResponse jwtResponse = await _authService.CliLogin(loginRequest);

                CustomerResponse? customerResponse = await _customerGetterService.GetCustomerByEmail(jwtResponse.Email);

                return Ok(new
                {
                    Customer = customerResponse,
                    jwt = new
                    {
                        accessToken = jwtResponse.JwtToken,
                        expireAccessToken = jwtResponse.ExpirationJwtToken,
                        refreshToken = jwtResponse.RefreshToken,
                        expireRefreshToken = jwtResponse.RefreshTokenExpirationDateTime,
                    }
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Register(CliRegisterRequest cliRegisterRequest)
        {
            try
            {
                CustomerResponse customerResponse = await _customerAdderService.AddCustomer(cliRegisterRequest);
                return Created("", new
                {
                    status = 201,
                    data = new
                    {
                        customer = customerResponse
                    },
                    message = "Successful register !"
                });
            }
            catch (Exception ex) {

                return BadRequest(new
                {
                    status = 200,
                    message = ex.Message
                });
            }
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
        [Authorize(Roles = "Client")]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            var customerId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            bool result = await _authService.CliLogout(int.Parse(customerId));
            if (!result) {
                return BadRequest(new
                {
                    status = 400,
                    message = "Logout is fail !"
                });
            }
            return Ok(new
            {
                status = 200,
                message = "Logout success !"

            });
        }
    }
}
