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
        public DateTime LastOperatingTime { get; set; }

        [Required]
        public int Status { get; set; }
        public bool Deleted { get; set; } = false; // true: Deleted, false: Not Deleted
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<AddressCustomer>? AddressCustomers { get; set; }

    }
}
