using PrBeleBackend.Core.DTO.ContactDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Domain.Entities
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required,StringLength(255)]
        public string? Title { get; set; }
        [Required]
        public string? Message { get; set; }
        [Required,StringLength(64)]
        public string? FullName { get; set; }
        [Required,EmailAddress]
        public string? Email { get; set; }
        [Required,Phone]
        public string? PhoneNumber { get; set; }
        public int Status { get; set; } 
        public bool Deleted { get; set; } = false;
        public DateTime CreatedAt { get; set; }
    }
    public static class ContactExtension
    {
        public static Contact ToContact(this ContactAddRequest contactResponse)
        {
            return new Contact()
            {
                Title = contactResponse.Title,
                Message = contactResponse.Message,
                FullName = contactResponse.FullName,
                Email = contactResponse.Email,
                PhoneNumber = contactResponse.PhoneNumber,

            };
        }
    }
}
