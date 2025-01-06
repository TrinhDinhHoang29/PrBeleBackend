using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Domain.Entities
{
    public class Variant
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }
        [Column(TypeName = "decimal(18,2)")]

        public decimal Price { get; set; }

        public int Stock {  get; set; }

        public string? Thumbnail { get; set; } 

        public int Status { get; set; }

        public bool Deleted { get; set; } = false;

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Product? Product { get; set; }
        public List<ProductCart> ProductCarts {  get; set; } 
        public List<ProductOrder> ProductOrders { get; set; }
        public List<VariantAttributeValue>? VariantAttributeValues { get; set; }
    }
}
