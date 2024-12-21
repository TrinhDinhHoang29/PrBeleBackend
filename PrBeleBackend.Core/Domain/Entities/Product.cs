using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Domain.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? DescriptionPlainText { get; set; }
        public int CategoryId { get; set; }
        public string? Thumbnail { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal BasePrice { get; set; }

        public int View {  get; set; }

        public int Like { get; set; }

        public string? Slug { get; set; }

        public int Status { get; set; }

        public bool Deleted { get; set; } = false;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Category? Category { get; set; }

        public List<ProductAttributeType>? ProductAttributeTypes { get; set; }
        
        public List<Variant>? Variants { get; set; }
    }
}
