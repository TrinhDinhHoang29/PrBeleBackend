using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.DTO.AddressDTOs
{
    public class AddressAddRequest
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required,Phone]
        public string? PhoneNumber { get; set; }

        [Required]
        public bool IsDefault { get; set; }
    }
}
