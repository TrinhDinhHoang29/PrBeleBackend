using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.DTO.ContactDTOs
{
    public class ContactUpdateRequest
    {
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string? Title { get; set; }
        [Required]
        public string? Message { get; set; }
        [Required, StringLength(64)]
        public string? FullName { get; set; }
        [Required, EmailAddress]
        public string? Email { get; set; }
        [Required, Phone]
        public string? PhoneNumber { get; set; }
        public byte Status { get; set; } // tinyint được map thành byte
        public bool Deleted { get; set; } = false;
        public DateTime CreatedAt { get; set; }
    }
}
