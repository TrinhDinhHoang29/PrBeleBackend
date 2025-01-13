using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using PrBeleBackend.API.Filters;
using PrBeleBackend.Core.DTO.AccountDTOs;
using PrBeleBackend.Core.DTO.AuthDTOs;
using PrBeleBackend.Core.DTO.CustomerDTOs;
using PrBeleBackend.Core.DTO.JwtDTOs;
using PrBeleBackend.Core.ServiceContracts.AuthContracts;
using PrBeleBackend.Core.ServiceContracts.CustomerContracts;
using PrBeleBackend.Core.ServiceContracts.EmailContracts;
using PrBeleBackend.Core.ServiceContracts.JwtContracts;
using System.Security.Claims;

namespace PrBeleBackend.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ICustomerGetterService _customerGetterService;
        private readonly ICustomerAdderService _customerAdderService;
        private readonly ICustomerUpdaterService _customerUpdaterService;
        private readonly IJwtService _jwtService;
        private readonly IEmailService _emailService;
        private readonly IAuthService _authService;
        private readonly IMemoryCache _memoryCache;

        public AuthController(
            ICustomerGetterService customerGetterService,
            ICustomerAdderService customerAdderService,
            ICustomerUpdaterService customerUpdaterService,
            IAuthService authService,
            IEmailService emailService,
            IMemoryCache memoryCache,
            IJwtService jwtService
            )
        {
            _customerGetterService = customerGetterService;
            _customerAdderService = customerAdderService;
            _authService = authService;
            _emailService = emailService;
            _memoryCache = memoryCache;
            _jwtService = jwtService;
            _customerUpdaterService = customerUpdaterService;
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
                return BadRequest(new
                {
                    status = 400,
                    message = ex.Message,
                });
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
        [HttpPost]
        public async Task<IActionResult> GetOTP([FromBody]string Email)
        {
            CustomerResponse? customerResponse = await _customerGetterService.GetCustomerByEmail(Email);
            if(customerResponse == null)
            {
                return BadRequest(new
                {
                    status = 400,
                    message = "Can't get account from email !"
                });
            }
            Random random = new Random();
            int otp = random.Next(1000, 10000);
            string body = $"<!DOCTYPE html>\r\n<html>\r\n<head>\r\n    <title>Your OTP Code</title>\r\n</head>\r\n<body>\r\n    <p>Dear {customerResponse.FullName},</p>\r\n    <p>We have received a request to verify your identity. Please use the One-Time Password (OTP) below to complete the verification process:</p>\r\n    <h2 style=\"color: #2e6c80;\">Your OTP Code: <strong>{otp}</strong></h2>\r\n    <p>This code is valid for <strong>2 minutes</strong>. For security reasons, do not share this code with anyone.</p>\r\n    <p>If you did not request this, please ignore this email or contact our support team immediately.</p>\r\n    <br>\r\n    <p>Thank you for using our services!</p>\r\n    <p>Best regards,</p>\r\n    <p><strong>Bele company</strong><br>\r\n    Support Team<br>\r\n    <a href=\"mailto:support@yourcompany.com\">support@bele.com</a> | 123456789</p>\r\n</body>\r\n</html>\r\n";
            await _emailService.SendEmailAsync(Email, "Your OTP Code for Secure Verification", body);
            _memoryCache.Set(Email, otp.ToString(), TimeSpan.FromMinutes(2));
            return Ok(new
            {
                status = 200,
                message = "Send otp success. "
            });

        }

        [HttpPost]
        public async Task<IActionResult> ValidateOTP(ValidateOtpRequest validateOtpRequest)
        {
            string? getOTP = _memoryCache.Get(validateOtpRequest.Email).ToString();
            if(getOTP == null)
            {
                return BadRequest(new
                {
                    status = 400,
                    message = "OTP fail."
                });
            }
            if(getOTP != validateOtpRequest.Otp)
            {
                return BadRequest(new
                {
                    status = 400,
                    message = "OTP fail."
                });
            }

            CustomerResponse? customerResponse = await _customerGetterService.GetCustomerByEmail(validateOtpRequest.Email);
            JwtResponse jwtResponse = await _jwtService.GenarateJwtClient(customerResponse);
            return Ok(new
            {
                status = 200,
                message = "Validate otp success",
                data = new
                {
                    jwt = jwtResponse.JwtToken,
                }
            });
        }

        [HttpPost]
        public async Task<IActionResult> RefreshToken(RefrestTokenRequest refrestTokenRequest)
        {
            try
            {
                JwtResponse jwtResponse = await _authService.CliRefreshToken(refrestTokenRequest);
                CustomerResponse? customerResponse = await _customerGetterService.GetCustomerByEmail(jwtResponse.Email);

                return Ok(new
                {
                    jwt = new
                    {
                        accessToken = jwtResponse.JwtToken,
                        expireAccessToken = jwtResponse.ExpirationJwtToken,
                        refreshToken = jwtResponse.RefreshToken,
                    }
                });
            }
            catch (Exception ex) { 
                return BadRequest(new
                {
                    status = 400,
                    message = ex.Message,
                });
            }
        }

        [PermissionAuthorize("Forgot password")]
        [HttpPost]
        public async Task<IActionResult> CreateNewPassword(CliForgotPasswordRequest cliForgotPasswordRequest)
        {
            try
            {
                var customerId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                CustomerResponse customerResponse = await _customerUpdaterService.CliUpdatePasswordFromForgotCustomer(int.Parse(customerId), cliForgotPasswordRequest);
                return Ok(new
                {
                    status = 200,
                    data = customerResponse,
                    message = "Create new password success."
                });
            }
            catch (Exception ex) {

                return BadRequest(new
                {
                    status = 400,
                    message = ex.Message,
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
                    FullName = customerResponse.FullName,
                    Email = customerResponse.Email,
                    PhoneNumber = customerResponse.PhoneNumber,
                    Sex = customerResponse.Sex,
                    Birthday = customerResponse.Birthday,
                    Password = "***********",
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
