using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.AccountDTOs;
using PrBeleBackend.Core.DTO.AuthDTOs;
using PrBeleBackend.Core.DTO.JwtDTOs;
using PrBeleBackend.Core.DTO.RoleDTOs;
using PrBeleBackend.Core.ServiceContracts.AccountContracts;
using PrBeleBackend.Core.ServiceContracts.AuthContracts;
using PrBeleBackend.Core.ServiceContracts.RoleContracts;
using System.Security.Claims;

namespace PrBeleBackend.API.Areas.Admin.Controllers
{
    [Route("api/admin/[controller]/[Action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IAccountGetterService _accountGetterService;
        private readonly IRoleGetterService _roleGetterService;

        public AuthController(IAuthService authService,IAccountGetterService accountGetterService, IRoleGetterService roleGetterService)
        {
            _authService = authService;
            _accountGetterService = accountGetterService;
            _roleGetterService = roleGetterService;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetMe()
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            AccountResponse? accountResponse = await _accountGetterService.GetAccountByEmail(email);
            RoleResponse role = await _roleGetterService.GetRoleById(accountResponse.Role.Id);
            accountResponse.Role = role;
            return Ok(new
            {
                status = 200,
                data = new
                {
                    Account = accountResponse,
                },
                message = "Get account successful !"
            });
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
                    jwt = new
                    {
                        accessToken = jwtResponse.JwtToken,
                        expireAccessToken = jwtResponse.ExpirationJwtToken,
                        refreshToken = jwtResponse.RefreshToken,
                        expireRefreshToken = jwtResponse.RefreshTokenExpirationDateTime,
                    }
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
                    jwt = new
                    {
                        accessToken = jwtResponse.JwtToken,
                        expireAccessToken = jwtResponse.ExpirationJwtToken,
                        refreshToken = jwtResponse.RefreshToken,
                    }
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
