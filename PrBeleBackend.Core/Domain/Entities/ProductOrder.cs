using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Domain.Entities
{
    public class ProductOrder
    {
        public int OrderId { get; set; }
        public int VariantId { get; set; }
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal OriginalPrice { get; set; } // Giá gốc
        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountValue { get; set; } // Giá trị giảm giá
        [Column(TypeName = "decimal(18,2)")]
        public decimal FinalPrice { get; set; }    // Giá sau giảm
        public bool IsRating {  get; set; } = false;
        public Order? Order { get; set; }
        public Variant? Variant { get; set; }
    }
}
