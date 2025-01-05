using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.DTO.DiscountDTOs
{
    public class DiscountUpdateRequest
    {
        [Required, StringLength(64)]
        public string? Name { get; set; }
        [Required, Range(0, 100, ErrorMessage = "Discount value must be between 0 and 100.")]
        public int DiscountValue { get; set; }
        [Required]
        public DateTime ExpireDate { get; set; }

        [Range(0, 1, ErrorMessage = "Status must be either 0 or 1.")]
        public int Status { get; set; }
    }
}
