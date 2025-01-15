using PrBeleBackend.Core.DTO.AuthDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Domain.Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required,StringLength(64)]
        public string? FullName { get; set; }
        [StringLength(16),Phone]
        public string? PhoneNumber { get; set; }
        [Required,StringLength(64),EmailAddress]
        public string? Email { get; set; }
        [StringLength(10)]
        public string? Sex { get; set; } // 0: Female, 1: Male, 2: Other
        public DateTime? Birthday { get; set; }
        [Required,StringLength(255)]
        public string Password { get; set; }

        public int TotalSpending { get; set; }

        [Required]
        public int Status { get; set; }
        public bool Deleted { get; set; } = false; // true: Deleted, false: Not Deleted
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<AddressCustomer>? AddressCustomers { get; set; }
        public List<Order> Orders { get; set; }
        public List<Rate> Rates { get; set; }
        public Cart Cart { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpirationDateTime { get; set; }

    }
    public static class CustomerExtension
    {
        public static Customer ToCustomer(this CliRegisterRequest cliRegisterRequest)
        {
            return new Customer()
            {
                FullName = cliRegisterRequest.FullName,
                Email = cliRegisterRequest.Email,
                Password = cliRegisterRequest.Password,
                PhoneNumber = cliRegisterRequest.PhoneNumber,
            };
        }
    }
}
