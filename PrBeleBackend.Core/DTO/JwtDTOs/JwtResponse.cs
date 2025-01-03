using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.DTO.JwtDTOs
{
    public class JwtResponse
    {
        public string? JwtToken { get; set; }

        public DateTime ExpirationJwtToken {  get; set; }

        public string? Email { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpirationDateTime { get; set; }
    }
}
