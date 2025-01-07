using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.DTO.VariantDTOs
{
    public class VariantAdderRequest
    {
        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Status { get; set; }

        [Required]
        public List<int> AttributeValueId { get; set; }

        [Required]
        public IFormFile VariantFile { get; set; }
    }
}
