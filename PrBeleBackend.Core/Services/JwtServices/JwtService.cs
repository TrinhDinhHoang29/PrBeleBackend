using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.AccountDTOs;
using PrBeleBackend.Core.DTO.JwtDTOs;
using PrBeleBackend.Core.ServiceContracts.JwtContracts;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Services.JwtServices
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        private readonly IAccountRepository _accountRepository;

        public JwtService(IConfiguration configuration,IAccountRepository accountRepository)
        {
            _configuration = configuration;
            _accountRepository = accountRepository;
        }
        public  async Task<JwtResponse> GenarateJwt(AccountResponse account, List<string> permissions)
        {
            DateTime expiresF = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["Jwt:EXPIRATION_MINUTES"]));

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));


            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, account.Id.ToString().ToUpper()), //Subject (user id)
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), //JWT unique ID
                    new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString(),
                        ClaimValueTypes.Integer64),
                    new Claim(ClaimTypes.NameIdentifier, account.Email), //Unique name identifier of the user (Email)
                    new Claim(ClaimTypes.Role, account.Role.Name), //Unique name identifier of the user (Email)
                };

            foreach (var permission in permissions)
            {
                claims.Add(new Claim("Permission", permission));
            }

            var tokenGenerator = new JwtSecurityToken(_configuration["Jwt:Issuer"],
               _configuration["Jwt:Audience"],
               claims,
               expires: expiresF,
               signingCredentials: credentials);
            DateTime timeLifeRefreshToken = DateTime.Now.AddDays(1);

            string token = new JwtSecurityTokenHandler().WriteToken(tokenGenerator);
            return new JwtResponse()
            {
                JwtToken = token,
                Email = account.Email,
                ExpirationJwtToken = expiresF,
                RefreshTokenExpirationDateTime = timeLifeRefreshToken,
                RefreshToken = GenerateRefreshToken()
            };
        }
        private string GenerateRefreshToken()
        {
            byte[] bytes = new byte[64];
            var randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }
    }
}
