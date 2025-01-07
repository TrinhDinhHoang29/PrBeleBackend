using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.DTO.ProductDTOs
{
    public class ProductUpdateRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal BasePrice { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [DefaultValue(0)]
        public int DiscountId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public List<int> AttributeType { get; set; }

        public IFormFile ProductFile { get; set; }
    }
}
