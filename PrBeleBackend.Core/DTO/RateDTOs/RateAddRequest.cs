using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.DTO.RateDTOs
{
    public class RateAddRequest
    {
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Range(1,5)]
        public int Star { get; set; }
        [StringLength(255)]
        public string? Content { get; set; }
    }
}
