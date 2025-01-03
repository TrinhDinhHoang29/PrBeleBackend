using Microsoft.AspNetCore.Mvc;
using PrBeleBackend.Core.DTO.AccountDTOs;
using PrBeleBackend.Core.DTO.AuthDTOs;
using PrBeleBackend.Core.DTO.JwtDTOs;
using PrBeleBackend.Core.ServiceContracts.AccountContracts;
using PrBeleBackend.Core.ServiceContracts.AuthContracts;

namespace PrBeleBackend.API.Areas.Admin.Controllers
{
    [Route("api/admin/[controller]/[Action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IAccountGetterService _accountGetterService;
        public AuthController(IAuthService authService,IAccountGetterService accountGetterService)
        {
            _authService = authService;
            _accountGetterService = accountGetterService;
        }
        
        [HttpPost]       
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            try
            {
                JwtResponse jwtResponse = await _authService.Login(loginRequest);
                AccountResponse? accountResponse = await _accountGetterService.GetAccountByEmail(jwtResponse.Email);

                return Ok(new
                {
                    Account = accountResponse,
                    jwtResponse = jwtResponse
                });
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
      
        }
        [HttpPost]
        public async Task<IActionResult> RefreshToken(RefrestTokenRequest refrestTokenRequest)
        {
            try
            {
                JwtResponse jwtResponse = await _authService.RefreshToken(refrestTokenRequest);
                AccountResponse? accountResponse = await _accountGetterService.GetAccountByEmail(jwtResponse.Email);

                return Ok(new
                {
                    jwtResponse = jwtResponse
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
