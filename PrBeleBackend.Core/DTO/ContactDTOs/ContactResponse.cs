using PrBeleBackend.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.DTO.ContactDTOs
{
    public class ContactResponse
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Message { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int Status { get; set; } // tinyint được map thành byte
        public DateTime CreatedAt { get; set; }
    }
    public static class ContactResponseExtension
    {
        public static ContactResponse ToContactResponse(this Contact contact)
        {
            return new ContactResponse
            {
                Id = contact.Id,
                Title = contact.Title,
                Email = contact.Email,
                Message = contact.Message,
                FullName = contact.FullName,
                PhoneNumber = contact.PhoneNumber,
                Status = contact.Status,
                CreatedAt = contact.CreatedAt,

            };
        }
    }
}
