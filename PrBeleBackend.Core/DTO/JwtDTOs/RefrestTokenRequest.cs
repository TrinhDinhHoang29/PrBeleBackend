using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.DTO.JwtDTOs
{
    public class RefrestTokenRequest
    {
        [Required]
        public string? RefreshToken { get; set; }
        [Required]
        public DateTime RefreshTokenExpirationDateTime { get; set; }
    }
}
