using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.DTO.CustomerDTOs
{
    public class CliCustomerChangePasswordRequest
    {
        [Required]
        public string? currentPassword {  get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
        ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one number, and one special character.")]
        public string? newPassword { get; set; }

        [Required,Compare("newPassword")]
        public string? confirmPassword { get; set; }
    }
}
