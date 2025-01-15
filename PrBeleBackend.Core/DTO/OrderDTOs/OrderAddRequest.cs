using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrBeleBackend.Core.Enums;

namespace PrBeleBackend.Core.DTO.OrderDTOs
{
    public class OrderAddRequest
    {
        [Required, StringLength(64)]
        public string? FullName { get; set; }
        [Required, Phone, StringLength(16)]
        public string? PhoneNumber { get; set; }
        [Required, StringLength(255)]
        public string? Address { get; set; }
        public string? Note { get; set; }

    }
}
