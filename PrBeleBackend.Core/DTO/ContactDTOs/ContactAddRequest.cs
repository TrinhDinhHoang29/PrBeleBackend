using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.DTO.ContactDTOs
{
    public class ContactAddRequest
    {
        [Required]
        [StringLength(100)]
        public string? Title { get; set; }
        [Required]
        public string? Message { get; set; }
        [Required, StringLength(64)]
        public string? FullName { get; set; }
        [Required, EmailAddress]
        public string? Email { get; set; }
        [Required, Phone]
        public string? PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
