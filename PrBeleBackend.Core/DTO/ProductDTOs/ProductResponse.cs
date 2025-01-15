using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.DTO.CategoryDTOs;
using PrBeleBackend.Core.DTO.VariantDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PrBeleBackend.Core.DTO.ProductDTOs
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public int CategoryStatus { get; set; }
        public string Description { get; set; }
        public Discount Discount { get; set; }
        public decimal BasePrice { get; set; }
        public string Slug { get; set; }
        public string Thumbnail { get; set; }
        public int View { get; set; }
        public int Like { get; set; }
        public int Status { get; set; }
        public List<int> RateAVG { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<VariantColorReponse> VariantColors { get; set; }
        public List<AttributeType> AttributeTypes { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
