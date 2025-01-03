using PrBeleBackend.Core.DTO.AuthDTOs;
using PrBeleBackend.Core.DTO.JwtDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.AuthContracts
{
    public interface IAuthService
    {
        public Task<JwtResponse> Login(LoginRequest loginRequest);
        public Task<JwtResponse> RefreshToken(RefrestTokenRequest refrestTokenRequest);

    }
}
