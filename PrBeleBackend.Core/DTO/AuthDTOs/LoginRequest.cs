using System.ComponentModel.DataAnnotations;

namespace PrBeleBackend.Core.DTO.AuthDTOs
{
    public class LoginRequest
    {
        [Required,EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
