using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Domain.Entities
{
    public class AddressCustomer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(64)]
        public string? FullName { get; set; }

        [Required]
        [Phone]
        [StringLength(16)]
        public string? Phone { get; set; }
        [Required]
        [StringLength(255)]
        public string? Address { get; set; }
        [Required]
        public bool IsDefault { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public Customer? Customer { get; set; }

    }
}
